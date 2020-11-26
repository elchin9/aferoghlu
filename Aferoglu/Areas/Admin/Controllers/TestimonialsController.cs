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
    public class TestimonialsController : Controller
    {
        private readonly AferogluDbContext _context;
        private readonly IWebHostEnvironment _env;

        public TestimonialsController(AferogluDbContext context,
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
            return View(_context.Testimonials);
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

            TestimonialsLang category = await _context.TestimonialsLangs.FirstOrDefaultAsync(p => p.Testimonials.Id == id && p.Lang.Code.ToLower() == "az");
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

            Testimonials category = await _context.Testimonials.FindAsync(id);
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
            Testimonials category = await _context.Testimonials.FindAsync(id);

            string computerPhoto = Path.Combine(_env.WebRootPath, "images", category.PhotoURL);

            if (System.IO.File.Exists(computerPhoto))
            {
                System.IO.File.Delete(computerPhoto);
            }

            _context.Testimonials.Remove(category);

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
        public async Task<IActionResult> Create(CreateTestimonialsVM category)
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

            Testimonials newCategory = new Testimonials()
            {
                PhotoURL = fileName,
            };

            await _context.Testimonials.AddAsync(newCategory);
            await _context.SaveChangesAsync();

            TestimonialsLang historyAZ = new TestimonialsLang
            {
                FullName = category.FullNameAZ,
                Description = category.DescriptionAZ,
                LangId = azLang.Id,
                TestimonialsId = newCategory.Id
            };
            TestimonialsLang historyEN = new TestimonialsLang
            {
                FullName = category.FullNameEN,
                Description = category.DescriptionEN,
                LangId = enLang.Id,
                TestimonialsId = newCategory.Id
            };
            TestimonialsLang historyRU = new TestimonialsLang
            {
                FullName = category.FullNameRU,
                Description = category.DescriptionRU,
                LangId = ruLang.Id,
                TestimonialsId = newCategory.Id
            };

            _context.TestimonialsLangs.AddRange(historyAZ, historyEN, historyRU);
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
            Testimonials category = _context.Testimonials.Find(id);
            var viewModel = new CreateTestimonialsVM
            {
                FullNameAZ = category.TestimonialLangs.FirstOrDefault(x => x.Lang.Code.ToLower() == "az").FullName,
                FullNameEN = category.TestimonialLangs.FirstOrDefault(x => x.Lang.Code.ToLower() == "en").FullName,
                FullNameRU = category.TestimonialLangs.FirstOrDefault(x => x.Lang.Code.ToLower() == "ru").FullName,
                DescriptionAZ = category.TestimonialLangs.FirstOrDefault(x => x.Lang.Code.ToLower() == "az").Description,
                DescriptionEN = category.TestimonialLangs.FirstOrDefault(x => x.Lang.Code.ToLower() == "en").Description,
                DescriptionRU = category.TestimonialLangs.FirstOrDefault(x => x.Lang.Code.ToLower() == "ru").Description,
            };

            return View(viewModel);
        }

        [ActionName("Edit")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> EditPost(int id, CreateTestimonialsVM category)
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
            Testimonials newCategory = await _context.Testimonials.FindAsync(id);
            if (newCategory == null) return View("Error");

            if (category.Photo != null)
            {
                string computerPhoto = Path.Combine(_env.WebRootPath, "images", newCategory.PhotoURL);

                if (System.IO.File.Exists(computerPhoto))
                {
                    System.IO.File.Delete(computerPhoto);
                }

                string fileName = await category.Photo.SaveAsync(_env.WebRootPath);
                newCategory.PhotoURL = fileName;
            }
            TestimonialsLang azBlogLangFromDb = await _context.TestimonialsLangs.FirstOrDefaultAsync(x => x.Lang.Code.ToLower() == "az"
                                                                               && x.TestimonialsId == newCategory.Id);

            TestimonialsLang ruBlogLangFromDb = await _context.TestimonialsLangs.FirstOrDefaultAsync(x => x.Lang.Code.ToLower() == "ru"
                                                                                       && x.TestimonialsId == newCategory.Id);

            TestimonialsLang enBlogLangFromDb = await _context.TestimonialsLangs.FirstOrDefaultAsync(x => x.Lang.Code.ToLower() == "en"
                                                                                       && x.TestimonialsId == newCategory.Id);

            azBlogLangFromDb.FullName = category.FullNameAZ;
            enBlogLangFromDb.FullName = category.FullNameEN;
            ruBlogLangFromDb.FullName = category.FullNameRU;
            azBlogLangFromDb.Description = category.DescriptionAZ;
            enBlogLangFromDb.Description = category.DescriptionEN;
            ruBlogLangFromDb.Description = category.DescriptionRU;

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
    }
}
