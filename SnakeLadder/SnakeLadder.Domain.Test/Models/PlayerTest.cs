using NUnit.Framework;
using SnakeLadder.Domain.Models;
using System.Collections.Generic;

namespace SnakeLadder.Domain.Test.Models
{
    internal class PlayerTest
    {

        [Test]
        public void GenerateGameStatistic_ValidateMinimumNumberOfRollsStartingAtZero_ExpectedMinimumNumberOfRollsMatch()
        {
            //Arrange
            var expectedMinimumNumberOfRolls = 7;

            var player = new Player(byte.MaxValue)
            {
                CurrentPosition = 0
            };

            //Act
            var playerStatistic = player.GenerateGameStatistic(Constants.defaultSnakeSteps, Constants.defaultLadderSteps);

            //Assert
            Assert.AreEqual(expectedMinimumNumberOfRolls, playerStatistic.MinimumNumberOfRolls);

        }

        [Test]
        public void GenerateGameStatistic_ValidateMinimumNumberOfRolls_ExpectedMinimumNumberOfRollsMatch()
        {
            //Arrange
            var expectedMinimumNumberOfRolls = 4;
           
            var player = new Player(byte.MaxValue)
            {
                CurrentPosition = 63
            };

            //Act
            var playerStatistic = player.GenerateGameStatistic(Constants.defaultSnakeSteps, Constants.defaultLadderSteps);

            //Assert
            Assert.AreEqual(expectedMinimumNumberOfRolls, playerStatistic.MinimumNumberOfRolls);

        }

        [Test]
        public void GenerateGameStatistic_ValidateExpectedNumberOfClimbs_ExpectedMinimumAmountOfClimbsMatch()
        {
            //Arrange
            int expectedMinimumAmountOfClimbs = (25 - 4) + (49 - 33) + (69 - 50) + (81 - 62);
            var playerTurns = new List<PlayerTurn>
            {
                CreatePlayerTurn(new List<DiceThrow>()
            {
                CreateDiceThrow(4, new LadderStep() { StepFrom = 4, StepTo = 25 }, 25)
            }),

                CreatePlayerTurn(new List<DiceThrow>()
            {
                CreateDiceThrow(6, null, 31),
                CreateDiceThrow(2, new LadderStep(){ StepFrom = 33, StepTo = 49 }, 49)
            }),

                CreatePlayerTurn(new List<DiceThrow>()
            {
                CreateDiceThrow(1, new LadderStep(){ StepFrom = 50, StepTo = 69 }, 69)
            }),

                CreatePlayerTurn(new List<DiceThrow>()
            {
                CreateDiceThrow(6, null, 75),
                CreateDiceThrow(1, new LadderStep(){ StepFrom = 62, StepTo = 81 }, 81)
            })
            };

            var player = new Player(byte.MaxValue)
            {
                PlayerTurns = playerTurns
            };

            //Act
            var playerStatistic = player.GenerateGameStatistic(Constants.defaultSnakeSteps, Constants.defaultLadderSteps);

            //Assert
            Assert.AreEqual(expectedMinimumAmountOfClimbs, playerStatistic.MinimumAmountOfClimbs);

        }

        [Test]
        public void GenerateGameStatistic_ValidateExpectedNumberOfSlides_ExpectedMinimumAmountOfSlidesMatch()
        {
            //Arrange
            int expectedMinimumAmountOfSlides = (27 - 5) + (54 - 31) + (54 - 31);

            var playerTurns = new List<PlayerTurn>
            {
                CreatePlayerTurn(new List<DiceThrow>()
            {
                CreateDiceThrow(4, new LadderStep() { StepFrom = 4, StepTo = 25 }, 25)
            }),

                CreatePlayerTurn(new List<DiceThrow>()
            {
                CreateDiceThrow(2, new SnakeStep(){ StepFrom = 27, StepTo = 5 }, 5)
            }),

                CreatePlayerTurn(new List<DiceThrow>()
            {
                CreateDiceThrow(6, null, 11),
                CreateDiceThrow(2, new LadderStep(){ StepFrom = 13, StepTo = 46 }, 46)
            }),

                CreatePlayerTurn(new List<DiceThrow>()
            {
                CreateDiceThrow(6, null, 52),
                CreateDiceThrow(2, new SnakeStep(){ StepFrom = 54, StepTo = 31 }, 31)
            }),

                CreatePlayerTurn(new List<DiceThrow>()
            {
                CreateDiceThrow(2, new LadderStep(){ StepFrom = 33, StepTo = 49 }, 49)
            }),

                CreatePlayerTurn(new List<DiceThrow>()
            {
                CreateDiceThrow(5, new SnakeStep(){ StepFrom = 54, StepTo = 31 }, 31)
            })
            };

            var player = new Player(byte.MaxValue)
            {
                PlayerTurns = playerTurns
            };

            //Act
            var playerStatistic = player.GenerateGameStatistic(Constants.defaultSnakeSteps, Constants.defaultLadderSteps);

            //Assert
            Assert.AreEqual(expectedMinimumAmountOfSlides, playerStatistic.MinimumAmountOfSlides);

        }

