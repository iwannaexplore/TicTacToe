using Newtonsoft.Json;
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
                board = JsonConvert.DeserializeObject<Board>((string) TempData["Board"]);
            }
            else
            {
                board = new Board();
            }

            return View(new BoardViewModel(board));
        }

        
        public ActionResult MakeAStep(int btn)
        {
            Board board = JsonConvert.DeserializeObject<Board>((string) TempData["Board"]);
            CellValues nextTurn = (CellValues) TempData["NextTurn"];



            return View("Index", new BoardViewModel(board));
        }

        
    }
}