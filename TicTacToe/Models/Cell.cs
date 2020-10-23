namespace TicTacToe.Models
{
    public  class Cell
    {
        public int Id { get; set; }
        public CellValues Value { get; set; }

        public Cell(int id)
        {
            Id = id;
            Value = CellValues.Empty;
        }

    }
}
