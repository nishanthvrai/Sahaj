namespace SnakeLadder.Domain.Models
{
    internal class PlayersLobby
    {
        private readonly int capacity;
        private int activePlayer = -1;

        public List<Player> Players { get; private set; } = new List<Player>();


        public PlayersLobby(int capacity)
        {
            this.capacity = capacity;
            CreatePlayers();
        }

        private void CreatePlayers()
        {
            for (int i = 1; i <= this.capacity; i++)
            {
                Players.Add(new Player(i));
            }
        }

        public Player? GetNextPlayer()
        {
            if (activePlayer == -1 || activePlayer == Players.Count)
            {
                activePlayer = 0;
            }

            var possibleNextPlayerIndex = activePlayer;
            do
            {
                if (Players[possibleNextPlayerIndex].CurrentPosition != 100)
                {
                    activePlayer = possibleNextPlayerIndex;
                    return Players[activePlayer++];
                }
                else
                { 
                    possibleNextPlayerIndex++;
                    possibleNextPlayerIndex = (possibleNextPlayerIndex == this.capacity)? 0 : possibleNextPlayerIndex;
                }

            } while (possibleNextPlayerIndex != activePlayer);

            return default;
        }

    }
}
