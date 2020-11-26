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
    public class AboutController : Controller
    {
        private readonly AferogluDbContext _context;
        private readonly IWebHostEnvironment _env;

        public AboutController(AferogluDbContext context, IWebHostEnvironment env)
        {
            _context = context;
            _env = env;
        }

        public async Task<IActionResult> Index()
        {
            if (!User.Identity.IsAuthenticated)
            {
                return RedirectToAction("Login", "Account");
            }

            if (!User.IsInRole("Admin"))
            {
                return RedirectToAction("Login", "Account");
            }

            var about = await _context.AboutLang.FirstOrDefaultAsync();

            return View(about);
        }

        public async Task<IActionResult> Edit(int id)
        {
            if (!User.Identity.IsAuthenticated)
            {
                return RedirectToAction("Login", "Account");
            }

            if (!User.IsInRole("Admin"))
            {
                return RedirectToAction("Login", "Account");
            }

            var about = await _context.About.FirstOrDefaultAsync(p => p.Id == id);
            var viewModel = new CreateAboutVM
            {
                DescriptionAZ = about.AboutLangs.FirstOrDefault(x => x.Lang.Code.ToLower() == "az").Description,
                DescriptionEN = about.AboutLangs.FirstOrDefault(x => x.Lang.Code.ToLower() == "en").Description,
                DescriptionRU = about.AboutLangs.FirstOrDefault(x => x.Lang.Code.ToLower() == "ru").Description,
            };

            return View(viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, CreateAboutVM about)
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
                return View(about);
            }

            var currentAbout = await _context.About.FirstOrDefaultAsync(p => p.Id == id);

            if (about.Photo != null)
            {
                string computerPhoto = Path.Combine(_env.WebRootPath, "images", currentAbout.PhotoURL);

                if (System.IO.File.Exists(computerPhoto))
                {
                    System.IO.File.Delete(computerPhoto);
                }

                string filename = await about.Photo.SaveAsync(_env.WebRootPath);
                currentAbout.PhotoURL = filename;
            }

            AboutLang azBlogLangFromDb = await _context.AboutLang.FirstOrDefaultAsync(x => x.Lang.Code.ToLower() == "az"
                                                                                   && x.AboutId == currentAbout.Id);

            AboutLang ruBlogLangFromDb = await _context.AboutLang.FirstOrDefaultAsync(x => x.Lang.Code.ToLower() == "ru"
                                                                                       && x.AboutId == currentAbout.Id);

            AboutLang enBlogLangFromDb = await _context.AboutLang.FirstOrDefaultAsync(x => x.Lang.Code.ToLower() == "en"
                                                                                       && x.AboutId == currentAbout.Id);

            azBlogLangFromDb.Description = about.DescriptionAZ;
            enBlogLangFromDb.Description = about.DescriptionEN;
            ruBlogLangFromDb.Description = about.DescriptionRU;

            await _context.SaveChangesAsync();

            return RedirectToAction("Index", "About");
        }
    }
}
