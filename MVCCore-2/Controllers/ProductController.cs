using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MVCCore_2.Contexts;
using MVCCore_2.Models;
using MVCCore_2.Utilities;
using NuGet.Common;

namespace MVCCore_2.Controllers
{
    public class ProductController : Controller
    {
        // eski usül
        // MarketDbContext dbContext = new MarketDbContext();
        // dependency injection (constructor injection)
        private readonly MarketDbContext dbContext;
        public ProductController(MarketDbContext _dbContext)
        {
            dbContext = _dbContext;
        }

        public IActionResult GetCategoryList()
        {
            // tüm kategorileri ekranda sırasız liste olarak göster
            var categories = dbContext.Categories.ToList();
            return View(categories);
        }

        public IActionResult GetProductList()
        {
            var products = dbContext.Products.Include(x => x.Category).ToList();
            return View(products);
        }

        public IActionResult AddOrEditProduct(int id = 0)
        {
            // category isimlerinin gönderilme işlemini burada yapıyoruz. model ile gönderemeyiz bu actionda gönderilen bir product modeli var zaten. diğer yöntemleri kullanacağız.
            // ViewBag.Categories = dbContext.Categories.ToList();
            var product = dbContext.Products.Find(id);
            ViewBag.Categories = new SelectList(dbContext.Categories, "CategoryId", "Name");
            return View(product);
        }

        [HttpPost]
        public IActionResult AddOrEditProduct(Product product, IFormFile imageName)
        {
            // kullanıcıdan gelen dosyayı bir yere kaydetmemiz gerek. nereye kaydederiz? wwwroota.
            // daha sonra dbde ürün tablomuzda bu resmi gösterebilmek için resmin yolunu tutmamız gerek. yani burası için resim adı. çünkü zaten bu proje dosyası içinde tutuluyor???

            // adımlar:
            // 1- dosyayı sunucuya yükle.
            // 2- dosya adını, ürün modeline yaz (id nin guid olarak tutulması lazım)

            // "wwwroot" klasörünün altında "images" adında bir klasör oluşturacağız. bu klasörün içinde resim dosyalarını tutacağız.

            if (imageName == null || imageName.Length == 0)
            {
                ModelState.AddModelError("ImageUrl", "Lütfen bir resim dosyası seçin.");
                ViewBag.Categories = new SelectList(dbContext.Categories, "CategoryId", "Name");
                return View(product);
            }

            string guid = Guid.NewGuid().ToString();
            string filePath = "wwwroot/images/" + guid + "_" + imageName.FileName; // çok fazla resim olduğunda db de her seferinde bu path adı geçecek. gerek yok sadece dosya adı yeterli. bu da sıkıntı. aynı isimli dosya yüklenebilir farklı kullanıcılar tarafından. bu sefer sonradan eklenen önceki resmin üstüne yazar. veri kaybı olur. bu sebeple guid tanımlamak en iyisidir.
            FileStream fileStream = new FileStream(filePath, FileMode.Create); // fileMode.Create yeni oluşturulması gerektiğini söylemiş oluyoruz.
            // imageName.CopyTo(new FileStream(Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "images", imageName.FileName), FileMode.Create));
            imageName.CopyTo(fileStream);
            fileStream.Close(); // bunları utility sınıfında yapacağız.

            product.ImageUrl = guid + "_" + imageName.FileName; // dbdeki resim yolunu tutan property

            //if (ModelState.IsValid)
            //{
                if (product.ProductId == 0)
                {
                    dbContext.Products.Add(product);
                }
                else
                {
                    dbContext.Update(product);
                    // dbContext.Entry(product).State = EntityState.Modified;
                }
                dbContext.SaveChanges();
                return RedirectToAction("GetProductList");
            //}

            //return View(product);
        }

        public IActionResult CreateGuid()
        {
            string guid = Guid.NewGuid().ToString();
            return Content(guid);
        }

        public IActionResult GetProductDetail(int id)
        {
            var product = dbContext.Products.Include(x => x.Category).Where(x => x.ProductId == id).FirstOrDefault();
            return View(product);
        }

        //public IActionResult DeleteProduct(int id)
        //{
        //    var product = dbContext.Products.Find(id);
        //    return View(product);
        //}

        [HttpPost]
        public IActionResult DeleteProduct(Product product) // id verirsek üstteki get i yapmamıza gerek yok
        {
            if (product != null)
            {
                dbContext.Products.Remove(product);
                dbContext.SaveChanges();
            }
            return RedirectToAction("GetProductList");
        }

        public IActionResult EditProduct(int id)
        {
            var product = dbContext.Products.Find(id);
            ViewBag.Categories = new SelectList(dbContext.Categories, "CategoryId", "Name");
            return View(product);
        }

        [HttpPost]
        public IActionResult EditProduct(Product product, IFormFile imageName)
        {
            if (imageName != null) // resim değiştiyse
            {
                //ModelState.AddModelError("ImageUrl", "Lütfen bir resim dosyası seçin.");
                //ViewBag.Categories = new SelectList(dbContext.Categories, "CategoryId", "Name");
                //return View(product);

                product.ImageUrl = FileOperations.UploadImage(imageName); // dosyayı yükle
            }

            product.ImageUrl = "";
            dbContext.Products.Update(product);
            dbContext.SaveChanges();
            return RedirectToAction("GetProductList");
        }
    }
}
