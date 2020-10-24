using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;

namespace TicTacToe.Models.ViewModels
{
    public class BoardViewModel
    {
        public Board Board { get; set; }

        public CellValues NextTurn { get; set; }

        public BoardViewModel(Board board)
        {
            Board = new Board();
            NextTurn = CellValues.O;
        }
    }
}
