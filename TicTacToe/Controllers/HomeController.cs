using System.Collections.Generic;
using System.Linq;
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

        //There are values that will lead to victory
        private readonly List<List<int>> _winnerValues = new List<List<int>>
        {
            new List<int> {1, 2, 3},
            new List<int> {4, 5, 6},
            new List<int> {7, 8, 9},
            new List<int> {1, 4, 7},
            new List<int> {2, 5, 8},
            new List<int> {3, 6, 9},
            new List<int> {1, 5, 9},
            new List<int> {3, 5, 7}
        };

        //model of Main model of that app. Maked it static to don't lose it values after reloading
        private static BoardViewModel _gameBoard;

        //Start of the game
        public ActionResult Start()
        {
            _gameBoard = null;
            Board board = new Board(new List<Cell>
            {
                new Cell(1),
                new Cell(2),
                new Cell(3),
                new Cell(4),
                new Cell(5),
                new Cell(6),
                new Cell(7),
                new Cell(8),
                new Cell(9),
            });

            return View("Index", new BoardViewModel(board, CellValues.O));
        }

        //If the game started we go right here
        public ActionResult GameIndex()
        {
            return View("Index", _gameBoard);
        }

        //user click button and goes here
        public ActionResult MakeMove(int btnId)
        {
            //We use Deserialize from json here (we can't just write board = TempData["Board"]
            Board board = JsonConvert.DeserializeObject<Board>((string) TempData["Board"]);
            //get turn from Index.cshtml(View)
            CellValues nextTurn = (CellValues) TempData["NextTurn"];

            //if button with id = 3 was clicked, we change this button.Value from Empty to O or X
            board.Cells.First(c => c.Id == btnId).Value = nextTurn;

            //If O made the step, next=CellValues.X and vice versa
            nextTurn = nextTurn == CellValues.O ? CellValues.X : CellValues.O;

            //stepResult is HTML markup
            string stepResult = StepResult(board, ref nextTurn);

            //change static gameBoard variable
            _gameBoard = new BoardViewModel(board, nextTurn, stepResult);

            //return to GameIndex is needed for (clicking the browser’s Refresh button should redisplay the page, not post the previous click again)
            return RedirectToAction("GameIndex");
        }


        private string StepResult(Board board, ref CellValues nextTurn)
        {
            //Get all O and X which was clicked
            List<Cell> oCells = board.Cells.Where(c => c.Value == CellValues.O).ToList();
            List<Cell> xCells = board.Cells.Where(c => c.Value == CellValues.X).ToList();

            if (oCells.Capacity >= 3)
            {
                //Check if O win the game
                if (CheckForWinnerLine(oCells))
                {
                    nextTurn = CellValues.Empty;
                    //write HTML markup if O won
                    return "<div><div class=\"result-container\"><h2>O wins!</h2></div></div>" +
                           "<div class=\"anchor-container\"><a class=\"anchor\" href=\"/\">New Game</a></div>";
                }
            }

            if (xCells.Capacity >= 3)
            {//here the same
                if (CheckForWinnerLine(xCells))
                {
                    nextTurn = CellValues.Empty;

                    return "<div><div class=\"result-container\"><h2>X wins!</h2></div></div>" +
                           "<div class=\"anchor-container\"><a class=\"anchor\" href=\"/\">New Game</a></div>";
                }
            }

            if (oCells.Count == 5)
            {
                nextTurn = CellValues.Empty;

                return "<div><div class=\"result-container\"><h2>It's a tie!</h2></div></div>" +
                       "<div class=\"anchor-container\"><a class=\"anchor\" href=\"/\">New Game</a></div>";
            }
            //if nobody wins - return message about next turn
            return $"<div class=\"container\"><h2>{nextTurn} turn!</h2></div>";
        }

        private bool CheckForWinnerLine(List<Cell> cells)
        {
            //check if clicked buttons contains line for win like 1,2,3 or 4,5,6
            return _winnerValues.Any(wv => cells.Select(c => c.Id).Intersect(wv).Count() == wv.Count);
        }
    }
}