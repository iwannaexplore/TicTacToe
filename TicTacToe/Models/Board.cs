using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TicTacToe.Models
{
    public class Board
    {
        public List<Cell> Cells { get; set; }

        public Board()
        {
            Cells = new List<Cell>
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
            };
        }
    }
}
