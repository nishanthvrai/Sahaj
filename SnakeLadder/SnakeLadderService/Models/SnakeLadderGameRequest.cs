using SnakeLadder.Domain.Models;
using System.ComponentModel;

namespace SnakeLadderService.Models
{
    public class SnakeLadderGameRequest
    {

        /// <summary>
        /// Number of Players
        /// </summary>
        public int NumberOfPlayers { get; set; }

        /// <summary>
        /// Game dice throws
        /// </summary>
        public int[]? DiceThrows { get; set; }

        /// <summary>
        /// Default values are used if the value is null.
        /// </summary>
        [DefaultValue(null)]
        public List<SnakeStep>? OptionalSnakeStepsOverrides { get; set; }

        /// <summary>
        /// Default values are used if the value is null.
        /// </summary>
        [DefaultValue(null)]
        public List<LadderStep>? OptionalLadderStepsOverrides { get; set; }

    }
}
