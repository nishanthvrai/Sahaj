using NUnit.Framework;
using SnakeLadder.Domain.Models;
using System.Collections.Generic;
using System.Linq;

namespace SnakeLadder.Domain.Test.Models
{
    internal class SnakeLadderGameTest
    {
        [Test]
        public void CalculateGameStats_TwoPlayersAndPlayer2IsLeading_Player2ShouldBeTheFavorite()
        {
            //Arrange
            var noOfPlayers = 2;
            var snakeLadderGame = new SnakeLadderGame(noOfPlayers, Constants.defaultSnakeSteps, Constants.defaultLadderSteps);
            var diceThrows = new int[] 
            { 
                4, 6, 6, 1, 
                6, 2, 4 
            };

            var expectedGameStatistic = new GameStatistics(new List<PlayerStatistic>()
            {
                CreatePlayerStatistic(21,0,new int[] {6, 2}, 37, 0, 2, 4, 0, "Player 1", 49),
                CreatePlayerStatistic(33,0,new int[] {6, 6, 1}, 52, 0, 2, 3, 0, "Player 2", 69)
            });

            //Act
            var gameStatistic = snakeLadderGame.CalculateGameStats(diceThrows);


            //Assert
            AssertGameStatisticsAreEqual(expectedGameStatistic, gameStatistic);

        }

        [Test]
        public void CalculateGameStats_TwoPlayersAndPlayer4Leads_Player4ShouldBeTheFavorite()
        {
            //Arrange
            var noOfPlayers = 4;
            var snakeLadderGame = new SnakeLadderGame(noOfPlayers, Constants.defaultSnakeSteps, Constants.defaultLadderSteps);
            var diceThrows = new int[] { 
                1,1,1,4,            
                1,1,1,6,2,
                1,1,1,1,
                2,2,2,5
            };

            var expectedGameStatistic = new GameStatistics(new List<PlayerStatistic>()
            {
                CreatePlayerStatistic(0,0,new int[] {2}, 0, 0, 0, 6, 0, "Player 1", 5),
                CreatePlayerStatistic(0,0,new int[] {2}, 0, 0, 0, 6, 0, "Player 2", 5),
                CreatePlayerStatistic(0,0,new int[] {2}, 0, 0, 0, 6, 0, "Player 3", 5),
                CreatePlayerStatistic(21,0,new int[] {6, 2}, (21+16+19+18) , 0, 4, 2, 0, "Player 4", 92)
            });

            //Act
            var gameStatistic = snakeLadderGame.CalculateGameStats(diceThrows);


            //Assert
            AssertGameStatisticsAreEqual(expectedGameStatistic, gameStatistic);

        }

        [Test]
        public void CalculateGameStats_Player4FinishedTheGame_Player4ShouldNotBeConsideredForNextThrows()
        {
            //Arrange
            var noOfPlayers = 4;
            var snakeLadderGame = new SnakeLadderGame(noOfPlayers, Constants.defaultSnakeSteps, Constants.defaultLadderSteps);
            var diceThrows = new int[] {
                1,1,1,4,
                1,1,1,6,2,
                1,1,1,1,
                2,2,2,5,
                1,1,1,6,2,
                1, 1, 1,
                4, 4, 4
            };

            var expectedGameStatistic = new GameStatistics(new List<PlayerStatistic>()
            {
                CreatePlayerStatistic(0,0,new int[] {4}, 0, 0, 0, 5, 0, "Player 1", 11),
                CreatePlayerStatistic(0,0,new int[] {4}, 0, 0, 0, 5, 0, "Player 2", 11),
                CreatePlayerStatistic(0,0,new int[] {4}, 0, 0, 0, 5, 0, "Player 3", 11),
                CreatePlayerStatistic(21,0,new int[] {6, 2}, (21+16+19+18) , 0, 5, 0, 0, "Player 4", 100)
            });

            //Act
            var gameStatistic = snakeLadderGame.CalculateGameStats(diceThrows);


            //Assert
            AssertGameStatisticsAreEqual(expectedGameStatistic, gameStatistic);

        }

        void AssertGameStatisticsAreEqual(GameStatistics expected, GameStatistics actual)
        {
            foreach (var playerStatistic in actual?.PlayerStatistics)
            {
                var expectedPlayerInfo = expected?.PlayerStatistics?.First(x => x.PlayerName == playerStatistic.PlayerName);

                Assert.AreEqual(expectedPlayerInfo?.BiggestClimbInASingleTurn, playerStatistic.BiggestClimbInASingleTurn);
                Assert.AreEqual(expectedPlayerInfo?.BiggestSlideInASingleTurn, playerStatistic.BiggestSlideInASingleTurn);
                Assert.AreEqual(expectedPlayerInfo?.LongestTurn, playerStatistic.LongestTurn);
                Assert.AreEqual(expectedPlayerInfo?.MinimumAmountOfClimbs, playerStatistic.MinimumAmountOfClimbs);
                Assert.AreEqual(expectedPlayerInfo?.MinimumAmountOfSlides, playerStatistic.MinimumAmountOfSlides);
                Assert.AreEqual(expectedPlayerInfo?.MinimumLuckyRolls, playerStatistic.MinimumLuckyRolls);
                Assert.AreEqual(expectedPlayerInfo?.MinimumNumberOfRolls, playerStatistic.MinimumNumberOfRolls);
                Assert.AreEqual(expectedPlayerInfo?.MinimumUnluckyRolls, playerStatistic.MinimumUnluckyRolls);
            }

            Assert.AreEqual(expected.GameStatus, actual.GameStatus);
        }


        PlayerStatistic CreatePlayerStatistic(int biggestClimbInASingleTurn, 
            int biggestSlideInASingleTurn,
            int[] longestTurn,
            int minimumAmountOfClimbs,
            int minimumAmountOfSlides,
            int minimumLuckyRolls,
            int minimumNumberOfRolls,
            int minimumUnluckyRolls,
            string playerName,
            int gamePosition
            )
        {
            return new PlayerStatistic()
            {
                BiggestClimbInASingleTurn = biggestClimbInASingleTurn,
                BiggestSlideInASingleTurn = biggestSlideInASingleTurn,
                LongestTurn = longestTurn,
                MinimumAmountOfClimbs = minimumAmountOfClimbs,
                MinimumAmountOfSlides = minimumAmountOfSlides,
                MinimumLuckyRolls = minimumLuckyRolls,
                MinimumNumberOfRolls = minimumNumberOfRolls,
                MinimumUnluckyRolls = minimumUnluckyRolls,
                PlayerName = playerName,
                GamePosition = gamePosition
            };
        }
    }
}
