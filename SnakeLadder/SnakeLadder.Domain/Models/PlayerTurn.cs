namespace SnakeLadder.Domain.Models
{
    public class PlayerTurn
    {
        public int Position { get; set; }

        public int PreviousTurnPosition { get; set; }

        public List<DiceThrow> DiceThrows { get; set; } = new List<DiceThrow>();

    }
}
