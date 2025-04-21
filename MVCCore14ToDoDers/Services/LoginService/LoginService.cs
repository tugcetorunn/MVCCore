using AutoMapper;
using Microsoft.AspNetCore.Identity;
using MVCCore14ToDoDers.ViewModels.Auth;
using System.Security.Claims;

namespace MVCCore14ToDoDers.Services.LoginService
{
    public class LoginService : ILoginService
    {
        private readonly UserManager<IdentityUser> userManager; // signinmanager ı burada bağladığımızda projeyi webe bağımlı hale getirmiş oluruz. çünkü signin bilgileri cookie de session da tutulur. bunlar da web te bulunur. console da masaüstü uyg da yoktur.bu sebeplerden dolayı logout u da burada yapmıyoruz.
        private readonly SignInManager<IdentityUser> signInManager;
        private readonly IMapper mapper;

        public LoginService(SignInManager<IdentityUser> _signInManager, UserManager<IdentityUser> _userManager, IMapper _mapper)
        {
            signInManager = _signInManager;
            userManager = _userManager;
            mapper = _mapper;
        }

        public string GetUserId(ClaimsPrincipal claim)
        {
            return userManager.GetUserId(claim);
        }

        public IdentityUser Login(LoginVM loginVM)
        {
            //userManager.FindByNameAsync(loginVM.Username).ContinueWith(async task =>
            //{
            //    var user = await task;
            //    if (user != null)
            //    {
            //        var result = await signInManager.PasswordSignInAsync(user, loginVM.Password, false, false);
            //        if (!result.Succeeded)
            //        {
            //            // throw new Exception("Şifre yanlış...");
            //            return null;
            //        }
            //    }
            //    else
            //    {
            //        // throw new Exception("Kullanıcı bulunamadı...");
            //        return null;
            //    }
            //});

            var user = userManager.FindByNameAsync(loginVM.Username).Result;
            if (user != null)
            {
                var result = userManager.CheckPasswordAsync(user, loginVM.Password).Result;
                if (result)
                {
                    return user;
                }

                return null;
            }

            return null;

        }

        public void Register(RegisterVM registerVM)
        {
            IdentityUser user = new IdentityUser();
            mapper.Map(registerVM, user);
            var result = userManager.CreateAsync(user, registerVM.Password).Result;
        }
    }
}
