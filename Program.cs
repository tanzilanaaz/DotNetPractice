using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace phase1project
{
    class Program
    {
        static void Main(string[] args)
        {
            OneDayTeam team = new OneDayTeam();
            int choice;
            char ans = 'Y';
            do
            {
                Console.WriteLine("\nMenu: \nEnter a valid choice \nPress 1: To Add Player \nPress 2: To Remove Player by Id \nPress 3: Get Player By Id \nPress 4: Get Player by Name \nPress 5: Get All Players \nPress 0: Exit");
                choice =Convert.ToInt32(Console.ReadLine());
                switch (choice)
                {
                    case 1:
                        Console.WriteLine("Enter Player Details:");
                        Console.Write("Player Id: ");
                        int playerId = Convert.ToInt32(Console.ReadLine());

                        Console.Write("Player Name: ");
                        string playerName = Console.ReadLine();

                        Console.Write("Player Age: ");
                        int playerAge = Convert.ToInt32(Console.ReadLine());

                        Player newPlayer = new Player { PlayerId = playerId, PlayerName = playerName, PlayerAge = playerAge };
                        team.Add(newPlayer);
                        break;

                    case 2:
                        Console.Write("Enter Player Id to Remove: ");
                        int playerIdToRemove = Convert.ToInt32(Console.ReadLine());
                        team.Remove(playerIdToRemove);
                        break;

                    case 3:
                        Console.Write("Enter Player Id to Get: ");
                        int playerIdToGet = Convert.ToInt32(Console.ReadLine());
                        Player playerById = team.GetPlayerById(playerIdToGet);
                        if (playerById != null)
                            Console.WriteLine($"Player found: ID: {playerById.PlayerId}, Name: {playerById.PlayerName}, Age: {playerById.PlayerAge}");
                        else
                            Console.WriteLine("Player not found.");
                        break;

                    case 4:
                        Console.Write("Enter Player Name to Get: ");
                        string playerNameToGet = Console.ReadLine();
                        Player playerByName = team.GetPlayerByName(playerNameToGet);
                        if (playerByName != null)
                            Console.WriteLine($"Player found: ID: {playerByName.PlayerId}, Name: {playerByName.PlayerName}, Age: {playerByName.PlayerAge}");
                        else
                            Console.WriteLine("Player not found.");
                        break;

                    case 5:
                        List<Player> allPlayers = team.GetAllPlayers();
                        Console.WriteLine("All Players:");
                        foreach (var player in allPlayers)
                        {
                            Console.WriteLine($"ID: {player.PlayerId}, Name: {player.PlayerName}, Age: {player.PlayerAge}");
                        }
                        break;

                    case 0:
                        break;

                    default:
                        Console.WriteLine("Invalid choice. Please try again.");
                        break;
                }
                Console.WriteLine("Do you want to continue y/Y, n/N");
                ans = Convert.ToChar(Console.ReadLine());

            }while (choice != 0);
        }
    }
}