        [Test]
        public void GenerateGameStatistic_ValidateBiggestClimbInASingleTurn_ExpectedBiggestClimbInASingleTurnMatch()
        {
            //Arrange
            int expectedBiggestClimbInASingleTurn = (46 - 13);

            var playerTurns = new List<PlayerTurn>
            {
                CreatePlayerTurn(new List<DiceThrow>()
            {
                CreateDiceThrow(4, new LadderStep() { StepFrom = 4, StepTo = 25 }, 25)
            }),

                CreatePlayerTurn(new List<DiceThrow>()
            {
                CreateDiceThrow(2, new SnakeStep(){ StepFrom = 27, StepTo = 5 }, 5)
            }),

                CreatePlayerTurn(new List<DiceThrow>()
            {
                CreateDiceThrow(6, null, 11),
                CreateDiceThrow(2, new LadderStep(){ StepFrom = 13, StepTo = 46 }, 46)
            }),

                CreatePlayerTurn(new List<DiceThrow>()
            {
                CreateDiceThrow(6, null, 52),
                CreateDiceThrow(6, null, 58),
                CreateDiceThrow(4, new LadderStep(){ StepFrom = 62, StepTo = 81 }, 81)
            })
            };

            var player = new Player(byte.MaxValue)
            {
                PlayerTurns = playerTurns
            };

            //Act
            var playerStatistic = player.GenerateGameStatistic(Constants.defaultSnakeSteps, Constants.defaultLadderSteps);

            //Assert
            Assert.AreEqual(expectedBiggestClimbInASingleTurn, playerStatistic.BiggestClimbInASingleTurn);

        }

        [Test]
        public void GenerateGameStatistic_ValidateBiggestSlideInASingleTurn_ExpectedBiggestSlideInASingleTurnMatch()
        {
            //Arrange
            int expectedBiggestSlideInASingleTurn = (27 - 5);

            var playerTurns = new List<PlayerTurn>
            {
                CreatePlayerTurn(new List<DiceThrow>()
            {
                CreateDiceThrow(4, new LadderStep() { StepFrom = 4, StepTo = 25 }, 25)
            }),

                CreatePlayerTurn(new List<DiceThrow>()
            {
                CreateDiceThrow(2, new SnakeStep(){ StepFrom = 27, StepTo = 5 }, 5)
            }),

                CreatePlayerTurn(new List<DiceThrow>()
            {
                CreateDiceThrow(6, null, 11),
                CreateDiceThrow(2, new LadderStep(){ StepFrom = 13, StepTo = 46 }, 46)
            }),

                CreatePlayerTurn(new List<DiceThrow>()
            {
                CreateDiceThrow(6, null, 52),
                CreateDiceThrow(6, null, 58),
                CreateDiceThrow(2, new SnakeStep(){ StepFrom = 66, StepTo = 45 }, 45)
            })
            };

            var player = new Player(byte.MaxValue)
            {
                PlayerTurns = playerTurns
            };

            //Act
            var playerStatistic = player.GenerateGameStatistic(Constants.defaultSnakeSteps, Constants.defaultLadderSteps);

            //Assert
            Assert.AreEqual(expectedBiggestSlideInASingleTurn, playerStatistic.BiggestSlideInASingleTurn);

        }

        [Test]
        public void GenerateGameStatistic_ValidateLongestTurn_ExpectedLongestTurnMatch()
        {
            //Arrange
            var expectedLongestTurn = new int[] { 6, 6, 6, 2 };

            var playerTurns = new List<PlayerTurn>
            {
                CreatePlayerTurn(new List<DiceThrow>()
            {
                CreateDiceThrow(4, new LadderStep() { StepFrom = 4, StepTo = 25 }, 25)
            }),

                CreatePlayerTurn(new List<DiceThrow>()
            {
                CreateDiceThrow(2, new SnakeStep(){ StepFrom = 27, StepTo = 5 }, 5)
            }),

                CreatePlayerTurn(new List<DiceThrow>()
            {
                CreateDiceThrow(6, null, 11),
                CreateDiceThrow(2, new LadderStep(){ StepFrom = 13, StepTo = 46 }, 46)
            }),

                CreatePlayerTurn(new List<DiceThrow>()
            {
                CreateDiceThrow(6, null, 52),
                CreateDiceThrow(6, null, 58),
                CreateDiceThrow(6, null, 64),
                CreateDiceThrow(2, new SnakeStep(){ StepFrom = 66, StepTo = 45 }, 45)
            })
            };

            var player = new Player(byte.MaxValue)
            {
                PlayerTurns = playerTurns
            };

            //Act
            var playerStatistic = player.GenerateGameStatistic(Constants.defaultSnakeSteps, Constants.defaultLadderSteps);

            //Assert
            Assert.AreEqual(expectedLongestTurn, playerStatistic.LongestTurn);

        }

