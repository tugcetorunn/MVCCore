using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace MVCCore7Uygulama.CustomFilters
{
    public class SessionVarMi : ActionFilterAttribute
    {
        // onactionexecuted da var, action çalıştırılıp bitince çalışır ?? araştır
        public override void OnActionExecuting(ActionExecutingContext context) // session kontrolü için attribute
        {
            base.OnActionExecuting(context);

            int? uyeId = context.HttpContext.Session.GetInt32("UyeId");

            if (uyeId == null)
            {
                context.Result = new RedirectToActionResult("GirisYap", "Uye", null);
            }
        }
    }
}
