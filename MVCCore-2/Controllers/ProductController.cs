using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MVCCore_2.Contexts;
using MVCCore_2.Models;
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

        public IActionResult AddProduct()
        {
            // category isimlerinin gönderilme işlemini burada yapıyoruz. model ile gönderemeyiz bu actionda gönderilen bir product modeli var zaten. diğer yöntemleri kullanacağız.
            // ViewBag.Categories = dbContext.Categories.ToList();
            ViewBag.Categories = new SelectList(dbContext.Categories, "CategoryId", "Name");
            return View();
        }

        [HttpPost]
        public IActionResult AddProduct(Product product, IFormFile imageName)
        {
            // kullanıcıdan gelen dosyayı bir yere kaydetmemiz gerek. nereye kaydederiz? wwwroota.
            // daha sonra dbde ürün tablomuzda bu resmi gösterebilmek için resmin yolunu tutmamız gerek. yani burası için resim adı. çünkü zaten bu proje dosyası içinde tutuluyor???

            // adımlar:
            // 1- dosyayı sunucuya yükle.
            // 2- dosya adını, ürün modeline yaz (id nin guid olarak tutulması lazım)

            // "wwwroot" klasörünün altında "images" adında bir klasör oluşturacağız. bu klasörün içinde resim dosyalarını tutacağız.

            string guid = Guid.NewGuid().ToString();
            string filePath = "wwwroot/images/" + guid + "_" + imageName.FileName; // çok fazla resim olduğunda db de her seferinde bu path adı geçecek. gerek yok sadece dosya adı yeterli. bu da sıkıntı. aynı isimli dosya yüklenebilir farklı kullanıcılar tarafından. bu sefer sonradan eklenen önceki resmin üstüne yazar. veri kaybı olur. bu sebeple guid tanımlamak en iyisidir.
            FileStream fileStream = new FileStream(filePath, FileMode.Create); // fileMode.Create yeni oluşturulması gerektiğini söylemiş oluyoruz.
            // imageName.CopyTo(new FileStream(Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "images", imageName.FileName), FileMode.Create));
            imageName.CopyTo(fileStream);
            fileStream.Close();

            product.ImageUrl = guid + "_" + imageName.FileName; // dbdeki resim yolunu tutan property

            dbContext.Products.Add(product);
            dbContext.SaveChanges();



            return RedirectToAction("GetProductList");
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
    }
}
