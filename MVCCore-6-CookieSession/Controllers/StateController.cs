using Microsoft.AspNetCore.Mvc;

namespace MVCCore_6_CookieSession.Controllers
{
    public class StateController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }


        public IActionResult Detay()
        {
            // queryString üzerinden gelen verileri request nesnesi ile alıp işleyebiliriz.
            string strQuery = Request.QueryString.Value;
            // Request.Query["id"];
            return Content("Gelen değer :" + strQuery);
        }

        public IActionResult CerezOlustur()
        {
            // bu şekilde kullanımda oluşturulan çerez o session için geçerlidir.
            // 1. kullanım
            // Response.Cookies.Append("cerezos", "Cerez icerisinde tutulacak veri"); 
            // 2. kullanım (yaşam süresi vererek)
            CookieOptions cookieOptions = new CookieOptions();
            cookieOptions.Expires = DateTime.Now.AddDays(15);
            Response.Cookies.Append("cerezos", "[Sureli]Cerez icerisinde tutulacak veri", cookieOptions);
            //Response.Cookies.Append("cerezos", "[Sureli]Cerez icerisinde tutulacak veri", new Microsoft.AspNetCore.Http.CookieOptions()
            //{
            //    Expires = DateTimeOffset.Now.AddDays(1), // 1 gün geçerli
            //    HttpOnly = true, // sadece http üzerinden erişilebilir
            //    Secure = true, // sadece https üzerinden erişilebilir
            //    SameSite = Microsoft.AspNetCore.Http.SameSiteMode.Strict // sadece aynı site üzerinden erişilebilir
            //});
            return Content("Cerez olustur...");
            // f12 - application - cookies - cerezosu görebiliriz. browser ı kapatıp tekrar açtığımızda programı çalıştırınca actionı çağırmadan f12 app sekmesini tekrar açtığımızda cerez silinmiş olur. sekme kapatarak cerez silinmez. ayrıca tüm browser pencerelerini kapatmak gerekir silinmesi için. cerezin süresi dolduğunda da silinir
        }

        public IActionResult CerezdenOku()
        {
            // cerezokuma
            // çerez yazarken response, okurken request.
            string cerez = Request.Cookies["cerezos"];
            return Content("Cerez icerigi : " + cerez);
        }

        public IActionResult SessionOlustur()
        {
            HttpContext.Session.SetInt32("Id", 999);
            return Content("Session olusturuldu");
        }

        public IActionResult SessiondanOku()
        {
            return Content("Session değeri : " + HttpContext.Session.GetInt32("Id")); // db den diğer bilgilerine ulaşmak için session üzerinde id değerini tutarız.
            // HttpContext.Session.Clear(); // session silme
        }
    }
}
