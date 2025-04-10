using Microsoft.AspNetCore.Html;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace MVCCore_5_Uygulama.CustomHelpers
{
    public static class Genislet
    {
        public static IHtmlContent HaberBandi(this IHtmlHelper content, string mesaj)
        {
            // "<div class='alert alert-primary' role='alert'>Bu bir haber bandıdır.</div>"
            string htmlString = "<marquee>" + mesaj + "<marquee>";
            return new HtmlString(htmlString);
        }

        public static IHtmlContent ListeGetir(this IHtmlHelper content, ICollection<object> liste)
        {
            string htmlString = "<ul>";

            foreach (var item in liste)
            {
                htmlString += "<li>" + item + "</li>";
            }

            htmlString += "</ul>";

            return new HtmlString(htmlString);
        }
    }
}
