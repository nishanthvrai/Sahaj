namespace SnakeLadder.Domain.Models
{
    public class GameStatistics
    {
        public List<PlayerStatistic>? PlayerStatistics { get; private set; }

        public string GameStatus { get; private set; } = String.Empty;

        public GameStatistics(List<PlayerStatistic> playerStatistics)
        {
            this.PlayerStatistics = playerStatistics;
            
            foreach (var playerStatistic in playerStatistics.OrderBy(o => o.MinimumNumberOfRolls))
            {
                GameStatus = GameStatus + $"{playerStatistic?.PlayerName} needs {playerStatistic?.MinimumNumberOfRolls} rolls to win the game. {Environment.NewLine}" ;
            }
        }

    }
}
