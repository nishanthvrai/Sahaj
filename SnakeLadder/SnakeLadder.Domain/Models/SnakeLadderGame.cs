namespace SnakeLadder.Domain.Models
{
    public class SnakeLadderGame
    {
        private readonly IEnumerable<SnakeStep> snakes;
        private readonly IEnumerable<LadderStep> ladders;
        private readonly PlayersLobby playerLobby;

        private Player? player = null;
        private PlayerTurn playerTurn = new();

        public SnakeLadderGame(int numberOfPlayers, IEnumerable<SnakeStep> snakeSteps, IEnumerable<LadderStep> ladderSteps)
        {
            this.snakes = snakeSteps;
            this.ladders = ladderSteps;

            playerLobby = new PlayersLobby(numberOfPlayers);
        }

        public GameStatistics CalculateGameStats(int[] diceThrows)
        {
            ProcessDiceThrows(diceThrows);

            var playerStatistics = playerLobby.Players.Select(x=>x.GenerateGameStatistic(snakes, ladders)).ToList();
            var game = new GameStatistics(playerStatistics);            
            return game;
        }

        private void ProcessDiceThrows(int[] diceThrows)
        {
            // default it to first player
            player = playerLobby.GetNextPlayer();
            playerTurn = new PlayerTurn();

            for (int i = 0; i < diceThrows.Length; i++)
            {
                var throwValue = diceThrows[i];

                player.CurrentPosition = UpdateDiceThrowDetailsAndReturnNewPosition(throwValue);

                if (throwValue == Constants.LuckyThrow) // Lucky throw
                    continue;
                else
                {
                    UpdatePlayerTurn();
                    SetNextPlayerActiveAndCreateNewTurn();
                }
            }
        }

        private int UpdateDiceThrowDetailsAndReturnNewPosition(int throwValue)
        {
            var possibleNextPosition = (player.CurrentPosition + throwValue);

            var diceThrow = new DiceThrow();
            playerTurn.DiceThrows.Add(diceThrow);

            //Check for snake bite
            var snakeBite = snakes.FirstOrDefault(x => x.StepFrom == possibleNextPosition);
            if (snakeBite != null)
            {
                diceThrow.InsertDiceValue(throwValue, snakeBite, snakeBite.StepTo);
                return snakeBite.StepTo;
            }

            //Check for lucks
            var luckyLadder = ladders.FirstOrDefault(x => x.StepFrom == possibleNextPosition);

            if (luckyLadder != null)
            {
                diceThrow.InsertDiceValue(throwValue, luckyLadder, luckyLadder.StepTo);
                return luckyLadder.StepTo;
            }

            // Normal dude
            diceThrow.InsertDiceValue(throwValue, null, possibleNextPosition);
            return possibleNextPosition;
        }

        private void UpdatePlayerTurn()
        {
            //Update turn positions

            playerTurn.Position = player.CurrentPosition;
            player?.PlayerTurns.Add(playerTurn);
        }

        private void SetNextPlayerActiveAndCreateNewTurn()
        {
            player = playerLobby.GetNextPlayer();

            playerTurn = new PlayerTurn
            {
                PreviousTurnPosition = player.CurrentPosition
            };
        }
    }
}
