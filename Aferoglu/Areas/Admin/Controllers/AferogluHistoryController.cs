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
    public class AferogluHistoryController : Controller
    {
        private readonly AferogluDbContext _context;
        private readonly IWebHostEnvironment _env;

        public AferogluHistoryController(AferogluDbContext context,
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
            return View(_context.AferogluHistory);
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

            AferogluHistoryLang category = await _context.AferogluHistoryLangs.FirstOrDefaultAsync(p => p.AferogluHistory.Id == id && p.Lang.Code.ToLower() == "az");
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

            AferogluHistory category = await _context.AferogluHistory.FindAsync(id);
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
            AferogluHistory category = await _context.AferogluHistory.FindAsync(id);

            string computerPhoto = Path.Combine(_env.WebRootPath, "images", category.PhotoUrl);

            if (System.IO.File.Exists(computerPhoto))
            {
                System.IO.File.Delete(computerPhoto);
            }

            _context.AferogluHistory.Remove(category);

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
        public async Task<IActionResult> Create(CreateHistoryVM category)
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

            AferogluHistory newCategory = new AferogluHistory()
            {
                Date = category.Date,
                PhotoUrl = fileName
            };

            await _context.AferogluHistory.AddAsync(newCategory);
            await _context.SaveChangesAsync();

            AferogluHistoryLang historyAZ = new AferogluHistoryLang
            {
                Header = category.HeaderAZ,
                Description = category.DescriptionAZ,
                LangId = azLang.Id,
                AferogluHistoryId = newCategory.Id
            };
            AferogluHistoryLang historyEN = new AferogluHistoryLang
            {
                Header = category.HeaderEN,
                Description = category.DescriptionEN,
                LangId = enLang.Id,
                AferogluHistoryId = newCategory.Id
            };
            AferogluHistoryLang historyRU = new AferogluHistoryLang
            {
                Header = category.HeaderRU,
                Description = category.DescriptionRU,
                LangId = ruLang.Id,
                AferogluHistoryId = newCategory.Id
            };

            _context.AferogluHistoryLangs.AddRange(historyAZ, historyEN, historyRU);
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
            AferogluHistory category = _context.AferogluHistory.Find(id);

            var viewModel = new CreateHistoryVM
            {
                HeaderAZ = category.AferogluHistoryLangs.FirstOrDefault(x => x.Lang.Code.ToLower() == "az").Header,
                HeaderEN = category.AferogluHistoryLangs.FirstOrDefault(x => x.Lang.Code.ToLower() == "en").Header,
                HeaderRU = category.AferogluHistoryLangs.FirstOrDefault(x => x.Lang.Code.ToLower() == "ru").Header,
                DescriptionAZ = category.AferogluHistoryLangs.FirstOrDefault(x => x.Lang.Code.ToLower() == "az").Description,
                DescriptionEN = category.AferogluHistoryLangs.FirstOrDefault(x => x.Lang.Code.ToLower() == "en").Description,
                DescriptionRU = category.AferogluHistoryLangs.FirstOrDefault(x => x.Lang.Code.ToLower() == "ru").Description,
                Date = category.Date,
            };

            return View(viewModel);
        }

        [ActionName("Edit")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> EditPost(int id, CreateHistoryVM category)
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
            AferogluHistory newCategory = await _context.AferogluHistory.FindAsync(id);
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

            AferogluHistoryLang azBlogLangFromDb = await _context.AferogluHistoryLangs.FirstOrDefaultAsync(x => x.Lang.Code.ToLower() == "az"
                                                                                  && x.AferogluHistoryId == newCategory.Id);

            AferogluHistoryLang ruBlogLangFromDb = await _context.AferogluHistoryLangs.FirstOrDefaultAsync(x => x.Lang.Code.ToLower() == "ru"
                                                                                       && x.AferogluHistoryId == newCategory.Id);

            AferogluHistoryLang enBlogLangFromDb = await _context.AferogluHistoryLangs.FirstOrDefaultAsync(x => x.Lang.Code.ToLower() == "en"
                                                                                       && x.AferogluHistoryId == newCategory.Id);

            newCategory.Date = category.Date;
            azBlogLangFromDb.Header = category.HeaderAZ;
            enBlogLangFromDb.Header = category.HeaderEN;
            ruBlogLangFromDb.Header = category.HeaderRU;
            azBlogLangFromDb.Description = category.DescriptionAZ;
            azBlogLangFromDb.Description = category.DescriptionEN;
            azBlogLangFromDb.Description = category.DescriptionRU;

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
    }
}
