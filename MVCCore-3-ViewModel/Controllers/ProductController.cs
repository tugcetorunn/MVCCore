using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MVCCore_3_ViewModel.Models;
using MVCCore_3_ViewModel.Utilities;
using MVCCore_3_ViewModel.ViewModels;

namespace MVCCore_3_ViewModel.Controllers
{
    public class ProductController : Controller
    {
        private readonly SimpleMarketDbContext context;
        public ProductController(SimpleMarketDbContext _context)
        {
            context = _context;
        }
        public IActionResult Index()
        {
            var products = context.Products.Select(x => new GetProductsVM() // select kendi içerisinde include un yaptığı join işlemini yapıyor.
            {
                ProductId = x.ProductId, // göndermezsek viewdata title kodunda null hatası veriyor.
                ProductName = x.ProductName,
                Price = x.Price,
                ImageUrl = x.ImageUrl,
                CategoryName = x.Category.Name
            }).ToList();

            return View(products);
        }

        public IActionResult Create()
        {
            CreateProductFormVM vm = new CreateProductFormVM();
            vm.Categories = new SelectList(context.Categories.ToList(), "CategoryId", "Name");
            return View(vm);
        }

        [HttpPost]
        public IActionResult Create(CreateProductVM product) // product parametre ismi formda yani CreateProductFormVM classında tanımlandığı yerde kullanılan prop ismiyle aynı olmalıdır. yoksa göremez null hatası
        {
            Product newProduct = new Product()
            {
                ProductName = product.ProductName,
                Price = product.Price,
                Description = product.Description,
                CategoryId = product.CategoryId
            };

            newProduct.ImageUrl = FileOperations.UploadImage(product.ImageUrl);
            context.Products.Add(newProduct);
            context.SaveChanges();
            return RedirectToAction("Index");
        }

        public IActionResult Detail(int id)
        {
            var product = context.Products.Select(x => new GetProductVM()
            {
                ProductId = x.ProductId,
                ProductName = x.ProductName,
                Price = x.Price,
                Description = x.Description,
                ImageUrl = x.ImageUrl,
                CategoryName = x.Category.Name
            }).FirstOrDefault(x => x.ProductId == id);

            return View(product);
        }

        public IActionResult Edit(int id)
        {
            var product = context.Products.FirstOrDefault(x => x.ProductId == id);
            UpdateProductFormVM vM = new UpdateProductFormVM() { 
                Product = new UpdateProductVM { 
                    ProductId = id,
                    CategoryId = product.CategoryId,
                    Description = product.Description,
                    ImageUrl = product.ImageUrl,
                    Price = product.Price,
                    ProductName = product.ProductName 
                }
            }; // select, where ile de yapılabilir.

            vM.Categories = new SelectList(context.Categories.ToList(), "CategoryId", "Name");
            return View(vM);
        }

        [HttpPost]
        public IActionResult Edit(UpdateProductVM product)
        {
            var oldProduct = context.Products.Find(product.ProductId);

            oldProduct.ProductName = product.ProductName;
            oldProduct.Price = product.Price;
            oldProduct.Description = product.Description;
            oldProduct.CategoryId = product.CategoryId;

            if (product.ImageFile != null)
                oldProduct.ImageUrl = FileOperations.UploadImage(product.ImageFile);

            context.SaveChanges(); // image null old hata veriyor. düzeldi. 2. projede bu hata devam ediyor bakılacak.

            return RedirectToAction("Index");
        }

        [HttpPost]
        public IActionResult Delete(int id)
        {
            var product = context.Products.FirstOrDefault(x => x.ProductId == id);

            context.Products.Remove(product);
            context.SaveChanges();

            return RedirectToAction("Index");
        }
    }
}
