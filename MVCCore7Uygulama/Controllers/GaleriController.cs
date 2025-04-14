using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using MVCCore7Uygulama.Contexts;
using MVCCore7Uygulama.CustomFilters;
using MVCCore7Uygulama.Models;
using MVCCore7Uygulama.ViewModels.Araclar;
using System.Security.Cryptography;
using System.Text;

namespace MVCCore7Uygulama.Controllers
{
    public class GaleriController(GaleriDbContext _context) : Controller
    {
        private readonly GaleriDbContext context = _context; // primary constructor
        public IActionResult Index()
        {
            var aracListesi = context.Araclar.Select(x => new AracGosterVM
            {
                Uye = x.Uye.AdSoyad,
                Plaka = x.Plaka,
                Aciklama = x.Aciklama,
                Fiyat = x.Fiyat,
                Marka = x.Marka.MarkaAdi,
                Model = x.Model,
                Renk = x.Renk
            }).ToList();

            return View(aracListesi);

        }

        [SessionVarMi]
        public IActionResult AracEkle()
        {
            // session kontrolü (şuan sadece araç ekleme fonk var fakat eklenecek başka işlemler araç güncelleme, silme, marka ekleme vs de olduğunda her actionda sürekli session kontrol edilmemeli bunu için identity kütüphanesinin authorize işlevindeki gibi attribute ile kontrol sağlanması best practice dir.)

            //var uyeId = HttpContext.Session.GetInt32("UyeId");
            //var uye = context.Uyeler.Find(uyeId);
            //string uyeAdi = uye?.AdSoyad;

            //if (uyeId == null)
            //{
            //    return RedirectToAction("GirisYap", "Uye");    
            //} // attribute ile yapıyoruz.

            AracEkleFormVM form = new AracEkleFormVM()
            {
                Markalar = new SelectList(context.Markalar.ToList(), "MarkaId", "MarkaAdi"), // tolist şart değil
                                                                                             // UyeAdi = uyeAdi,
            };

            return View(form);

        }

        [HttpPost]
        public IActionResult AracEkle(AracEkleVM arac) // arac içindeki değerler null geliyorsa bunun sebebi formvm de kullanılan araceklevm tipindeki değişkenin adı ile parametredeki ad aynı değildir.
        {
            // valid kontrolü şuan db tarafına geçerken conf lar üzerinden yapılıyor. model state çalışması için attirbute eklenecek.
            if (ModelState.IsValid)
            {
                Arac yeniArac = new Arac
                {
                    UyeId = HttpContext.Session.GetInt32("UyeId").Value,
                    Plaka = arac.Plaka,
                    Aciklama = arac.Aciklama,
                    Fiyat = arac.Fiyat,
                    MarkaId = arac.MarkaId,
                    Model = arac.Model,
                    Renk = arac.Renk
                };

                context.Araclar.Add(yeniArac);
                context.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(arac);
        }

        public string SHA256Hash(string password)
        {
            string source = password;
            using (SHA256 sha1Hash = SHA256.Create())
            {
                byte[] sourceBytes = Encoding.UTF8.GetBytes(source);
                byte[] hashBytes = sha1Hash.ComputeHash(sourceBytes);
                string hash = BitConverter.ToString(hashBytes).Replace("-", String.Empty);
                return hash;
            }
        }

        public string EncryptString(string plainText)
        {
            var key = "b14ca5898a4e4133bbce2ea2315a1916";

            byte[] iv = new byte[16];
            byte[] array;

            using (Aes aes = Aes.Create())
            {
                aes.Key = Encoding.UTF8.GetBytes(key);
                aes.IV = iv;

                ICryptoTransform encryptor = aes.CreateEncryptor(aes.Key, aes.IV);

                using (MemoryStream memoryStream = new MemoryStream())
                {
                    using (CryptoStream cryptoStream = new CryptoStream((Stream)memoryStream, encryptor, CryptoStreamMode.Write))
                    {
                        using (StreamWriter streamWriter = new StreamWriter((Stream)cryptoStream))
                        {
                            streamWriter.Write(plainText);
                        }

                        array = memoryStream.ToArray();
                    }
                }
            }

            return Convert.ToBase64String(array);
        }

        public string DecryptString(string cipherText)
        {
            var key = "b14ca5898a4e4133bbce2ea2315a1916";

            byte[] iv = new byte[16];
            byte[] buffer = Convert.FromBase64String(cipherText);

            using (Aes aes = Aes.Create())
            {
                aes.Key = Encoding.UTF8.GetBytes(key);
                aes.IV = iv;
                ICryptoTransform decryptor = aes.CreateDecryptor(aes.Key, aes.IV);

                using (MemoryStream memoryStream = new MemoryStream(buffer))
                {
                    using (CryptoStream cryptoStream = new CryptoStream((Stream)memoryStream, decryptor, CryptoStreamMode.Read))
                    {
                        using (StreamReader streamReader = new StreamReader((Stream)cryptoStream))
                        {
                            return streamReader.ReadToEnd();
                        }
                    }
                }
            }
        }

    }
}
