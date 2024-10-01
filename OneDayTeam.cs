using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace phase1project
{
    class OneDayTeam : ITeam

    {
        public static List<Player> oneDayTeam = new List<Player>();
        public const int MaxCapacity = 11;

        public OneDayTeam() {
            oneDayTeam.Add(new Player { PlayerId = 01, PlayerName = "Sachin", PlayerAge = 28 });
            oneDayTeam.Add(new Player { PlayerId = 02, PlayerName = "Rohit", PlayerAge = 24 });
            oneDayTeam.Add(new Player { PlayerId = 03, PlayerName = "Rahul", PlayerAge = 25 });
            oneDayTeam.Add(new Player { PlayerId = 04, PlayerName = "Aman", PlayerAge = 23 });
            oneDayTeam.Add(new Player { PlayerId = 05, PlayerName = "Puneet", PlayerAge = 20 });
            oneDayTeam.Add(new Player { PlayerId = 06, PlayerName = "Manoj", PlayerAge = 22 });
        }

        public void Add(Player player)
        {
            if (oneDayTeam.Count < MaxCapacity)
            {
                oneDayTeam.Add(player);
                Console.WriteLine($"{player.PlayerName} is added to the team.");
            }
            else
            {
                Console.WriteLine("Team can only have 11 players. Cannot add more.");
            }
        }

        public void Remove(int playerId)
        {
            Player playerToRemove = oneDayTeam.Find(p => p.PlayerId == playerId);

            if (playerToRemove != null)
            {
                oneDayTeam.Remove(playerToRemove);
                Console.WriteLine($"{playerToRemove.PlayerName} removed from the team.");
            }
            else
            {
                Console.WriteLine("Player not found in the team.");
            }
        }

        public Player GetPlayerById(int playerId) => oneDayTeam.Find(p => p.PlayerId == playerId);

        public Player GetPlayerByName(string playerName) =>
            oneDayTeam.Find(p => p.PlayerName.Equals(playerName, StringComparison.OrdinalIgnoreCase));

        public List<Player> GetAllPlayers() => oneDayTeam;
    }
}