        [Test]
        public void GenerateGameStatistic_ValidateMinimumUnluckyRolls_ExpectedMinimumUnluckyRollsMatch()
        {
            //Arrange
            var expectedMinimumUnluckyRolls = 2;

            var playerTurns = new List<PlayerTurn>
            {
                CreatePlayerTurn(new List<DiceThrow>()
            {
                CreateDiceThrow(4, new LadderStep() { StepFrom = 4, StepTo = 25 }, 25)
            }),

                CreatePlayerTurn(new List<DiceThrow>()
            {
                CreateDiceThrow(2, new SnakeStep(){ StepFrom = 27, StepTo = 5 }, 5)
            }),

                CreatePlayerTurn(new List<DiceThrow>()
            {
                CreateDiceThrow(6, null, 11),
                CreateDiceThrow(2, new LadderStep(){ StepFrom = 13, StepTo = 46 }, 46)
            }),

                CreatePlayerTurn(new List<DiceThrow>()
            {
                CreateDiceThrow(6, null, 52),
                CreateDiceThrow(6, null, 58),
                CreateDiceThrow(6, null, 64),
                CreateDiceThrow(2, new SnakeStep(){ StepFrom = 66, StepTo = 45 }, 45)
            })
            };

            var player = new Player(byte.MaxValue)
            {
                PlayerTurns = playerTurns
            };

            //Act
            var playerStatistic = player.GenerateGameStatistic(Constants.defaultSnakeSteps, Constants.defaultLadderSteps);

            //Assert
            Assert.AreEqual(expectedMinimumUnluckyRolls, playerStatistic.MinimumUnluckyRolls);

        }

        [Test]
        public void GenerateGameStatistic_ValidateMinimumLuckyRolls_ExpectedMinimumLuckyRollsMatch()
        {
            //Arrange
            var expectedMinimumLuckyRolls = 6;

            var playerTurns = new List<PlayerTurn>
            {
                CreatePlayerTurn(new List<DiceThrow>()
            {
                CreateDiceThrow(4, new LadderStep() { StepFrom = 4, StepTo = 25 }, 25)
            }, 25, 0),

                CreatePlayerTurn(new List<DiceThrow>()
            {
                CreateDiceThrow(4, null, 29) // Close call
            }, 29, 25),

                CreatePlayerTurn(new List<DiceThrow>()
            {
                CreateDiceThrow(6, null, 35),
                CreateDiceThrow(6, null, 41), //?
                CreateDiceThrow(1, new LadderStep(){ StepFrom = 42, StepTo = 63 }, 63) // Close call
            }, 63, 29),

                CreatePlayerTurn(new List<DiceThrow>()
            {
                CreateDiceThrow(6, null, 69),
                CreateDiceThrow(6, null, 75),
                CreateDiceThrow(6, null, 81),
                CreateDiceThrow(6, null, 87),
                CreateDiceThrow(6, null, 93),
                CreateDiceThrow(1, null, 94), // Close call               
            }, 94, 63),

                CreatePlayerTurn(new List<DiceThrow>()
            {
                CreateDiceThrow(6, null, 100)
            }, 100, 94)
            };

            var player = new Player(byte.MaxValue)
            {
                PlayerTurns = playerTurns
            };

            //Act
            var playerStatistic = player.GenerateGameStatistic(Constants.defaultSnakeSteps, Constants.defaultLadderSteps);

            //Assert
            Assert.AreEqual(expectedMinimumLuckyRolls, playerStatistic.MinimumLuckyRolls);

        }

        DiceThrow CreateDiceThrow(int turnValue, Step? step, int landPosition)
        {
            var diceThrow = new DiceThrow();
            diceThrow.InsertDiceValue(turnValue, step, landPosition);

            return diceThrow;
        }

        PlayerTurn CreatePlayerTurn(List<DiceThrow> diceThrows, int position = 0, int previousPosition = 0)
        {
            var turn = new PlayerTurn();
            turn.DiceThrows.AddRange(diceThrows);
            turn.Position = position;
            turn.PreviousTurnPosition = previousPosition;
            return turn;
        }

    }
}
