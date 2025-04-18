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
            CreateMap<Kitap, KitapListeleVM>()
                .ForMember(dest => dest.Kategori, opt => opt.MapFrom(src => src.Kategori.KategoriAdi)) // neden yaptık -> bunu yapmadığımızda MVCCore12GenericRepository.Models.Yazar	nav proplar böyle görünüyor Kitap entity'sinde Yazar, Kategori, Yayinevi komple nesneler, ama ViewModel’de sadece string olarak adlarını istiyoruz.
                .ForMember(dest => dest.Yayinevi, opt => opt.MapFrom(src => src.Yayinevi.YayineviAdi))
                .ForMember(dest => dest.Yazar, opt => opt.MapFrom(src => src.Yazar.YazarAdSoyad))
                .ReverseMap(); // reverseMap ten sonra formember kullanırsak dest kitaplistelevm opt kitap olmuş oluyor... dikkat.
            CreateMap<Kitap, KitapDetayVM>()
                .ForMember(dest => dest.Kategori, opt => opt.MapFrom(src => src.Kategori.KategoriAdi))
                .ForMember(dest => dest.Yazar, opt => opt.MapFrom(src => src.Yazar.YazarAdSoyad))
                .ForMember(dest => dest.Yayinevi, opt => opt.MapFrom(src => src.Yayinevi.YayineviAdi))
                .ReverseMap();
            CreateMap<Kitap, KitapGuncelleVM>().ReverseMap();
            CreateMap<KitapDetayVM, KitapGuncelleVM>().ReverseMap();

        }
    }
}
