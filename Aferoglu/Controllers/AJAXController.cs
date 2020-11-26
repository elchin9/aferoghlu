using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Aferoglu.DAL;
using Aferoglu.Helpers;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Aferoglu.Controllers
{
    public class AJAXController : Controller
    {
        private readonly AferogluDbContext _context;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public AJAXController(AferogluDbContext context, IHttpContextAccessor httpContextAccessor)
        {
            _context = context;
            _httpContextAccessor = httpContextAccessor;
        }


        public IActionResult LoadMessageIndex(int skip)
        {
            var model =
                _context.MailBoxes.OrderByDescending(g => g.Id).Skip(skip).Take(10);

            return PartialView("_MailBoxIndexPartialView", model);
        }


        public async Task<IActionResult> LoadProduct(string _lang = "az", int skip = 0)
        {
            ViewBag.Lang = _lang;
            MainHelper.SetLang(_httpContextAccessor, _lang);

            var model =
                await _context.ProductLangs.OrderByDescending(p => p.Id).Where(a => a.Lang.Code.ToLower() == _lang).Skip(skip).Take(12).ToListAsync();

            return PartialView("_ProductPartialView", model);
        }

        public async Task<IActionResult> LoadProductByCategory(string _lang = "az", int id = 1)
        {
            ViewBag.Lang = _lang;
            MainHelper.SetLang(_httpContextAccessor, _lang);

            var model =
                await _context.ProductLangs.OrderByDescending(p => p.Id).Where(a => a.Lang.Code.ToLower() == _lang && a.Product.CategoryId == id).ToListAsync();

            return PartialView("_ProductPartialView", model);
        }

    }
}
