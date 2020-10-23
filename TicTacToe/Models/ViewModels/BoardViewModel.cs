using System.Collections.Generic;

namespace TicTacToe.Models.ViewModels
{
    public class BoardViewModel
    {
        public Board Board { get; set; }

        public BoardViewModel(Board board)
        {
            Board = new Board();
        }
    }
}
