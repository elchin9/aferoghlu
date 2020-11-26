using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Aferoglu.Models;
using Aferoglu.DAL;
using Microsoft.EntityFrameworkCore;
using Aferoglu.ViewModels;
using Microsoft.AspNetCore.Http;
using Aferoglu.Helpers;

namespace Aferoglu.Controllers
{
    public class HomeController : Controller
    {

        private readonly ILogger<HomeController> _logger;
        private readonly AferogluDbContext _context;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public HomeController(ILogger<HomeController> logger, AferogluDbContext context, IHttpContextAccessor httpContextAccessor)
        {
            _logger = logger;
            _context = context;
            _httpContextAccessor = httpContextAccessor;
            MainHelper.TryToSetLang(_httpContextAccessor);
        }

        [Route("/")]
        [Route("/{_lang}")]
        [Route("/{_lang}/home/index")]
        public async Task<IActionResult> Index(string _lang = "az")
        {
            ViewBag.Lang = _lang;
            MainHelper.SetLang(_httpContextAccessor, _lang);

            HomeViewModel viewModel = new HomeViewModel
            {
                Slider = await _context.SliderLangs.Where(a => a.Lang.Code.ToLower() == _lang).ToListAsync(),
                Category = await _context.CategoryLangs.Where(a => a.Lang.Code.ToLower() == _lang).ToListAsync(),
                Products = await _context.ProductLangs.Where(a => a.Lang.Code.ToLower() == _lang).Skip(0).Take(6).ToListAsync(),
                Abouts = await _context.AboutLang.FirstOrDefaultAsync(a => a.Lang.Code.ToLower() == _lang),
                OurTeam = await _context.OurTeamLangs.Where(p => p.Lang.Code.ToLower() == _lang).ToListAsync()
            };

            return View(viewModel);
        }

        [Route("/{_lang}/home/about")]
        public async Task<IActionResult> About(string _lang = "az")
        {
            ViewBag.Lang = _lang;
            MainHelper.SetLang(_httpContextAccessor, _lang);

            var viewModel = new AboutViewModel
            {
                History = await _context.AferogluHistoryLangs.Where(a => a.Lang.Code.ToLower() == _lang).ToListAsync(),
                Teams = await _context.OurTeamLangs.Where(a => a.Lang.Code.ToLower() == _lang).ToListAsync(),
                AboutLang = await _context.AboutLang.FirstOrDefaultAsync(a => a.Lang.Code.ToLower() == _lang),
                Testimonials = await _context.TestimonialsLangs.Where(a => a.Lang.Code.ToLower() == _lang).ToListAsync()
            };

            return View(viewModel);
        }


        public async Task<IActionResult> Shop(string _lang = "az")
        {
            ViewBag.Lang = _lang;
            MainHelper.SetLang(_httpContextAccessor, _lang);
            ViewBag.TotalCount = _context.Products.Count();

            var viewModel = new ShopViewModel
            {
                Categories = await _context.CategoryLangs.Where(a => a.Lang.Code.ToLower() == _lang).ToListAsync(),
                Products = await _context.ProductLangs.OrderByDescending(p => p.Id).Where(a => a.Lang.Code.ToLower() == _lang).Skip(0).Take(12).ToListAsync()
            };

            return View(viewModel);
        }

        public async Task<IActionResult> Service(string _lang = "az", int id = 1)
        {
            ViewBag.Lang = _lang;
            MainHelper.SetLang(_httpContextAccessor, _lang);

            return View(await _context.OurTeamLangs.Where(a => a.Lang.Code.ToLower() == _lang && a.OurTeam.Id == id).FirstOrDefaultAsync());
        }


        public async Task<IActionResult> ShopDetails(string _lang = "az", int id = 1)
        {
            ViewBag.Lang = _lang;
            MainHelper.SetLang(_httpContextAccessor, _lang);
            var product = await _context.ProductLangs.FirstOrDefaultAsync(p => p.ProductId == id && p.Lang.Code.ToLower() == _lang);

            if (product == null) return View("Error");


            return View(product);
        }


        public async Task<IActionResult> Contact(string _lang = "az")
        {
            ViewBag.Lang = _lang;
            MainHelper.SetLang(_httpContextAccessor, _lang);

            var map = await _context.StaticDataLangs.FirstOrDefaultAsync(p => p.Lang.Code.ToLower() == _lang);

            return View(map);
        }


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
