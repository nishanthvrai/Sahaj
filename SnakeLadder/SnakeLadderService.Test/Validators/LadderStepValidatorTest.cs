using FluentValidation.TestHelper;
using NUnit.Framework;
using SnakeLadder.Domain.Models;
using SnakeLadderService.Validators;

namespace SnakeLadderService.Test.Validators
{
    internal class LadderStepValidatorTest
    {

        private readonly LadderStepValidator ladderStepValidator = new LadderStepValidator();

        [TestCase(0)]
        [TestCase(99)]
        [TestCase(91)]
        [TestCase(100)]
        [TestCase(1000)]
        public void LadderStepValidator_InvalidStepFrom_ThrowException(int stepFrom)
        {
            //Arrange 
            var step = new LadderStep() { StepFrom = stepFrom };

            //Act
            var result = ladderStepValidator.TestValidate(step);

            //Assert
            result.ShouldHaveValidationErrorFor(s => s.StepFrom);
        }

        [TestCase(1)]
        [TestCase(10)]
        [TestCase(30)]
        [TestCase(40)]
        [TestCase(90)]
        public void LadderStepValidator_ValidStepFrom_ThrowException(int stepFrom)
        {
            //Arrange 
            var step = new LadderStep() { StepFrom = stepFrom };

            //Act
            var result = ladderStepValidator.TestValidate(step);

            //Assert
            result.ShouldNotHaveValidationErrorFor(s => s.StepFrom);
        }

        [TestCase(0)]
        [TestCase(1)]
        [TestCase(10)]
        [TestCase(5)]
        [TestCase(101)]
        public void LadderStepValidator_InvalidStepTo_ThrowException(int stepTo)
        {
            //Arrange 
            var step = new LadderStep() { StepTo = stepTo };

            //Act
            var result = ladderStepValidator.TestValidate(step);

            //Assert
            result.ShouldHaveValidationErrorFor(s => s.StepTo);
        }

        [TestCase(11)]
        [TestCase(40)]
        [TestCase(30)]
        [TestCase(40)]
        [TestCase(91)]
        [TestCase(100)]
        public void LadderStepValidator_ValidStepTo_ThrowException(int stepTo)
        {
            //Arrange 
            var step = new LadderStep() { StepTo = stepTo };

            //Act
            var result = ladderStepValidator.TestValidate(step);

            //Assert
            result.ShouldNotHaveValidationErrorFor(s => s.StepTo);
        }
    }
}
