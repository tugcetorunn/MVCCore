using AutoMapper;
using MVCCore13GenericRepository.Models;
using MVCCore13GenericRepository.ViewModels.Auth;
using MVCCore13GenericRepository.ViewModels.Eylemler;

namespace MVCCore13GenericRepository.Mappers
{
    public class ProjectMapper : Profile
    {
        public ProjectMapper()
        {
            CreateMap<Uye, LoginVM>().ReverseMap();
            CreateMap<Uye, RegisterVM>().ReverseMap();
            CreateMap<Eylem, EylemEklemeVM>().ReverseMap();
            CreateMap<Eylem, EylemListeleVM>().ForMember(dest => dest.Kategori, opt => opt.MapFrom(src => src.Kategori.KategoriAd)).ReverseMap();
            CreateMap<Eylem, EylemGuncelleVM>().ForMember(dest => dest.KategoriId, opt => opt.MapFrom(src => src.Kategori.KategoriAd)).ReverseMap();
        }
    }
}
