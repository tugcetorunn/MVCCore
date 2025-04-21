using MVCCore14ToDoDers.Models;
using MVCCore14ToDoDers.ViewModels;

namespace MVCCore14ToDoDers.Services.KategoriService
{
    public interface IKategoriService
    {
        List<KategoriListeleVM> TumKategoriler();
    }
}