using NUnit.Framework;
using SnakeLadder.Domain.Models;

namespace SnakeLadder.Domain.Test.Models
{
    internal class SnakeLadderGameTest
    {
        [Test]
        public void CalculateGameStats_X_Y()
        {
            //Arrange
            var snakeLadderGame = new SnakeLadderGame(2, Constants.defaultSnakeSteps, Constants.defaultLadderSteps);
            var diceThrows = new int[] { 4, 6, 6, 1, 6, 2 };


            //Act
            snakeLadderGame.CalculateGameStats(diceThrows);


            //Assert
        }
    }
}
