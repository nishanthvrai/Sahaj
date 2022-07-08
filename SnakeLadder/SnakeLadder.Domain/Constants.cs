using SnakeLadder.Domain.Models;

namespace SnakeLadder.Domain
{
    public static class Constants
    {
        public static IEnumerable<SnakeStep> defaultSnakeSteps = new List<SnakeStep>()
        {
            new SnakeStep() { StepFrom = 27, StepTo= 5 },
            new SnakeStep() { StepFrom = 40, StepTo= 3 },
            new SnakeStep() { StepFrom = 43, StepTo= 18 },
            new SnakeStep() { StepFrom = 54, StepTo= 31 },
            new SnakeStep() { StepFrom = 66, StepTo= 45 },
            new SnakeStep() { StepFrom = 76, StepTo= 58 },
            new SnakeStep() { StepFrom = 89, StepTo= 54 },
            new SnakeStep() { StepFrom = 99, StepTo= 41 }
        };

        public static IEnumerable<LadderStep> defaultLadderSteps = new List<LadderStep>()
        {
            new LadderStep() { StepFrom =4, StepTo = 25},
            new LadderStep() { StepFrom =13, StepTo = 46},
            new LadderStep() { StepFrom =33, StepTo = 49},
            new LadderStep() { StepFrom =42, StepTo = 63},
            new LadderStep() { StepFrom =50, StepTo = 69},
            new LadderStep() { StepFrom =62, StepTo = 81},
            new LadderStep() { StepFrom =74, StepTo = 92}            
        };

        public static int LuckyThrow = 6;
    }
}
