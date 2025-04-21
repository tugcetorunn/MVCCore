using AutoMapper;
using Microsoft.AspNetCore.Identity;
using MVCCore14ToDoDers.Models;
using MVCCore14ToDoDers.ViewModels;
using MVCCore14ToDoDers.ViewModels.Auth;
using MVCCore14ToDoDers.ViewModels.Eylemler;

namespace MVCCore14ToDoDers.Mappers
{
    public class ToDoMapper : Profile
    {
        public ToDoMapper()
        {
            CreateMap<IdentityUser, RegisterVM>().ReverseMap();
            CreateMap<Eylem, EylemEkleVM>().ReverseMap();
            CreateMap<Eylem, EylemListeleVM>()
                .ForMember(dest => dest.KategoriAdi, opt => opt.MapFrom(src => src.Kategori.KategoriAdi)).ReverseMap();
            CreateMap<Kategori, KategoriListeleVM>().ReverseMap();
        }
    }
}
