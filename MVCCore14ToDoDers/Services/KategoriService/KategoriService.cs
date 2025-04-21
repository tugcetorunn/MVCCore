using AutoMapper;
using MVCCore14ToDoDers.Repositories;
using MVCCore14ToDoDers.ViewModels;

namespace MVCCore14ToDoDers.Services.KategoriService
{
    public class KategoriService : IKategoriService
    {
        private readonly KategoriRepository kategoriRepository;
        private readonly IMapper mapper;
        public List<KategoriListeleVM> TumKategoriler()
        {
            var kategoriler = kategoriRepository.Listele();
            var kategoriListeleVM = mapper.Map<List<KategoriListeleVM>>(kategoriler);
            return kategoriListeleVM;
        }
    }
}
