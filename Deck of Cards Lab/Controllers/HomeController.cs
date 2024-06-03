using Deck_of_Cards_Lab.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace Deck_of_Cards_Lab.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }
        public IActionResult Cards()
        {
            DeckModel result = DeckDAL.GetDeck();
            return View(result);
        }
        //[HttpPost]
        public IActionResult CardResult()
        {
            DeckModel result = DeckDAL.DrawCard();
            return View(result);
        }
        //[HttpGet]
        //public IActionResult CardResult(DeckModel c)
        //{
        //    DeckModel result = DeckDAL.DrawCard();
        //    result.cards.CopyTo(c.cards, 0);
        //    return View(result);
        //}
        public IActionResult CardShuffle()
        {
            DeckDAL.ShuffleDeck();
            return RedirectToAction("CardResult");
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
