using AutoMapper;
using Microsoft.AspNetCore.Identity;
using MVCCore13GenericRepository.Data;
using MVCCore13GenericRepository.Models;
using MVCCore13GenericRepository.Repositories;
using MVCCore13GenericRepository.Services.Abstracts;
using MVCCore13GenericRepository.ViewModels.Auth;
using MVCCore13GenericRepository.ViewModels.Eylemler;
using System.Threading.Tasks;

namespace MVCCore13GenericRepository.Services.Concretes
{
    public class UyeService : IUyeService
    {
        private readonly UserManager<Uye> userManager; // old için login vs için repoya gerek yok
        private readonly SignInManager<Uye> signInManager;
        private readonly IMapper mapper;
        public UyeService(UserManager<Uye> _userManager, SignInManager<Uye> _signInManager, IMapper _mapper)
        {
            userManager = _userManager;
            signInManager = _signInManager;
            mapper = _mapper;
        }

        public async Task<bool> Login(LoginVM vm)
        {
            var uye = await userManager.FindByNameAsync(vm.Username);
            if (uye != null)
            {
                var result = await signInManager.PasswordSignInAsync(uye, vm.Password, false, false);
                if (!result.Succeeded)
                {
                    // throw new Exception("Şifre yanlış...");
                    return false;
                }
            }
            else
            {
                // throw new Exception("Kullanıcı bulunamadı...");
                return false;
            }
            return true;
        }

        public async Task Logout()
        {
            await signInManager.SignOutAsync();
        }

        public async Task<bool> Register(RegisterVM vm)
        {
            var uye = mapper.Map<Uye>(vm);

            var result = await userManager.CreateAsync(uye, vm.Password);
            if (!result.Succeeded)
            {
                // throw new Exception("Kullanıcı oluşturulamadı...");
                return false;
            }

            return true;
        }

        public string GetUserId(string username)
        {
            var user = userManager.Users.FirstOrDefault(x => x.UserName == username);
            return user.Id;
        }

    }
}
