using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Aferoglu.DAL;
using Aferoglu.Models;
using Aferoglu.ViewModels;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Aferoglu.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class StaticDataController : Controller
    {
        private readonly AferogluDbContext _context;
        private readonly IWebHostEnvironment _env;

        public StaticDataController(AferogluDbContext context,
                                       IWebHostEnvironment env)
        {
            _context = context;
            _env = env;
        }


        public IActionResult Details()
        {
            if (!User.Identity.IsAuthenticated)
            {
                return RedirectToAction("Login", "Account");
            }

            if (!User.IsInRole("Admin"))
            {
                return RedirectToAction("Login", "Account");
            }

            return View(_context.StaticDataLangs.FirstOrDefault(p=> p.Lang.Code.ToLower() == "az"));
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

            StaticData staticData = _context.StaticData.Find(id);
            var viewModel = new CreateStaticDataVM
            {
                Facebook = staticData.Facebook,
                Instagram = staticData.Instagram,
                Map = staticData.Map,
                EmailAdress = staticData.EmailAdress,
                PhoneNumberOne = staticData.PhoneNumberOne,
                PhoneNumberTwo = staticData.PhoneNumberTwo,
                AddressAZ = staticData.StaticDataLangs.FirstOrDefault(x => x.Lang.Code.ToLower() == "az").Address,
                AddressEN = staticData.StaticDataLangs.FirstOrDefault(x => x.Lang.Code.ToLower() == "en").Address,
                AddressRU = staticData.StaticDataLangs.FirstOrDefault(x => x.Lang.Code.ToLower() == "ru").Address,
                WorkingHoursAZ = staticData.StaticDataLangs.FirstOrDefault(x => x.Lang.Code.ToLower() == "az").WorkingHours,
                WorkingHoursEN = staticData.StaticDataLangs.FirstOrDefault(x => x.Lang.Code.ToLower() == "en").WorkingHours,
                WorkingHoursRU = staticData.StaticDataLangs.FirstOrDefault(x => x.Lang.Code.ToLower() == "ru").WorkingHours,
            };

            return View(viewModel);
        }

        [ActionName("Edit")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> EditPost(int id, CreateStaticDataVM staticData)
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
                return View(staticData);
            }

            StaticData currentData = await _context.StaticData.FindAsync(id);

            if (currentData == null) return View("Error");

            StaticDataLang azBlogLangFromDb = await _context.StaticDataLangs.FirstOrDefaultAsync(x => x.Lang.Code.ToLower() == "az"
                                                                              && x.StaticDataId == currentData.Id);

            StaticDataLang ruBlogLangFromDb = await _context.StaticDataLangs.FirstOrDefaultAsync(x => x.Lang.Code.ToLower() == "ru"
                                                                                       && x.StaticDataId == currentData.Id);

            StaticDataLang enBlogLangFromDb = await _context.StaticDataLangs.FirstOrDefaultAsync(x => x.Lang.Code.ToLower() == "en"
                                                                                       && x.StaticDataId == currentData.Id);

            currentData.EmailAdress = staticData.EmailAdress;
            currentData.Facebook = staticData.Facebook;
            currentData.Instagram = staticData.Instagram;
            currentData.PhoneNumberOne = staticData.PhoneNumberOne;
            currentData.PhoneNumberTwo = staticData.PhoneNumberTwo;
            azBlogLangFromDb.Address = staticData.AddressAZ;
            ruBlogLangFromDb.Address = staticData.AddressRU;
            enBlogLangFromDb.Address = staticData.AddressEN;
            currentData.Map = staticData.Map;
            azBlogLangFromDb.WorkingHours = staticData.WorkingHoursAZ;
            ruBlogLangFromDb.WorkingHours = staticData.WorkingHoursRU;
            enBlogLangFromDb.WorkingHours = staticData.WorkingHoursEN;


            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Details));
        }
    }
}
