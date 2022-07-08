using SnakeLadder.Core.Contract;
using SnakeLadder.Domain;
using SnakeLadder.Domain.Models;

namespace SnakeLadder.Core
{
    public class SnakeLadderLogic : ISnakeLadderLogic
    {       
        public GameStatistics CalculateGameStats(int numberOfPlayers, int[]? diceThrows, IEnumerable<SnakeStep>? snakeSteps, IEnumerable<LadderStep>? ladderSteps)
        {
            snakeSteps ??= Constants.defaultSnakeSteps;
            ladderSteps ??= Constants.defaultLadderSteps;

            var snakeLadderGame = new SnakeLadderGame(numberOfPlayers, snakeSteps, ladderSteps);
            return snakeLadderGame.CalculateGameStats(diceThrows);
        }
    }
}
