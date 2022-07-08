using FluentValidation;
using SnakeLadder.Domain.Models;

namespace SnakeLadderService.Validators
{
    public class LadderStepValidator: AbstractValidator<LadderStep>
    {
        public LadderStepValidator()
        {
            RuleFor(x => x.StepFrom).InclusiveBetween(1, 90);
            RuleFor(x => x.StepTo).InclusiveBetween(11, 100);
        }
    }
}
