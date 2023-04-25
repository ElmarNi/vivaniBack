using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using VivaniBack.DAL;
using VivaniBack.Models;
using static VivaniBack.Extensions.IFormFileEx;


namespace VivaniBack.Areas.admin.Controllers
{
    [Area("admin")]
    public class ProductController : Controller
    {
        private readonly VivaniDbContext _context;
        private readonly IWebHostEnvironment _env;
        public ProductController(VivaniDbContext context, IWebHostEnvironment env)
        {
            _context = context;
            _env = env;
        }
        public IActionResult Index()
        {
            if (User.Identity.IsAuthenticated && User.IsInRole("admin"))
                return View(_context.products.OrderByDescending(p => p.IsNew || p.IsBestSeller || p.IsTrendingProduct).ThenByDescending(p => p.Date));

            return Redirect("/admin/account");
        }

        public IActionResult Create()
        {
            if (User.Identity.IsAuthenticated && User.IsInRole("admin"))
            {
                List<SelectListItem> productCategories = new List<SelectListItem>();
                foreach (var item in _context.ProductCategories)
                    productCategories.Add(new SelectListItem { Text = item.Name, Value = item.Id.ToString() });

                ViewData["productCategories"] = productCategories;

                List<SelectListItem> productTypes = new List<SelectListItem>();
                foreach (var item in _context.productTypes)
                    productTypes.Add(new SelectListItem { Text = item.Name, Value = item.Id.ToString() });

                ViewData["productTypes"] = productTypes;

                return View();
            }

            return Redirect("/admin/account");
        }

        [HttpPost, ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Product product)
        {
            if (User.Identity.IsAuthenticated && User.IsInRole("admin"))
            {
                List<SelectListItem> productCategories = new List<SelectListItem>();
                foreach (var item in _context.ProductCategories)
                    productCategories.Add(new SelectListItem { Text = item.Name, Value = item.Id.ToString() });

                ViewData["productCategories"] = productCategories;

                List<SelectListItem> productTypes = new List<SelectListItem>();
                foreach (var item in _context.productTypes)
                    productTypes.Add(new SelectListItem { Text = item.Name, Value = item.Id.ToString() });

                ViewData["productTypes"] = productTypes;

                if (!ModelState.IsValid) return View(product);

                if (product.MainImage == null)
                {
                    ModelState.AddModelError("MainImage", "Əsas şəkil boş ola bilməz");
                    return View(product);
                }

                if (!product.MainImage.ContentType.Contains("image/"))
                {
                    ModelState.AddModelError("MainImage", "Əsas şəklin formatı düzgün deyil");
                    return View(product);
                }

                if (product.ProductImagesFile != null)
                {
                    foreach (var item in product.ProductImagesFile)
                    {
                        if (!item.ContentType.Contains("image/"))
                        {
                            ModelState.AddModelError("ProductImagesFile", "Digər şəkillərin formatı düzgün deyil");
                            return View(product);
                        }
                    }
                }

                product.DiscountPercent ??= 0;
                product.Date = DateTime.Now;
                Product trendingProduct = _context.ProductCategories.Where(c => c.Id == product.ProductCategoryId).Include(c => c.Products)
                                                                    .FirstOrDefault().Products.Where(p => p.IsTrendingProduct).FirstOrDefault();
                List<Product> bestSellerProducts = _context.products.Where(p => p.IsBestSeller).OrderByDescending(p => p.Date).ToList();

                if (trendingProduct != null && product.IsTrendingProduct) trendingProduct.IsTrendingProduct = false;

                if (bestSellerProducts.Count() == 6 && product.IsBestSeller) bestSellerProducts.LastOrDefault().IsBestSeller = false;
                await _context.products.AddAsync(product);
                product.MainImageUrl = await product.MainImage.SavePhotoAsync(_env.WebRootPath, "products");
                if (product.ProductImagesFile != null)
                {
                    foreach (var item in product.ProductImagesFile)
                    {
                        ProductImage productImage = new ProductImage
                        {
                            ImageUrl = await item.SavePhotoAsync(_env.WebRootPath, "products"),
                            Product = product
                        };
                        await _context.AddAsync(productImage);
                    }
                }

                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }

            return Redirect("/admin/account");
        }

