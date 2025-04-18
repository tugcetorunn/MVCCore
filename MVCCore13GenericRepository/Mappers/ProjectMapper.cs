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
        }
    }
}
