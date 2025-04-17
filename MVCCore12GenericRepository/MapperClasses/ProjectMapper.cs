using AutoMapper;
using MVCCore12GenericRepository.Models;
using MVCCore12GenericRepository.ViewModels.Kitaplar;

namespace MVCCore12GenericRepository.MapperClasses
{
    public class ProjectMapper : Profile
    {
        public ProjectMapper()
        {
            CreateMap<Kitap, KitapEkleVM>().ReverseMap();
        }
    }
}
