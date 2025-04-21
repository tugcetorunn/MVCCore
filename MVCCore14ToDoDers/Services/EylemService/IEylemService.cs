using MVCCore14ToDoDers.ViewModels.Eylemler;

namespace MVCCore14ToDoDers.Services.EylemService
{
    public interface IEylemService
    {
        void EylemEkle(EylemEkleVM eylem);
        List<EylemListeleVM> TumEylemler(string id);
    }
}
