using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.Rendering;
using MVCCore13GenericRepository.Models;
using MVCCore13GenericRepository.Repositories;
using MVCCore13GenericRepository.Services.Abstracts;
using MVCCore13GenericRepository.ViewModels.Eylemler;

namespace MVCCore13GenericRepository.Services.Concretes
{
    public class EylemService : IEylemService
    {
        private readonly EylemRepository eylemRepository;
        private readonly KategoriRepository kategoriRepository;
        private readonly IUyeService uyeService;
        private readonly IMapper mapper;
        public EylemService(EylemRepository _eylemRepository, KategoriRepository _kategoriRepository, IUyeService _uyeService, IMapper _mapper)
        {
            eylemRepository = _eylemRepository;
            kategoriRepository = _kategoriRepository;
            uyeService = _uyeService;
            mapper = _mapper;
        }
        public ICollection<EylemListeleVM> IliskiliListele()
        {
            var eylemler = eylemRepository.ListeleEager().ToList();
            return mapper.Map<ICollection<EylemListeleVM>>(eylemler);
        }

        public EylemDetayVM IliskiliDetay(int id)
        {
            var eylem = eylemRepository.DetayEager(id);
            if (eylem != null)
            {
                return mapper.Map<EylemDetayVM>(eylem);
            }
            else
            {
                return null;
            }
        }

        public bool Ekle(EylemEklemeVM eylem, string username)
        {            
            var eylemEntity = mapper.Map<Eylem>(eylem);
            eylemEntity.EkleyenUye = uyeService.GetUserId(username);
            return eylemRepository.Ekle(eylemEntity);
        }

        public EylemEklemeFormVM EklemeFormOlustur()
        {
            EylemEklemeFormVM frm = new EylemEklemeFormVM
            {
                Kategoriler = SelectListOlustur(),
                Durumlar = new SelectList(Enum.GetNames(typeof(Durum)), "Durum"),
            };

            return frm;
        }
        public EylemGuncelleFormVM GuncellemeFormOlustur(int id)
        {
            var eylem = eylemRepository.DetayEager(id);
            EylemGuncelleFormVM frm = new EylemGuncelleFormVM
            {
                Eylem = mapper.Map<EylemGuncelleVM>(eylem),
                Kategoriler = SelectListOlustur(),
                Durumlar = new SelectList(Enum.GetNames(typeof(Durum)), "Durum")
            };

            return frm;
        }

        public SelectList SelectListOlustur()
        {
            SelectList selectList = new SelectList(kategoriRepository.Listele(), "KategoriId", "KategoriAd");
            return selectList;
        }

        public void Sil(int id)
        {
            var eylem = eylemRepository.DetayEager(id);
            if (eylem != null)
            {
                eylemRepository.Sil(id);
            }
        }

        public void Guncelle(EylemGuncelleVM eylem)
        {
            var guncelEylem = eylemRepository.DetayEager(eylem.EylemId);
            if (guncelEylem != null)
            {
                mapper.Map(eylem, guncelEylem);
                eylemRepository.Guncelle(guncelEylem);
            }
        }
    }
}
