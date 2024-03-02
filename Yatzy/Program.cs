using System.Collections.Generic;
using System.Numerics;
using System.Text;
using System.Xml.Linq;
using Yatzy.Classes;
using static System.Formats.Asn1.AsnWriter;

namespace Yatzy
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8;
            
            Console.Clear();

            //velkomst
            Console.WriteLine("Velkommen til gruppe 4s Yatzy spil");
            Console.WriteLine("Husk at maksimere konsollen!!");


            var playersList = GetPlayers();

            //lav scoreboard 
            Scoreboard scoreboard = new Scoreboard();

            var newGame = new Game(playersList, scoreboard);

            //afslut spil
            var winner = playersList.OrderByDescending(x => x.Score).First();
            Console.WriteLine("Spillet er slut");
            Console.WriteLine($"Vinderen er: {winner.Name}");
            new Game(playersList, scoreboard).PlayGame();
            Console.WriteLine();
            foreach (Player player in playersList.OrderByDescending(x => x.Score))
            {
                Console.WriteLine(player.Name + " har en score på " + player.Score);

            }
        }
        static List<Player> GetPlayers()
        {
            var playersNeedAdding = true;
            var maxPlayer = 5;
            var playerCount = 1;
            var players = new List<Player>();
            while (playersNeedAdding && playerCount <= maxPlayer)
            {
                Console.WriteLine($"Indtast spiller {playerCount}:");
                string playerName = Console.ReadLine();

                if (string.IsNullOrWhiteSpace(playerName) == true && playerCount >= 2)
                {
                    playersNeedAdding = false;
                }
                else if (string.IsNullOrWhiteSpace(playerName) == true && playerCount == 0)
                {
                    Console.WriteLine("Du skal indtaste minimum to spillernavne");
                }
                else if (string.IsNullOrWhiteSpace(playerName) == false)
                {
                    Player player = new Player(playerName, playerCount);
                    players.Add(player);
                    playerCount++;
                }
                if (playerCount > 2) { Console.WriteLine("tryk Enter for at afslutte registering"); }
            }
            Console.Clear();
            return players;
        }

    }
}
