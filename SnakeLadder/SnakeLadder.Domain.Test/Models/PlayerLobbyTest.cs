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

    }
}
