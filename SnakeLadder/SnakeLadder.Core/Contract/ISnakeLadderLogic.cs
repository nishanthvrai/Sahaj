using SnakeLadder.Core.Models;
using SnakeLadder.Domain.Models;

namespace SnakeLadder.Core.Contract
{
    public interface ISnakeLadderLogic
    {
        GameStatistics CalculateGameStats( int numberOfPlayers, int[]? diceThrows, IEnumerable<SnakeStep>? snakeSteps, IEnumerable<LadderStep>? ladderSteps);
    }
}
