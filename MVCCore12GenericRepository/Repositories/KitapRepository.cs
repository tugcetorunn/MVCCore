using AutoMapper;
using Microsoft.EntityFrameworkCore;
using MVCCore12GenericRepository.Data;
using MVCCore12GenericRepository.Models;
using MVCCore12GenericRepository.ViewModels.Kitaplar;

namespace MVCCore12GenericRepository.Repositories
{
    public class KitapRepository : BaseRepository<Kitap>
    {
        private readonly IMapper mapper; // automapper ın özel kullanımını(formember, mapfrom) görmek için burada mapper kullandık. nşa da repository içinde böyle yazmamak lazım
        public KitapRepository(SahafDbContext _context, IMapper _mapper) : base(_context)
        {
            mapper = _mapper;
        }

        public KitapDetayVM IliskiliKitapDetay(int id)
        {
            var kitap = table
                .Include(x => x.Yazar)
                .Include(x => x.Kategori)
                .Include(x => x.Yayinevi).FirstOrDefault(x => x.KitapId == id);

            if (kitap != null)
            {
                return mapper.Map<KitapDetayVM>(kitap);
            }
            else
            {
                throw new Exception("Kitap bulunamadı.");
            }
        }

        public KitapDetayVM IliskiliKitapDetayNavEntry(int id)
        {
            var kitap = Bul(id);
            context.Entry(kitap).Navigation("Yazar").Load(); // explicit loading
            context.Entry(kitap).Navigation("Kategori").Load();
            context.Entry(kitap).Navigation("Yayinevi").Load();
            return mapper.Map<KitapDetayVM>(kitap);
        }

        public ICollection<KitapListeleVM> IliskiliKitapListele()
        {
            var kitaplar = table
                .Include(x => x.Yazar)
                .Include(x => x.Kategori)
                .Include(x => x.Yayinevi).ToList();
            var kitaplarVM = mapper.Map<ICollection<KitapListeleVM>>(kitaplar);
            return kitaplarVM;
        }
    }
}
