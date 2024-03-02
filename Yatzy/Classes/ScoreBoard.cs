using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Yatzy.Classes
{
    public class Scoreboard
    {
        //scoreboard 
        //Lav scoreboard
        public void DrawScoreboard(List<Player> players)
        {
            int ColumnWidth = 20;

            //TOP linje
            Console.WriteLine("".PadRight((ColumnWidth + (ColumnWidth*players.Count)),'-'));

            // SpillerLinje
            Console.Write($"|Slag\\Spiller".PadRight(ColumnWidth));
            foreach (Player player in players)
            {
                Console.Write($"|{player.Name}".PadRight(ColumnWidth));
            }
            Console.WriteLine("|");

            Console.WriteLine("".PadRight((ColumnWidth + (ColumnWidth * players.Count)), '-'));

            // enere 
            Console.Write($"|a - enere".PadRight(ColumnWidth));
            foreach (Player player in players)
            {
                Console.Write($"|{player.OnesScore}".PadRight(ColumnWidth));
            }
            Console.WriteLine("|");

            // toere 
            Console.Write($"|b - toere".PadRight(ColumnWidth));
            foreach (Player player in players)
            {
                Console.Write($"|{player.TwosScore}".PadRight(ColumnWidth));
            }
            Console.WriteLine("|");

            // treere 
            Console.Write($"|c - treere".PadRight(ColumnWidth));
            foreach (Player player in players)
            {
                Console.Write($"|{player.ThreesScore}".PadRight(ColumnWidth));
            }
            Console.WriteLine("|");

            // firere 
            Console.Write($"|d - firere".PadRight(ColumnWidth));
            foreach (Player player in players)
            {
                Console.Write($"|{player.FoursScore}".PadRight(ColumnWidth));
            }
            Console.WriteLine("|");

            // femere 
            Console.Write($"|e - femere".PadRight(ColumnWidth));
            foreach (Player player in players)
            {
                Console.Write($"|{player.FivesScore}".PadRight(ColumnWidth));
            }
            Console.WriteLine("|");

            // seksere 
            Console.Write($"|f - seksere".PadRight(ColumnWidth));
            foreach (Player player in players)
            {
                Console.Write($"|{player.SixesScore}".PadRight(ColumnWidth));
            }
            Console.WriteLine("|");

            Console.WriteLine("".PadRight((ColumnWidth + (ColumnWidth * players.Count)), '-'));

            // sum 
            Console.Write($"|sum".PadRight(ColumnWidth));
            foreach (Player player in players)
            {
                Console.Write($"|{player.Sum}".PadRight(ColumnWidth));
            }
            Console.WriteLine("|");

            // BONUS 
            Console.Write($"|Bonus".PadRight(ColumnWidth));
            foreach (Player player in players)
            {
                Console.Write($"|{player.Bonus}".PadRight(ColumnWidth));
            }
            Console.WriteLine("|");

            Console.WriteLine("".PadRight((ColumnWidth + (ColumnWidth * players.Count)), '-'));

            // et par  
            Console.Write($"|g - et par".PadRight(ColumnWidth));
            foreach (Player player in players)
            {
                Console.Write($"|{player.OnePairScore}".PadRight(ColumnWidth));
            }
            Console.WriteLine("|");

            // to par  
            Console.Write($"|h - to par".PadRight(ColumnWidth));
            foreach (Player player in players)
            {
                Console.Write($"|{player.TwoPairesScore}".PadRight(ColumnWidth));
            }
            Console.WriteLine("|");

            // tre ens  
            Console.Write("|i - tre ens".PadRight(ColumnWidth));
            foreach (Player player in players)
            {
                Console.Write($"|{player.ThreeOfTheSameScore}".PadRight(ColumnWidth));
            }
            Console.WriteLine("|");

            // fire ens  
            Console.Write("|j - fire ens".PadRight(ColumnWidth));
            foreach (Player player in players)
            {
                Console.Write($"|{player.FourOfTheSameScore}".PadRight(ColumnWidth));
            }
            Console.WriteLine("|");

            // lille straight  
            Console.Write($"|k - lille straight".PadRight(ColumnWidth));
            foreach (Player player in players)
            {
                Console.Write($"|{player.SmallStraightScore}".PadRight(ColumnWidth));
            }
            Console.WriteLine("|");

            // stor straight  
            Console.Write($"|l - stor straight".PadRight(ColumnWidth));
            foreach (Player player in players)
            {
                Console.Write($"|{player.BigStraightScore}".PadRight(ColumnWidth));
            }
            Console.WriteLine("|");

            //chancen  
            Console.Write($"|m - chancen".PadRight(ColumnWidth));
            foreach (Player player in players)
            {
                Console.Write($"|{player.ChanceScore}".PadRight(ColumnWidth));
            }
            Console.WriteLine("|");

            // Yatzy  
            Console.Write($"|n - yatzy".PadRight(ColumnWidth));
            foreach (Player player in players)
            {
                Console.Write($"|{player.YatzyScore}".PadRight(ColumnWidth));
            }
            Console.WriteLine("|");

            Console.WriteLine("".PadRight((ColumnWidth + (ColumnWidth * players.Count)), '-'));

            // total  
            Console.Write($"|Total".PadRight(ColumnWidth));
            foreach (Player player in players)
            {
                Console.Write($"|{player.Score}".PadRight(ColumnWidth));
            }
            Console.WriteLine("|");

            Console.WriteLine("".PadRight((ColumnWidth + (ColumnWidth * players.Count)), '-'));
        }
    }
}
