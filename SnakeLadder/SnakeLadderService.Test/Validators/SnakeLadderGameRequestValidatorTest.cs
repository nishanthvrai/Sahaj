using FluentValidation.TestHelper;
using NUnit.Framework;
using SnakeLadderService.Models;
using SnakeLadderService.Validators;

namespace SnakeLadderService.Test.Validators
{
    internal class SnakeLadderGameRequestValidatorTest
    {
        private readonly SnakeLadderGameRequestValidator snakeLadderGameRequestValidator = new();

        [TestCase(0)]
        [TestCase(7)]
        [TestCase(100)]
        public void SnakeLadderGameRequest_InvalidNumberOfPlayers_ThrowException(int numberOfPlayers)
        {
            //Arrange 
            var snakeLadderGameRequest = new SnakeLadderGameRequest() { NumberOfPlayers = numberOfPlayers };

            //Act
            var result = snakeLadderGameRequestValidator.TestValidate(snakeLadderGameRequest);

            //Assert
            result.ShouldHaveValidationErrorFor(s => s.NumberOfPlayers);
        }

        [TestCase(1)]
        [TestCase(2)]
        [TestCase(3)]
        [TestCase(4)]
        [TestCase(5)]
        [TestCase(6)]
        public void SnakeLadderGameRequest_ValidNumberOfPlayers_DoesNotThrowException(int numberOfPlayers)
        {
            //Arrange 
            var snakeLadderGameRequest = new SnakeLadderGameRequest() { NumberOfPlayers = numberOfPlayers };

            //Act
            var result = snakeLadderGameRequestValidator.TestValidate(snakeLadderGameRequest);

            //Assert
            result.ShouldNotHaveValidationErrorFor(s => s.NumberOfPlayers);
        }

        [Test]
        public void SnakeLadderGameRequest_NullDiceThrows_ThrowException()
        {
            //Arrange 
            var snakeLadderGameRequest = new SnakeLadderGameRequest() { DiceThrows = null};

            //Act
            var result = snakeLadderGameRequestValidator.TestValidate(snakeLadderGameRequest);

            //Assert
            result.ShouldHaveValidationErrorFor(s => s.DiceThrows);
        }

        [Test]
        public void SnakeLadderGameRequest_EmptyDiceThrows_ThrowException()
        {
            //Arrange 
            var snakeLadderGameRequest = new SnakeLadderGameRequest() { DiceThrows = System.Array.Empty<int>() };

            //Act
            var result = snakeLadderGameRequestValidator.TestValidate(snakeLadderGameRequest);

            //Assert
            result.ShouldHaveValidationErrorFor(s => s.DiceThrows);
        }


        [Test]
        public void SnakeLadderGameRequest_InvalidItemInDiceThrows_ThrowException()
        {
            //Arrange 
            var snakeLadderGameRequest = new SnakeLadderGameRequest() { DiceThrows = new int[] { 7 } };

            //Act
            var result = snakeLadderGameRequestValidator.TestValidate(snakeLadderGameRequest);

            //Assert
            result.ShouldHaveValidationErrorFor(s => s.DiceThrows);
        }


        [Test]
        public void SnakeLadderGameRequest_InvalidItemsInDiceThrows_ThrowException()
        {
            //Arrange 
            var snakeLadderGameRequest = new SnakeLadderGameRequest() { DiceThrows = new int[] { 0, 7, 100, 10 } };

            //Act
            var result = snakeLadderGameRequestValidator.TestValidate(snakeLadderGameRequest);

            //Assert
            result.ShouldHaveValidationErrorFor(s => s.DiceThrows);
        }

        [Test]
        public void SnakeLadderGameRequest_ValidItemInDiceThrows_DoesNotThrowException()
        {
            //Arrange 
            var snakeLadderGameRequest = new SnakeLadderGameRequest() { DiceThrows = new int[] { 6 } };

            //Act
            var result = snakeLadderGameRequestValidator.TestValidate(snakeLadderGameRequest);

            //Assert
            result.ShouldNotHaveValidationErrorFor(s => s.DiceThrows);
        }

        [Test]
        public void SnakeLadderGameRequest_ValidItemsInDiceThrows_DoesNotThrowException()
        {
            //Arrange 
            var snakeLadderGameRequest = new SnakeLadderGameRequest() { DiceThrows = new int[] { 1, 6, 5, 3, 4, 5, 2 } };

            //Act
            var result = snakeLadderGameRequestValidator.TestValidate(snakeLadderGameRequest);

            //Assert
            result.ShouldNotHaveValidationErrorFor(s => s.DiceThrows);
        }

    }
}