        public async Task<IActionResult> Update(int? id)
        {
            if (User.Identity.IsAuthenticated && User.IsInRole("admin"))
            {
                if (id == null || await _context.products.FindAsync(id) == null) return NotFound();

                List<SelectListItem> productCategories = new List<SelectListItem>();
                foreach (var item in _context.ProductCategories)
                    productCategories.Add(new SelectListItem { Text = item.Name, Value = item.Id.ToString() });

                ViewData["productCategories"] = productCategories;

                List<SelectListItem> productTypes = new List<SelectListItem>();
                foreach (var item in _context.productTypes)
                    productTypes.Add(new SelectListItem { Text = item.Name, Value = item.Id.ToString() });

                ViewData["productTypes"] = productTypes;

                Product product = _context.products.Where(p => p.Id == id).Include(p => p.ProductImages).FirstOrDefault();
                return View(product);
            }
            return Redirect("/admin/account");
        }

        [HttpPost, ValidateAntiForgeryToken]
        public async Task<IActionResult> Update(Product product)
        {
            if (User.Identity.IsAuthenticated && User.IsInRole("admin"))
            {
                List<SelectListItem> productCategories = new List<SelectListItem>();
                foreach (var item in _context.ProductCategories)
                    productCategories.Add(new SelectListItem { Text = item.Name, Value = item.Id.ToString() });

                ViewData["productCategories"] = productCategories;

                List<SelectListItem> productTypes = new List<SelectListItem>();
                foreach (var item in _context.productTypes)
                    productTypes.Add(new SelectListItem { Text = item.Name, Value = item.Id.ToString() });

                ViewData["productTypes"] = productTypes;

                if (!ModelState.IsValid) return View(product);

                if(product.ProductImagesFile != null)
                {
                    foreach (var item in product.ProductImagesFile)
                    {
                        if (!item.ContentType.Contains("image/"))
                        {
                            ModelState.AddModelError("ProductImagesFile", "Digər şəkillərin formatı düzgün deyil");
                            return View(product);
                        }
                    }
                }

                Product productFromDb = await _context.products.FindAsync(product.Id);

                if (product.MainImage != null)
                {
                    if (!product.MainImage.ContentType.Contains("image/"))
                    {
                        ModelState.AddModelError("MainImage", "Əsas şəklin formatı düzgün deyil");
                        return View(product);
                    }
                    RemovePhoto(_env.WebRootPath, productFromDb.MainImageUrl);
                    productFromDb.MainImageUrl = await product.MainImage.SavePhotoAsync(_env.WebRootPath, "products");
                }

                if (product.ProductImagesFile != null)
                {
                    foreach (var item in product.ProductImagesFile)
                    {
                        ProductImage productImage = new ProductImage
                        {
                            ImageUrl = await item.SavePhotoAsync(_env.WebRootPath, "products"),
                            ProductId = productFromDb.Id
                        };
                        await _context.AddAsync(productImage);
                    }
                }
                Product trendingProduct = _context.ProductCategories.Where(c => c.Id == product.ProductCategoryId).Include(c => c.Products)
                                                                    .FirstOrDefault().Products.Where(p => p.IsTrendingProduct).FirstOrDefault();
                List<Product> bestSellerProducts = _context.products.Where(p => p.IsBestSeller).OrderByDescending(p => p.Date).ToList();

                if (trendingProduct != null && product.IsTrendingProduct) trendingProduct.IsTrendingProduct = false;

                if (bestSellerProducts.Count() == 6 && product.IsBestSeller) bestSellerProducts.LastOrDefault().IsBestSeller = false;

                productFromDb.Description = product.Description;
                productFromDb.DiscountPercent = product.DiscountPercent;
                productFromDb.IsBestSeller = product.IsBestSeller;
                productFromDb.IsNew = product.IsNew;
                productFromDb.IsTrendingProduct = product.IsTrendingProduct;
                productFromDb.Name = product.Name;
                productFromDb.Price = product.Price;
                productFromDb.ProductCategoryId = product.ProductCategoryId;
                productFromDb.ProductTypeId = product.ProductTypeId;
                productFromDb.Date = DateTime.Now;
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return Redirect("/admin/account");
        }
    }
}
