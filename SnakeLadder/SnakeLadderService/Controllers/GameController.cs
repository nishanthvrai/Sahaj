using Microsoft.AspNetCore.Mvc;
using SnakeLadder.Core.Contract;
using SnakeLadderService.Models;

namespace SnakeLadderService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GameController : ControllerBase
    {
        private readonly ILogger<GameController> logger;
        private readonly ISnakeLadderLogic snakeLadderLogic;

        public GameController(ILogger<GameController> logger, ISnakeLadderLogic snakeLadderLogic)
        {
            this.logger = logger;
            this.snakeLadderLogic = snakeLadderLogic;
        }


        [HttpPut("stats")]
        public SnakeLadderGameResponse GameStats(SnakeLadderGameRequest snakeLadderGameRequest)
        {
           
            var gameStats = this.snakeLadderLogic.CalculateGameStats(snakeLadderGameRequest.NumberOfPlayers, 
                snakeLadderGameRequest.DiceThrows, 
                snakeLadderGameRequest.OptionalSnakeStepsOverrides, 
                snakeLadderGameRequest.OptionalLadderStepsOverrides);

            return new SnakeLadderGameResponse()
            {
                GameStatistics = gameStats,
            };
        }

    }
}
