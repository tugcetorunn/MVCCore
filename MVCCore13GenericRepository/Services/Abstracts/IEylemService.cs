using MVCCore13GenericRepository.Models;
using MVCCore13GenericRepository.ViewModels.Auth;
using MVCCore13GenericRepository.ViewModels.Eylemler;

namespace MVCCore13GenericRepository.Services.Abstracts
{
    public interface IEylemService
    {
        ICollection<EylemListeleVM> IliskiliListele();
        EylemDetayVM IliskiliDetay(int id);
        bool Ekle(EylemEklemeVM eylem, string username);
        EylemEklemeFormVM EklemeFormOlustur();
        EylemGuncelleFormVM GuncellemeFormOlustur(int id);
        void Sil(int id);
        void Guncelle(EylemGuncelleVM eylem);

    }
}
