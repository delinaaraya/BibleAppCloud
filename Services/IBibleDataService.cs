using FirstPageTry.Models;

namespace FirstPageTry.Services
{
    public interface IBibleDataService
    {
        List<BibleModel> AllVerses();
        List<BibleModel> SearchVerses(string searchTerm, string testament);
        BibleModel GetVerseById(int id);

    }
}
