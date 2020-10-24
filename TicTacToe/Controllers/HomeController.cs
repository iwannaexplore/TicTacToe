using System.Text.Json;
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
            Board board;
            if (TempData.ContainsKey("Board"))
            {
                board = JsonSerializer.Deserialize<Board>((string) TempData["Board"]);
            }
            else
            {
                board = new Board();
            }

            return View(new BoardViewModel(board));
        }

        [HttpPost]
        public ActionResult MakeAStep(int btn)
        {
            Board board = JsonSerializer.Deserialize<Board>((string) TempData["Board"]);
            string nextTurn = (string) TempData["NextTUrn"];



            return View("Index", new BoardViewModel(board));
        }

        
    }
}