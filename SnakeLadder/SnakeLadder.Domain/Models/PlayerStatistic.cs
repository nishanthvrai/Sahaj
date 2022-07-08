namespace SnakeLadder.Domain.Models
{
    public class PlayerStatistic
    {
        public string PlayerName { get; set; }
        public int MinimumNumberOfRolls { get; set; }   
        public int MinimumAmountOfClimbs { get; set; }
        public int MinimumAmountOfSlides { get; set; }
        public int BiggestClimbInASingleTurn { get; set; }
        public int BiggestSlideInASingleTurn { get; set; }
        public int[]? LongestTurn { get; set; }
        public int MinimumUnluckyRolls { get; set; }
        public int MinimumLuckyRolls { get; set; }
       
    }
}
