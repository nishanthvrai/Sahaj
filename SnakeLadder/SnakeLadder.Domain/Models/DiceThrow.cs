namespace SnakeLadder.Domain.Models
{
    public class DiceThrow
    {
        public int ThrowValue { get; set; }

        public bool IsSlide { get; set; }

        public bool IsClimb { get; set; }

        public int LandedPosition { get; set; }

        public Step? Step { get; set; }

        public void InsertDiceValue(int throwValue, Step? step, int landedPosition)
        {
            if(step is SnakeStep)
                IsSlide = true;
            else if(step is LadderStep)
                IsClimb = true;

            Step = step;
            ThrowValue = throwValue;
            LandedPosition = landedPosition;
        }
    }
}
