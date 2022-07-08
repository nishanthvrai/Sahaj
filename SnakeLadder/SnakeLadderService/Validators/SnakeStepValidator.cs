using FluentValidation;
using SnakeLadder.Domain.Models;

namespace SnakeLadderService.Validators
{
    public class SnakeStepValidator: AbstractValidator<SnakeStep>
    {
        public SnakeStepValidator()
        {
            RuleFor(x => x.StepFrom).InclusiveBetween(11, 99);
            RuleFor(x => x.StepTo).InclusiveBetween(1, 90);
        }
    }
}
