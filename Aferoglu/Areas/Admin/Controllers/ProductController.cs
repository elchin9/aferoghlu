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
    public class ProductController : Controller
    {
        private readonly AferogluDbContext _context;
        private readonly IWebHostEnvironment _env;

        public ProductController(AferogluDbContext context,
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

            return View(_context.ProductLangs.Where(p => p.Lang.Code.ToLower() == "az").ToList());
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

            ProductLang category = await _context.ProductLangs.FirstOrDefaultAsync(p=> p.Product.Id == id && p.Lang.Code.ToLower() == "az");
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

            Product category = await _context.Products.FindAsync(id);
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
            Product category = await _context.Products.FindAsync(id);

            foreach(var p in category.Photos)
            {
                string computerPhoto = Path.Combine(_env.WebRootPath, "images", p.PhotoURL);

                if (System.IO.File.Exists(computerPhoto))
                {
                    System.IO.File.Delete(computerPhoto);
                }

                IEnumerable<ProductPhoto> productPhotos = _context.ProductPhotos.Where(p => p.ProductId == id);

                _context.ProductPhotos.RemoveRange(productPhotos);
            }


            _context.Products.Remove(category);

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Create()
        {
            if (!User.Identity.IsAuthenticated)
            {
                return RedirectToAction("Login", "Account");
            }

            if (!User.IsInRole("Admin"))
            {
                return RedirectToAction("Login", "Account");
            }

            ViewBag.Category = await _context.CategoryLangs.Where(p => p.Lang.Code.ToLower() == "az").ToListAsync();
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(CreateProductVM category)
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
                ViewBag.Category = await _context.CategoryLangs.Where(p => p.Lang.Code.ToLower() == "az").ToListAsync();


                return View(category);
            }

            if (category.AllPhotos == null)
            {
                ViewBag.Category = await _context.CategoryLangs.Where(p => p.Lang.Code.ToLower() == "az").ToListAsync();


                return View(category);
            }
            Lang azLang = await _context.Langs.FirstOrDefaultAsync(x => x.Code.ToLower() == "az");
            Lang ruLang = await _context.Langs.FirstOrDefaultAsync(x => x.Code.ToLower() == "ru");
            Lang enLang = await _context.Langs.FirstOrDefaultAsync(x => x.Code.ToLower() == "en");

            Product newCategory = new Product()
            {
                Price = category.Price,
                CategoryId = category.CategoryId,
                IsStock = category.IsStock
            };

            await _context.Products.AddAsync(newCategory);
            await _context.SaveChangesAsync();

            foreach (var p in category.AllPhotos)
            {
                string fileName = await p.SaveAsync(_env.WebRootPath);

                ProductPhoto photo = new ProductPhoto
                {
                    PhotoURL = fileName,
                    ProductId = newCategory.Id
                };

                await _context.ProductPhotos.AddAsync(photo);
            }

            ProductLang historyAZ = new ProductLang
            {
                Name = category.NameAZ,
                Description = category.DescriptionAZ,
                Maifacturer = category.MaifacturerAZ,
                LangId = azLang.Id,
                ProductId = newCategory.Id
            };
            ProductLang historyEN = new ProductLang
            {
                Name = category.NameEN,
                Description = category.DescriptionEN,
                Maifacturer = category.MaifacturerEN,
                LangId = enLang.Id,
                ProductId = newCategory.Id
            };
            ProductLang historyRU = new ProductLang
            {
                Name = category.NameRU,
                Description = category.DescriptionRU,
                Maifacturer = category.MaifacturerRU,
                LangId = ruLang.Id,
                ProductId = newCategory.Id
            };

            _context.ProductLangs.AddRange(historyAZ, historyEN, historyRU);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        [ActionName("Edit")]
        public async Task<IActionResult> Edit(int? id)
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
            Product category = _context.Products.Find(id);
            ViewBag.Category = await _context.CategoryLangs.Where(p => p.Lang.Code.ToLower() == "az").ToListAsync();

            var viewModel = new CreateProductVM
            {
                Price = category.Price,
                CategoryId = category.CategoryId,
                IsStock = category.IsStock,
                Size = category.Size,
                NameAZ = category.ProductLangs.FirstOrDefault(x => x.Lang.Code.ToLower() == "az").Name,
                NameEN = category.ProductLangs.FirstOrDefault(x => x.Lang.Code.ToLower() == "en").Name,
                NameRU = category.ProductLangs.FirstOrDefault(x => x.Lang.Code.ToLower() == "ru").Name,
                DescriptionAZ = category.ProductLangs.FirstOrDefault(x => x.Lang.Code.ToLower() == "az").Description,
                DescriptionEN = category.ProductLangs.FirstOrDefault(x => x.Lang.Code.ToLower() == "en").Description,
                DescriptionRU = category.ProductLangs.FirstOrDefault(x => x.Lang.Code.ToLower() == "ru").Description,
                MaifacturerAZ = category.ProductLangs.FirstOrDefault(x => x.Lang.Code.ToLower() == "az").Maifacturer,
                MaifacturerEN = category.ProductLangs.FirstOrDefault(x => x.Lang.Code.ToLower() == "en").Maifacturer,
                MaifacturerRU = category.ProductLangs.FirstOrDefault(x => x.Lang.Code.ToLower() == "ru").Maifacturer,
            };

            return View(viewModel);
        }

        [ActionName("Edit")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> EditPost(int id, CreateProductVM category)
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
                ViewBag.Category = await _context.CategoryLangs.Where(p => p.Lang.Code.ToLower() == "az").ToListAsync();


                ModelState.AddModelError("", "Xaiş olunur düzgün doldurun.");
                return View(category);
            }

            Product newCategory = await _context.Products.FindAsync(id);
            if (newCategory == null) return View("Error");

            if (category.AllPhotos != null)
            {
                foreach (var p in newCategory.Photos)
                {
                    string computerPhoto = Path.Combine(_env.WebRootPath, "images", p.PhotoURL);

                    if (System.IO.File.Exists(computerPhoto))
                    {
                        System.IO.File.Delete(computerPhoto);
                    }

                    IEnumerable<ProductPhoto> productPhotos = _context.ProductPhotos.Where(p => p.ProductId == newCategory.Id);

                    _context.ProductPhotos.RemoveRange(productPhotos);
                }

                foreach (var p in category.AllPhotos)
                {
                    string fileName = await p.SaveAsync(_env.WebRootPath);

                    ProductPhoto photo = new ProductPhoto
                    {
                        PhotoURL = fileName,
                        ProductId = newCategory.Id
                    };

                    await _context.ProductPhotos.AddAsync(photo);
                }
            }
            ProductLang azBlogLangFromDb = await _context.ProductLangs.FirstOrDefaultAsync(x => x.Lang.Code.ToLower() == "az"
                                                                             && x.ProductId == newCategory.Id);

            ProductLang ruBlogLangFromDb = await _context.ProductLangs.FirstOrDefaultAsync(x => x.Lang.Code.ToLower() == "ru"
                                                                                       && x.ProductId == newCategory.Id);

            ProductLang enBlogLangFromDb = await _context.ProductLangs.FirstOrDefaultAsync(x => x.Lang.Code.ToLower() == "en"
                                                                                       && x.ProductId == newCategory.Id);

            azBlogLangFromDb.Name = category.NameAZ;
            enBlogLangFromDb.Name = category.NameEN;
            ruBlogLangFromDb.Name = category.NameRU;
            azBlogLangFromDb.Description = category.DescriptionAZ;
            enBlogLangFromDb.Description = category.DescriptionEN;
            ruBlogLangFromDb.Description = category.DescriptionRU;
            azBlogLangFromDb.Maifacturer = category.MaifacturerAZ;
            enBlogLangFromDb.Maifacturer = category.MaifacturerEN;
            ruBlogLangFromDb.Maifacturer = category.MaifacturerRU;

            newCategory.CategoryId = category.CategoryId;
            newCategory.IsStock = category.IsStock;
            newCategory.Price = category.Price;
            

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
    }
}
