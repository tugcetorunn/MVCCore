using AutoMapper;
using MVCCore14ToDoDers.Models;
using MVCCore14ToDoDers.Repositories;
using MVCCore14ToDoDers.ViewModels.Eylemler;

namespace MVCCore14ToDoDers.Services.EylemService
{
    public class EylemService : IEylemService
    {
        private readonly EylemRepository eylemRepository;
        private readonly IMapper mapper;
        public EylemService(EylemRepository _eylemRepository, IMapper _mapper)
        {
            eylemRepository = _eylemRepository;
            mapper = _mapper;
        }
        public void EylemEkle(EylemEkleVM eylem)
        {
            Eylem yeni = new Eylem();
            mapper.Map(eylem, yeni);
            yeni.OlusturmaTarihi = DateTime.Now;
            yeni.TamamlandiMi = false;
            eylemRepository.Ekle(yeni);
        }

        public List<EylemListeleVM> TumEylemler(string id)
        {
            return eylemRepository.Listele(id); // kullanıcının eylemleri gelecek
        }
    }
}
