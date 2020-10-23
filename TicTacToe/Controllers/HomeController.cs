using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using TicTacToe.Models;
using TicTacToe.Models.ViewModels;

namespace TicTacToe.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public ActionResult Index()
        {
            //TempData["Board"] = new Board();
            return View(new BoardViewModel(new Board()));
        }

        [HttpPost]
        public ActionResult Index(int id)
        {
            Board gameboard;
            if (TempData.ContainsKey("Board"))
            {
                gameboard = (Board)TempData["Board"];
            }
            else
            {
                gameboard = new Board();
            }

            return View(new BoardViewModel(gameboard));
        }
    }
}