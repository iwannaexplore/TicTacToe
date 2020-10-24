namespace TicTacToe.Models.ViewModels
{
    public class BoardViewModel
    {
        public Board Board { get; set; }

        public CellValues NextTurn { get; set; }

        public string StepResult { get; set; }

        public BoardViewModel() { }
        public BoardViewModel(Board board, CellValues nextTurn)
        {
            Board = board;
            NextTurn = nextTurn;
            StepResult = $"<div class=\"container\"><h2>{nextTurn} turn!</h2></div>";
        }

        public BoardViewModel(Board board, CellValues nextTurn, string result)
        {
            Board = board;
            NextTurn = nextTurn;
            StepResult = result;
        }
    }
}
