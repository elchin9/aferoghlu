using Aferoglu.DAL;
using Aferoglu.Helpers;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Aferoglu.ViewComponents
{
    public class SocialViewComponent : ViewComponent
    {
        private readonly AferogluDbContext _context;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public SocialViewComponent(AferogluDbContext context, IHttpContextAccessor httpContextAccessor)
        {
            _context = context;
            _httpContextAccessor = httpContextAccessor;
            MainHelper.TryToSetLang(_httpContextAccessor);
        }

        public async Task<IViewComponentResult> InvokeAsync(string _lang = "az")
        {
            ViewBag.Lang = _lang;
            MainHelper.SetLang(_httpContextAccessor, _lang);
            var social = _context.StaticDataLangs.FirstOrDefault(p => p.Lang.Code.ToLower() == _lang);

            return View(await Task.FromResult(social));
        }
    }
}
