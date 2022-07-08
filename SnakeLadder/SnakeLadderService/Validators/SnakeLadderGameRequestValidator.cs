using FluentValidation;
using SnakeLadderService.Models;

namespace SnakeLadderService.Validators
{
    public class SnakeLadderGameRequestValidator: AbstractValidator<SnakeLadderGameRequest>
    {
        public SnakeLadderGameRequestValidator()
        {
            RuleFor(x=>x.NumberOfPlayers).NotEmpty().NotNull().InclusiveBetween(1, 6);

            RuleFor(x => x.DiceThrows).NotNull().NotEmpty();

            RuleForEach(x => x.DiceThrows).InclusiveBetween(1, 6).When(x=>x.DiceThrows != null);

            RuleForEach(x => x.OptionalLadderStepsOverrides).SetValidator(new LadderStepValidator()).When(x => x.OptionalLadderStepsOverrides != null);

            RuleForEach(x => x.OptionalSnakeStepsOverrides).SetValidator(new SnakeStepValidator()).When(x => x.OptionalSnakeStepsOverrides != null);
        }
    }
}
