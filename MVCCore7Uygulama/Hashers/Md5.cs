using System.Security.Cryptography;
using System.Text;

namespace MVCCore7Uygulama.Hashers
{
    public static class Md5
    {
        public static string Hash(string input)
        {
            using (var md5 = MD5.Create()) // factory pattern (ihtiyacımız olan sınıfı, sınıf oluşturuyor.)
            {
                byte[] hashBytes = md5.ComputeHash(Encoding.UTF8.GetBytes(input)); // gelen inputu önce byte[] e daha sonra bu arrayi hashlenmiş byte[] e çeviriyoruz.

                // Convert the byte array to a hexadecimal string
                //StringBuilder sb = new StringBuilder();
                //for (int i = 0; i < hashBytes.Length; i++)
                //{
                //    sb.Append(hashBytes[i].ToString("X2"));
                //}
                //return sb.ToString();

                string strHashedPassword = "";
                foreach (byte key in hashBytes)
                {
                    strHashedPassword += key.ToString("X2");
                }

                return strHashedPassword;
            }
        }
    }
}
