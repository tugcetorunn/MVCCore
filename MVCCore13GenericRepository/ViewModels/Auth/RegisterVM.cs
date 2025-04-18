﻿using System.ComponentModel.DataAnnotations;

namespace MVCCore13GenericRepository.ViewModels.Auth
{
    public class RegisterVM
    {
        public string Ad { get; set; }
        public string Soyad { get; set; }
        public string Username { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        [Compare("Password", ErrorMessage = "Şifreler uyuşmuyor!")]
        public string ConfirmPassword { get; set; }
    }
}
