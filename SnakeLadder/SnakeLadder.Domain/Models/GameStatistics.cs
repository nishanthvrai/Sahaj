namespace SnakeLadder.Domain.Models
{
    public class GameStatistics
    {
        public List<PlayerStatistic>? PlayerStatistics { get; private set; }

        public string? GameStatus { get; private set; }

        public GameStatistics(List<PlayerStatistic> playerStatistics)
        {
            this.PlayerStatistics = playerStatistics;
            var favoritePlayer = playerStatistics
                .OrderBy(o=> o.MinimumNumberOfRolls)
                .FirstOrDefault();

            GameStatus = $"{favoritePlayer?.PlayerName} is a hot favorite on the game with best {favoritePlayer?.MinimumNumberOfRolls} rolls.";
        }

    }
}
