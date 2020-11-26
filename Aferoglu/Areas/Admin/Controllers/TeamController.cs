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
    public class TeamController : Controller
    {
        private readonly AferogluDbContext _context;
        private readonly IWebHostEnvironment _env;

        public TeamController(AferogluDbContext context,
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
            return View(_context.OurTeam);
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

            OurTeamLang category = await _context.OurTeamLangs.FirstOrDefaultAsync(p => p.OurTeam.Id == id && p.Lang.Code.ToLower() == "az");
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

            OurTeam category = await _context.OurTeam.FindAsync(id);
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
            OurTeam category = await _context.OurTeam.FindAsync(id);

            string computerPhoto = Path.Combine(_env.WebRootPath, "images", category.PhotoURL);

            if (System.IO.File.Exists(computerPhoto))
            {
                System.IO.File.Delete(computerPhoto);
            }

            _context.OurTeam.Remove(category);

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
        public async Task<IActionResult> Create(CreateTeamVM category)
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

            OurTeam newCategory = new OurTeam()
            {
                PhotoURL = fileName,
            };

            await _context.OurTeam.AddAsync(newCategory);
            await _context.SaveChangesAsync();
            OurTeamLang historyAZ = new OurTeamLang
            {
                FullName = category.FullNameAZ,
                Profession = category.ProfessionAZ,
                LangId = azLang.Id,
                OurTeamId = newCategory.Id
            };
            OurTeamLang historyEN = new OurTeamLang
            {
                FullName = category.FullNameEN,
                Profession = category.ProfessionEN,
                LangId = enLang.Id,
                OurTeamId = newCategory.Id
            };
            OurTeamLang historyRU = new OurTeamLang
            {
                FullName = category.FullNameRU,
                Profession = category.ProfessionRU,
                LangId = ruLang.Id,
                OurTeamId = newCategory.Id
            };

            _context.OurTeamLangs.AddRange(historyAZ, historyEN, historyRU);
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
            OurTeam category = _context.OurTeam.Find(id);
            var viewModel = new CreateTeamVM
            {
                FullNameAZ = category.OurTeamLangs.FirstOrDefault(x => x.Lang.Code.ToLower() == "az").FullName,
                FullNameEN = category.OurTeamLangs.FirstOrDefault(x => x.Lang.Code.ToLower() == "en").FullName,
                FullNameRU = category.OurTeamLangs.FirstOrDefault(x => x.Lang.Code.ToLower() == "ru").FullName,
                ProfessionAZ = category.OurTeamLangs.FirstOrDefault(x => x.Lang.Code.ToLower() == "az").Profession,
                ProfessionEN = category.OurTeamLangs.FirstOrDefault(x => x.Lang.Code.ToLower() == "en").Profession,
                ProfessionRU = category.OurTeamLangs.FirstOrDefault(x => x.Lang.Code.ToLower() == "ru").Profession,
            };

            return View(viewModel);
        }

        [ActionName("Edit")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> EditPost(int id, CreateTeamVM category)
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
            OurTeam newCategory = await _context.OurTeam.FindAsync(id);
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
            OurTeamLang azBlogLangFromDb = await _context.OurTeamLangs.FirstOrDefaultAsync(x => x.Lang.Code.ToLower() == "az"
                                                                                && x.OurTeamId == newCategory.Id);

            OurTeamLang ruBlogLangFromDb = await _context.OurTeamLangs.FirstOrDefaultAsync(x => x.Lang.Code.ToLower() == "ru"
                                                                                       && x.OurTeamId == newCategory.Id);

            OurTeamLang enBlogLangFromDb = await _context.OurTeamLangs.FirstOrDefaultAsync(x => x.Lang.Code.ToLower() == "en"
                                                                                       && x.OurTeamId == newCategory.Id);

            azBlogLangFromDb.FullName = category.FullNameAZ;
            enBlogLangFromDb.FullName = category.FullNameEN;
            ruBlogLangFromDb.FullName = category.FullNameRU;
            azBlogLangFromDb.Profession = category.ProfessionAZ;
            enBlogLangFromDb.Profession = category.ProfessionEN;
            ruBlogLangFromDb.Profession = category.ProfessionRU;

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
    }
}
