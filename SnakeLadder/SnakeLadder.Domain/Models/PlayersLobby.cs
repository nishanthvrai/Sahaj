namespace SnakeLadder.Domain.Models
{
    internal class PlayersLobby
    {
        private readonly int capacity;

        public List<Player> Players { get; private set; } = new List<Player>();

        private int activePlayer = -1;

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

        public Player GetNextPlayer()
        {
            if(activePlayer == -1 || activePlayer == Players.Count)
            {
                activePlayer = 0;
            }
            return Players[activePlayer++];
        }

    }
}
