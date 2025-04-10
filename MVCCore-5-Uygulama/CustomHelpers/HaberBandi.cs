using Microsoft.AspNetCore.Razor.TagHelpers;

namespace MVCCore_5_Uygulama.CustomHelpers
{
    [HtmlTargetElement("Yaz")] // bunu yazınca artık <Yaz>...</Yaz> şeklinde kullanılabilir haber-bandi olarak gelmeyecek.
    public class HaberBandi : TagHelper
    {
        public string EkrandaGozukecekMesaj { get; set; }
        public YaziYonu AspYaziYonu { get; set; }
        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            base.Process(context, output);

            output.TagName = "marquee"; // <marquee></marquee>
            output.Attributes.Add("direction", AspYaziYonu);
            output.Content.AppendHtml(EkrandaGozukecekMesaj); // <marquee>mesaj</marquee>
        }
    }
}
