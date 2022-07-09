namespace SnakeLadder.Domain.Models
{
    internal class Player
    {
        public int Id { get; private set; }

        public string? Name
        {
            get
            {
                return $"Player {this.Id}";
            }
        }

        public int CurrentPosition { get; set; } = 0;

        public List<PlayerTurn> PlayerTurns { get; set; } = new List<PlayerTurn>();

        public Player(int id)
        {
            Id = id;
        }

        public PlayerStatistic GenerateGameStatistic(IEnumerable<SnakeStep> snakes, IEnumerable<LadderStep> ladders)
        {
            return new PlayerStatistic()
            {
                PlayerName = Name,
                GamePosition = CurrentPosition,
                MinimumNumberOfRolls = GetMinimumNoRolesToWin(snakes, ladders),
                MinimumAmountOfClimbs = GetMinimumNumerOfClimbs(),
                MinimumAmountOfSlides = GetMinimumNumerOfSlides(),
                BiggestClimbInASingleTurn = GetBiggestClimbInASingleTurn(),
                BiggestSlideInASingleTurn = GetBiggestSlideInASingleTurn(),
                LongestTurn = GetLongestTurn(),
                MinimumUnluckyRolls = GetLandsOnSnake(),
                MinimumLuckyRolls = GetLandsOnLadder() + IsCloseToSnakeBite(snakes) + IsLastRollASix()
            };
        }

        private int GetMinimumNoRolesToWin(IEnumerable<SnakeStep> snakes, IEnumerable<LadderStep> ladders)
        {
            int attempts = 0;
            int currentPosition = CurrentPosition;
            while(currentPosition <= 99)
            {
                var nextAvailableMaxPosition = (currentPosition > 94)? 100-currentPosition: Constants.LuckyThrow;
                var nextAvailableBestLadder = ladders.Where(ladder =>  ladder.StepFrom >= currentPosition && ladder.StepFrom <= currentPosition + nextAvailableMaxPosition)
                    .OrderByDescending(o=>o.StepTo - o.StepFrom).FirstOrDefault();

                if(nextAvailableBestLadder != null) // Lucky ladder
                {
                    currentPosition = nextAvailableBestLadder.StepTo;
                    attempts++;
                }
                else // Check the best possible dice value starting from max value.
                {
                    for (int i = nextAvailableMaxPosition; i > 0; i--)
                    {
                        var pottentialPosition = currentPosition + i;

                        if(snakes.Any(s=>s.StepFrom == pottentialPosition) == false)
                        {
                            currentPosition = pottentialPosition;
                            attempts++;
                            break;
                        }
                    }
                }
            }

            return attempts;
        }

        private int GetMinimumNumerOfClimbs() => PlayerTurns.Sum(x => x.DiceThrows.Where(d => d.IsClimb).Sum(s=>(s.Step.StepTo - s.Step.StepFrom)));

        private int GetMinimumNumerOfSlides() => PlayerTurns.Sum(x => x.DiceThrows.Where(d => d.IsSlide).Sum(s => (s.Step.StepFrom - s.Step.StepTo)));

        private int GetBiggestClimbInASingleTurn() => (PlayerTurns.Any())? 
            PlayerTurns.Max(x => x.DiceThrows.Where(d => d.IsClimb).Sum(s => (s.Step.StepTo - s.Step.StepFrom)))
            : 0;

        private int GetBiggestSlideInASingleTurn() => (PlayerTurns.Any()) ? 
            PlayerTurns.Max(x => x.DiceThrows.Where(d => d.IsSlide).Sum(s => (s.Step.StepFrom - s.Step.StepTo)))
            : 0;

        private int[]? GetLongestTurn() => PlayerTurns.OrderByDescending(x=>x.DiceThrows.Sum(x=>x.ThrowValue)).FirstOrDefault()?.DiceThrows.Select(d=>d.ThrowValue).ToArray();

        private int GetLandsOnSnake() => PlayerTurns.Count(x => x.DiceThrows.Any(d => d.IsSlide));

        private int GetLandsOnLadder() => PlayerTurns.Count(x => x.DiceThrows.Any(d => d.IsClimb));

        private int IsCloseToSnakeBite(IEnumerable<SnakeStep> snakes)
        {
            var snakeBitePoint = snakes.Select(s => s.StepFrom).ToList();

            return PlayerTurns.SelectMany(x => x.DiceThrows)
                .Where(x => x.Step == null)
                .Count(d => 
                snakeBitePoint.Any(s => s >= d.LandedPosition && s <= (d.LandedPosition + NextTwoIndexByDiceValue(d.ThrowValue))) //Right Side
                ||
                (snakeBitePoint.Any(s => s >= (d.LandedPosition - PrevioiusTwoIndexByDiceValue(d.ThrowValue)) && (s <= d.LandedPosition)) //Left Side
                ));
        }

        private int NextTwoIndexByDiceValue(int throwValue) => throwValue switch
        {
                1 or 2 or 3 or 4 => 2, 5 => 1, 6 => 0
        };

        private int PrevioiusTwoIndexByDiceValue(int throwValue) => throwValue switch
        {
            6 or 5 or 3 or 4 => 2, 2 => 1, 1 => 0
        };

        private int IsLastRollASix()
        {
            var lastPlayerTurn = PlayerTurns.LastOrDefault();
            return (lastPlayerTurn != null && lastPlayerTurn.Position == 100 && lastPlayerTurn.PreviousTurnPosition == 94) ? 1 : 0;
        }


    }
}
