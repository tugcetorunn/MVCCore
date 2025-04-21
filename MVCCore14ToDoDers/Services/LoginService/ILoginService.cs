using Microsoft.AspNetCore.Identity;
using MVCCore14ToDoDers.ViewModels.Auth;
using System.Security.Claims;

namespace MVCCore14ToDoDers.Services.LoginService
{
    public interface ILoginService
    {
        void Register(RegisterVM registerVM);
        IdentityUser Login(LoginVM loginVM); // bool olursa kullanıcı var giriş yapto fakat kim olduğunu bilmiyoruz. id bilinmesi lazım. role ü olsaydı rolünün de bilinmesi lazım olurdu. id yi return type verip role ü out ile verebiliriz.
        // string dönüş tipini identity user yaptık çünkü controllerda login yaptırırken signinmanager signinasync metodu identityuser tipinde veri alıyor.
        // void Logout();
        string GetUserId(ClaimsPrincipal claim);
    }
}
