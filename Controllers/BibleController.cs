using FirstPageTry.Models;
using FirstPageTry.Services;
using Microsoft.AspNetCore.Mvc;
using System.Web;

namespace FirstPageTry.Controllers
{
    public class BibleController : Controller
    {
        BibleDAO repository = new BibleDAO();
        public BibleController()
        {
            repository = new BibleDAO();
        }
        public IActionResult Index()
        {
            return View(repository.AllVerses());
        }

        public IActionResult SearchResults(string searchTerm, string testament)
        {
            List<BibleModel> bibleList = repository.SearchVerses(searchTerm, testament);
            return View("Index", bibleList);
        }

        public IActionResult SearchForm()
        {
            return View();
        }
    }
}