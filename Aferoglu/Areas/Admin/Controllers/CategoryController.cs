using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Aferoglu.DAL;
using Aferoglu.Extensions;
using Aferoglu.Models;
using Aferoglu.ViewModels;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Aferoglu.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class CategoryController : Controller
    {
        private readonly AferogluDbContext _context;
        private readonly IWebHostEnvironment _env;

        public CategoryController(AferogluDbContext context,
                                       IWebHostEnvironment env)
        {
            _context = context;
            _env = env;
        }

        public IActionResult Index()
        {
            if (!User.Identity.IsAuthenticated)
            {
                return RedirectToAction("Login", "Account");
            }

            if (!User.IsInRole("Admin"))
            {
                return RedirectToAction("Login", "Account");
            }
            return View(_context.Category);
        }

        public async Task<IActionResult> Details(int? id)
        {
            if (!User.Identity.IsAuthenticated)
            {
                return RedirectToAction("Login", "Account");
            }

            if (!User.IsInRole("Admin"))
            {
                return RedirectToAction("Login", "Account");
            }
            if (id == null) return View("Error");

            CategoryLang category = await _context.CategoryLangs.FirstOrDefaultAsync(p=> p.Category.Id ==id && p.Lang.Code.ToLower() == "az");
            if (category == null) return View("Error");
            return View(category);
        }
        public async Task<IActionResult> Delete(int? id)
        {
            if (!User.Identity.IsAuthenticated)
            {
                return RedirectToAction("Login", "Account");
            }

            if (!User.IsInRole("Admin"))
            {
                return RedirectToAction("Login", "Account");
            }
            if (id == null) return View("Error");

            Category category = await _context.Category.FindAsync(id);
            if (category == null) return View("Error");
            return View(category);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [ActionName("Delete")]
        public async Task<IActionResult> DeletePost(int? id)
        {
            if (!User.Identity.IsAuthenticated)
            {
                return RedirectToAction("Login", "Account");
            }

            if (!User.IsInRole("Admin"))
            {
                return RedirectToAction("Login", "Account");
            }
            Category category = await _context.Category.FindAsync(id);

            string computerPhoto = Path.Combine(_env.WebRootPath, "images", category.PhotoUrl);

            if (System.IO.File.Exists(computerPhoto))
            {
                System.IO.File.Delete(computerPhoto);
            }

            _context.Category.Remove(category);

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        public IActionResult Create()
        {
            if (!User.Identity.IsAuthenticated)
            {
                return RedirectToAction("Login", "Account");
            }

            if (!User.IsInRole("Admin"))
            {
                return RedirectToAction("Login", "Account");
            }

            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(CreateCategoryVM category)
        {
            if (!User.Identity.IsAuthenticated)
            {
                return RedirectToAction("Login", "Account");
            }

            if (!User.IsInRole("Admin"))
            {
                return RedirectToAction("Login", "Account");
            }
            if (!ModelState.IsValid)
            {
                return View(category);
            }

            if (category.Photo == null)
            {
                return View(category);
            }

            string fileName = await category.Photo.SaveAsync(_env.WebRootPath);
            Lang azLang = await _context.Langs.FirstOrDefaultAsync(x => x.Code.ToLower() == "az");
            Lang ruLang = await _context.Langs.FirstOrDefaultAsync(x => x.Code.ToLower() == "ru");
            Lang enLang = await _context.Langs.FirstOrDefaultAsync(x => x.Code.ToLower() == "en");

            Category newCategory = new Category()
            {
                PhotoUrl = fileName
            };

            await _context.Category.AddAsync(newCategory);
            await _context.SaveChangesAsync();

            CategoryLang historyAZ = new CategoryLang
            {
                Name = category.NameAZ,
                LangId = azLang.Id,
                CategoryId = newCategory.Id
            };
            CategoryLang historyEN = new CategoryLang
            {
                Name = category.NameEN,
                LangId = enLang.Id,
                CategoryId = newCategory.Id
            };
            CategoryLang historyRU = new CategoryLang
            {
                Name = category.NameRU,
                LangId = ruLang.Id,
                CategoryId = newCategory.Id
            };

            _context.CategoryLangs.AddRange(historyAZ, historyEN, historyRU);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        [ActionName("Edit")]
        public IActionResult Edit(int? id)
        {
            if (!User.Identity.IsAuthenticated)
            {
                return RedirectToAction("Login", "Account");
            }

            if (!User.IsInRole("Admin"))
            {
                return RedirectToAction("Login", "Account");
            }
            if (id == null) return View("Error");
            Category category = _context.Category.Find(id);
            var viewModel = new CreateCategoryVM
            {
                NameAZ = category.CategoryLangs.FirstOrDefault(x => x.Lang.Code.ToLower() == "az").Name,
                NameEN = category.CategoryLangs.FirstOrDefault(x => x.Lang.Code.ToLower() == "en").Name,
                NameRU = category.CategoryLangs.FirstOrDefault(x => x.Lang.Code.ToLower() == "ru").Name,
            };

            return View(viewModel);
        }

        [ActionName("Edit")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> EditPost(int id, CreateCategoryVM category)
        {
            if (!User.Identity.IsAuthenticated)
            {
                return RedirectToAction("Login", "Account");
            }

            if (!User.IsInRole("Admin"))
            {
                return RedirectToAction("Login", "Account");
            }
            if (!ModelState.IsValid)
            {
                ModelState.AddModelError("", "Xaiş olunur düzgün doldurun.");
                return View(category);
            }
            Category newCategory = await _context.Category.FindAsync(id);
            if (newCategory == null) return View("Error");

            if (category.Photo != null)
            {
                string computerPhoto = Path.Combine(_env.WebRootPath, "images", newCategory.PhotoUrl);

                if (System.IO.File.Exists(computerPhoto))
                {
                    System.IO.File.Delete(computerPhoto);
                }

                string fileName = await category.Photo.SaveAsync(_env.WebRootPath);
                newCategory.PhotoUrl = fileName;
            }
            CategoryLang azBlogLangFromDb = await _context.CategoryLangs.FirstOrDefaultAsync(x => x.Lang.Code.ToLower() == "az"
                                                                                 && x.CategoryId == newCategory.Id);

            CategoryLang ruBlogLangFromDb = await _context.CategoryLangs.FirstOrDefaultAsync(x => x.Lang.Code.ToLower() == "ru"
                                                                                       && x.CategoryId == newCategory.Id);

            CategoryLang enBlogLangFromDb = await _context.CategoryLangs.FirstOrDefaultAsync(x => x.Lang.Code.ToLower() == "en"
                                                                                       && x.CategoryId == newCategory.Id);

            azBlogLangFromDb.Name = category.NameAZ;
            enBlogLangFromDb.Name = category.NameEN;
            ruBlogLangFromDb.Name = category.NameRU;

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
    }
}
