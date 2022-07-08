using FluentValidation.TestHelper;
using NUnit.Framework;
using SnakeLadder.Domain.Models;
using SnakeLadderService.Validators;

namespace SnakeLadderService.Test.Validators
{
    internal class SnakeStepValidatorTest
    {

        private readonly SnakeStepValidator snakeStepValidator = new SnakeStepValidator();

        [TestCase(0)]
        [TestCase(10)]
        [TestCase(5)]
        [TestCase(1)]
        [TestCase(100)]
        [TestCase(101)]
        public void SnakeStepValidator_InvalidStepFrom_ThrowException(int stepFrom)
        {
            //Arrange 
            var step = new SnakeStep() { StepFrom = stepFrom };

            //Act
            var result = snakeStepValidator.TestValidate(step);

            //Assert
            result.ShouldHaveValidationErrorFor(s => s.StepFrom);
        }

        [TestCase(11)]
        [TestCase(20)]
        [TestCase(30)]
        [TestCase(40)]
        [TestCase(90)]
        [TestCase(91)]
        [TestCase(99)]
        public void SnakeStepValidator_ValidStepFrom_ThrowException(int stepFrom)
        {
            //Arrange 
            var step = new SnakeStep() { StepFrom = stepFrom };

            //Act
            var result = snakeStepValidator.TestValidate(step);

            //Assert
            result.ShouldNotHaveValidationErrorFor(s => s.StepFrom);
        }

        [TestCase(100)]
        [TestCase(91)]
        [TestCase(95)]
        [TestCase(0)]
        [TestCase(101)]
        public void SnakeStepValidator_InvalidStepTo_ThrowException(int stepTo)
        {
            //Arrange 
            var step = new SnakeStep() { StepTo = stepTo };

            //Act
            var result = snakeStepValidator.TestValidate(step);

            //Assert
            result.ShouldHaveValidationErrorFor(s => s.StepTo);
        }

        [TestCase(1)]
        [TestCase(10)]
        [TestCase(11)]
        [TestCase(20)]
        [TestCase(30)]
        [TestCase(40)]
        [TestCase(90)]
        public void SnakeStepValidator_ValidStepTo_ThrowException(int stepTo)
        {
            //Arrange 
            var step = new SnakeStep() { StepTo = stepTo };

            //Act
            var result = snakeStepValidator.TestValidate(step);

            //Assert
            result.ShouldNotHaveValidationErrorFor(s => s.StepTo);
        }
    }
}
