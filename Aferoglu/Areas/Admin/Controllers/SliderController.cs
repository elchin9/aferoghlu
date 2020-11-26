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
    public class SliderController : Controller
    {
        private readonly AferogluDbContext _context;
        private readonly IWebHostEnvironment _env;

        public SliderController(AferogluDbContext context,
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
            return View(_context.Sliders);
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
            Slider slider = _context.Sliders.Find(id);
            var viewModel = new CreateSliderVM
            {
                HeaderAZ = slider.SliderLangs.FirstOrDefault(x => x.Lang.Code.ToLower() == "az").Header,
                HeaderEN = slider.SliderLangs.FirstOrDefault(x => x.Lang.Code.ToLower() == "en").Header,
                HeaderRU = slider.SliderLangs.FirstOrDefault(x => x.Lang.Code.ToLower() == "ru").Header,
                DescriptionAZ = slider.SliderLangs.FirstOrDefault(x => x.Lang.Code.ToLower() == "az").Description,
                DescriptionEN = slider.SliderLangs.FirstOrDefault(x => x.Lang.Code.ToLower() == "en").Description,
                DescriptionRU = slider.SliderLangs.FirstOrDefault(x => x.Lang.Code.ToLower() == "ru").Description,

            };

            return View(viewModel);
        }

        [ActionName("Edit")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> EditPost(int id, CreateSliderVM slider)
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
                return View(slider);
            }

            Slider newSlider = await _context.Sliders.FindAsync(id);
            if (newSlider == null) return View("Error");

            if (slider.Photo != null)
            {
                string computerPhoto = Path.Combine(_env.WebRootPath, "images", newSlider.PhotoUrl);

                if (System.IO.File.Exists(computerPhoto))
                {
                    System.IO.File.Delete(computerPhoto);
                }

                string fileName = await slider.Photo.SaveAsync(_env.WebRootPath);
                newSlider.PhotoUrl = fileName;
            }
            SliderLang azBlogLangFromDb = await _context.SliderLangs.FirstOrDefaultAsync(x => x.Lang.Code.ToLower() == "az"
                                                                                && x.SliderId == newSlider.Id);

            SliderLang ruBlogLangFromDb = await _context.SliderLangs.FirstOrDefaultAsync(x => x.Lang.Code.ToLower() == "ru"
                                                                                       && x.SliderId == newSlider.Id);

            SliderLang enBlogLangFromDb = await _context.SliderLangs.FirstOrDefaultAsync(x => x.Lang.Code.ToLower() == "en"
                                                                                       && x.SliderId == newSlider.Id);

            azBlogLangFromDb.Header = slider.HeaderAZ;
            enBlogLangFromDb.Header = slider.HeaderEN;
            ruBlogLangFromDb.Header = slider.HeaderRU;
            azBlogLangFromDb.Description = slider.DescriptionAZ;
            azBlogLangFromDb.Description = slider.DescriptionEN;
            azBlogLangFromDb.Description = slider.DescriptionRU;

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
    }
}
