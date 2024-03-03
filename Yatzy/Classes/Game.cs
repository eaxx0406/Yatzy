using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Yatzy.Classes
{
    internal class Game
    {
        private List<Player> playersList = new List<Player>();
        private Scoreboard scoreboard;
        public Game(List<Player> players, Scoreboard scoreboard)
        {
            playersList = players;
            this.scoreboard = scoreboard;
        }

        public void PlayGame()
        {

            List<Die> diceList = new List<Die>();
            // 5 terninger 
            Die dice1 = new Die(1);
            Die dice2 = new Die(2);
            Die dice3 = new Die(3);
            Die dice4 = new Die(4);
            Die dice5 = new Die(5);

            //rundekontrol
            int round = 1;
            while (round <= 14)
            {

                //player controller
                foreach (Player player in playersList)
                {
                    dice1.Saved = false;
                    dice2.Saved = false;
                    dice3.Saved = false;
                    dice4.Saved = false;
                    dice5.Saved = false;
                    // player takes turn and rolls dice
                    Console.Clear();
                    scoreboard.DrawScoreboard(playersList);
                    Console.WriteLine("Runde: " + round);
                    Console.WriteLine("Nu er det " + player.Name + "s tur");
                    int tries = 1;
                    while (tries <= 3)
                    {
                        diceList.Clear();

                        if (dice1.Saved == false) { dice1.Roll(); }
                        diceList.Add(dice1);

                        if (dice2.Saved == false) { dice2.Roll(); }
                        diceList.Add(dice2);

                        if (dice3.Saved == false) { dice3.Roll(); }
                        diceList.Add(dice3);

                        if (dice4.Saved == false) { dice4.Roll(); }
                        diceList.Add(dice4);

                        if (dice5.Saved == false) { dice5.Roll(); }
                        diceList.Add(dice5);
                        Console.Clear();
                        scoreboard.DrawScoreboard(playersList);
                        Console.WriteLine("Runde: " + round);
                        Console.WriteLine("Nu er det " + player.Name + "s tur");
                        Console.WriteLine("Tryk på Enter for at kaste terningerne");
                        Console.ReadKey();
                        Console.WriteLine("Terningerne er kastet. Øjnene viser...");
                        Console.WriteLine(GenerateDices(diceList));
                        Console.WriteLine("    1          2          3          4          5");
                        Console.WriteLine();

                        //ønsker spiller at beholde terninger? (maks 3 slag ialt)
                        if (tries < 3)
                        {
                            Console.WriteLine("hvilke terninger vil du slå om? ");
                            string tryAgainDicesString = Console.ReadLine();
                            if (string.IsNullOrWhiteSpace(tryAgainDicesString)) { tries = 3; }
                            if (tryAgainDicesString.Contains("1") == false) { dice1.Saved = true; }
                            if (tryAgainDicesString.Contains("2") == false) { dice2.Saved = true; }
                            if (tryAgainDicesString.Contains("3") == false) { dice3.Saved = true; }
                            if (tryAgainDicesString.Contains("4") == false) { dice4.Saved = true; }
                            if (tryAgainDicesString.Contains("5") == false) { dice5.Saved = true; }
                        }
                        tries = tries + 1;
                    }
                    player.DieValues.Clear();
                    foreach (var dice in diceList)
                    {
                        player.DieValues.Add(dice.Eyes);
                    }

                    player.ChooseCombination();

                    Console.WriteLine(player.Name + " har fået  " + player.RoundScore + " point");
                    Console.ReadKey();
                    Console.Clear();
                }
                round++;

            }

        }

        static string GenerateDices(List<Die> dice)
        {

            var diceArt = new[]
            {
                "┌───────┐", "│       │", "│   ●   │", "│       │", "└───────┘",
                "┌───────┐", "│●      │", "│       │", "│      ●│", "└───────┘",
                "┌───────┐", "│●      │", "│   ●   │", "│      ●│", "└───────┘",
                "┌───────┐", "│●     ●│", "│       │", "│●     ●│", "└───────┘",
                "┌───────┐", "│●     ●│", "│   ●   │", "│●     ●│", "└───────┘",
                "┌───────┐", "│●     ●│", "│●     ●│", "│●     ●│", "└───────┘",
            };

            StringBuilder[] lines = new StringBuilder[5];

            for (int i = 0; i < lines.Length; i++)
            {
                lines[i] = new StringBuilder();
            }

            foreach (var die in dice)
            {
                for (int j = 0; j < 5; j++)
                {
                    lines[j].Append(diceArt[(die.Eyes - 1) * 5 + j]);
                    lines[j].Append("  ");
                }
            }

            var diceString = string.Join("\n", lines.Select(b => b.ToString())); ;

            return diceString;
        }





    }
}
