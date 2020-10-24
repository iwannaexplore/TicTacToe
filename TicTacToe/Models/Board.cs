using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace TicTacToe.Models
{
    public class Board
    {
        public List<Cell> Cells { get; set; }

        public Board(List<Cell> cells)
        {
            Cells = cells;
        }
    }
}
