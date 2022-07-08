namespace SnakeLadder.Domain.Models
{
    public class DiceThrow
    {
        public int ThrowValue { get; private set; }

        public bool IsSlide { get; private set; }

        public bool IsClimb { get; private set; }

        public int LandedPosition { get; private set; }

        public Step? Step { get; private set; }

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
