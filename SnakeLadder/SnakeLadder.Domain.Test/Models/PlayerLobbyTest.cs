using NUnit.Framework;
using SnakeLadder.Domain.Models;

namespace SnakeLadder.Domain.Test.Models
{
    internal class PlayerLobbyTest
    {
        
        [Test]
        public void PlayersLobby_CreatePlayersOnInitialize_PlayersCreated()
        {
            //Arrange and Act
            int expectedPlayersCount = 25;
            var playersLobby = new PlayersLobby(25);

            //Assert
            Assert.AreEqual(expectedPlayersCount, playersLobby.Players.Count);
        }


        [Test]
        public void GetNextPlayer_FetchFirstElementAfterInitilaize_FirstPlayerSelected()
        {
            //Arrange
            int expectedPlayerId = 1;
            var playersLobby = new PlayersLobby(25);

            // Act
            var player = playersLobby.GetNextPlayer();

            //Assert
            Assert.AreEqual(expectedPlayerId, player.Id);
        }

        [Test]
        public void GetNextPlayer_FetchLastElementAfterInitilaize_LastPlayerSelected()
        {
            //Arrange
            int expectedPlayerId = 5;
            var playersLobby = new PlayersLobby(5);

            // Act
            playersLobby.GetNextPlayer();
            playersLobby.GetNextPlayer();
            playersLobby.GetNextPlayer();
            playersLobby.GetNextPlayer();
            var player = playersLobby.GetNextPlayer();


            //Assert
            Assert.AreEqual(expectedPlayerId, player.Id);
        }


        [Test]
        public void GetNextPlayer_DoNotReturnThePlayerWhoFinishedTheGame_PlayerWhoFinishedTheGameIsSkipped()
        {
            //Arrange
            int expectedPlayerId = 3;
            var playersLobby = new PlayersLobby(3);

            // Act
            var player1 = playersLobby.GetNextPlayer();
            player1.CurrentPosition = 100;

            var player2 = playersLobby.GetNextPlayer();
            player2.CurrentPosition = 100;

            var player3 = playersLobby.GetNextPlayer();

            var nextPlayer = playersLobby.GetNextPlayer();

            //Assert
            Assert.AreEqual(expectedPlayerId, nextPlayer.Id);
        }

        [Test]
        public void GetNextPlayer_Player3ShouldNotBeReturnedAfterWin_Player3IsNotReturnedAfterFinishingTheGame()
        {
            //Arrange
            int expectedPlayerId = 1;
            var playersLobby = new PlayersLobby(3);

            // Act
            playersLobby.GetNextPlayer();
            playersLobby.GetNextPlayer();

            var player3 = playersLobby.GetNextPlayer();
            player3.CurrentPosition = 100;

            playersLobby.GetNextPlayer();
            playersLobby.GetNextPlayer();

            var player = playersLobby.GetNextPlayer();

            //Assert
            Assert.AreEqual(expectedPlayerId, player.Id);
        }

        [Test]
        public void GetNextPlayer_ReturnNullWhenAllThePlayersFinishGame_ReturnNullForNextPlayer()
        {
            //Arrange
            Player? expectedPlayer = null;
            var playersLobby = new PlayersLobby(2);

            // Act
            var player1 = playersLobby.GetNextPlayer();
            player1.CurrentPosition = 100;
           
            var player2 = playersLobby.GetNextPlayer();
            player2.CurrentPosition = 100;

            var player = playersLobby.GetNextPlayer();

            //Assert
            Assert.AreEqual(expectedPlayer, player);
        }

    }
}
