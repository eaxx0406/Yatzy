using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Channels;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace Yatzy.Classes
{
    internal class CombinationResolver
    {
        public static bool GetOnesScore(Player player, int numberOfOnes)
        {
            if (player.Ones == false)
            {
                player.OnesScore = numberOfOnes;
                player.Ones = true;
                return true;
            }
            else
            {
                Console.WriteLine("Du har allerede brugt enerne");
                return false;
            }
        }
        public static bool GetTwosScore(Player player, int numberOfTwoes)
        {
            if (player.Twos == false)
            {
                player.TwosScore = numberOfTwoes * 2;
                player.Twos = true;
                return true;
            }
            else
            {
                Console.WriteLine("Du har allerede brugt toerne");
                return false;
            }
        }
        public static bool GetThreesScore(Player player, int numberOfThrees)
        {
            if (player.Threes == false)
            {
                player.ThreesScore = numberOfThrees * 3;
                player.Threes = true;
                return true;
            }
            else
            {
                Console.WriteLine("Du har allerede brugt treerne");
                return false;
            }
        }

        public static bool GetFoursScore(Player player, int numberOfFoures)
        {
            if (player.Fours == false)
            {
                player.FoursScore = numberOfFoures * 4;
                player.Fours = true;
                return true;
            }
            else
            {
                Console.WriteLine("Du har allerede brugt fireerne");
                return false;
            }
        }

        public static bool GetFivesScore(Player player, int numberOfFives)
        {
            if (player.Fives == false)
            {
                player.FivesScore = numberOfFives * 5;
                player.Fives = true;
                return true;
            }
            else
            {
                Console.WriteLine("Du har allerede brugt femerne");
                return false;
            }
        }
        public static bool GetSixesScore(Player player, int numberOfSixes)
        {
            if (player.Sixes == false)
            {
               player.SixesScore = numberOfSixes * 6;
               player.Sixes = true;
               return true;
            }
            else
            { 
                Console.WriteLine("Du har allerede brugt sekserne");
                return false;
            }
        }

        public static bool GetOnePairScore(Player player, int numberOfOnes, int numberOfTwoes, int numberOfThrees, int numberOfFoures, int numberOfFives, int numberOfSixes)
        {
            if (player.OnePair == false)
            {
                if (numberOfSixes >= 2)
                {
                    player.OnePairScore = 6 * 2;
                }
                else if (numberOfFives >= 2)
                {
                    player.OnePairScore = 5 * 2;
                }
                else if (numberOfFoures >= 2)
                {
                    player.OnePairScore = 4 * 2;
                }
                else if (numberOfThrees >= 2)
                {
                    player.OnePairScore = 3 * 2;
                }
                else if (numberOfTwoes >= 2)
                {
                    player.OnePairScore = 2 * 2;
                }
                else if (numberOfOnes >= 2)
                {
                    player.OnePairScore = 1 * 2;
                }
                else
                {
                    Console.WriteLine("har ikke fundet et par du får 0 point");
                }

                player.OnePair = true;
                return true;
            }
            else 
            { 
                Console.WriteLine("Du har allerede dannet et par");
                return false;
            }
        }
        public static bool GetTwoPairesScore(Player player, int numberOfOnes, int numberOfTwoes, int numberOfThrees, int numberOfFoures, int numberOfFives, int numberOfSixes)
        {
            if (player.TwoPaires == false)
            {
                int numberOfPaires = 0;
                if (numberOfSixes >= 2 && numberOfPaires < 2)
                {
                    player.TwoPairesScore = player.TwoPairesScore + (6 * 2);
                    numberOfPaires++;
                }

                if (numberOfFives >= 2 && numberOfPaires < 2)
                {
                    player.TwoPairesScore = player.TwoPairesScore + (5 * 2);
                    numberOfPaires++;
                }

                if (numberOfFoures >= 2 && numberOfPaires < 2)
                {
                    player.TwoPairesScore = player.TwoPairesScore + (4 * 2);
                    numberOfPaires++;
                }

                if (numberOfThrees >= 2 && numberOfPaires < 2)
                {
                    player.TwoPairesScore = player.TwoPairesScore + (3 * 2);
                    numberOfPaires++;
                }

                if (numberOfTwoes >= 2 && numberOfPaires < 2)
                {
                    player.TwoPairesScore = player.TwoPairesScore + (2 * 2);
                    numberOfPaires++;
                }

                if (numberOfOnes >= 2 && numberOfPaires < 2)
                {
                    player.TwoPairesScore = player.TwoPairesScore + (1 * 2);
                    numberOfPaires++;
                }
                else if (numberOfPaires < 2)
                {
                    Console.WriteLine("har ikke fundet to par");
                }

                player.TwoPaires = true;
                return true;
            }
            else 
            { 
                Console.WriteLine("Du har allerede dannet et par");
                return false;
            }
        }

        public static bool GetThreeOfTheSameScore(Player player, int numberOfOnes, int numberOfTwoes, int numberOfThrees, int numberOfFoures, int numberOfFives, int numberOfSixes)
        {
            if (player.ThreeOfTheSame == false)
            {
                if (numberOfSixes >= 3)
                {
                   player.ThreeOfTheSameScore = 6 * 3;
                }
                else if (numberOfFives >= 3)
                {
                    player.ThreeOfTheSameScore = 5 * 3;
                }
                else if (numberOfFoures >= 3)
                {
                    player.ThreeOfTheSameScore = 4 * 3;
                }
                else if (numberOfThrees >= 3)
                {
                    player.ThreeOfTheSameScore = 3 * 3;
                }
                else if (numberOfTwoes >= 3)
                {
                    player.ThreeOfTheSameScore = 2 * 3;
                }
                else if (numberOfOnes >= 3)
                {
                    player.ThreeOfTheSameScore = 1 * 3;
                }
                else
                {
                    Console.WriteLine("har ikke fundet 3 ens");
                }

                player.ThreeOfTheSame = true;
                return true;
            }
            else 
            {
                Console.WriteLine("Du har allerede fundet 3 ens");
                return false;
            }
        }

        //Fire ens:Fire terninger med samme værdi. Summen af terningerne.
        public static bool GetFourOfTheSameScore(Player player, int numberOfOnes, int numberOfTwoes, int numberOfThrees, int numberOfFoures, int numberOfFives, int numberOfSixes)
        {
            if (player.FourOfTheSame == false)
            {
                if (numberOfSixes >= 4)
                {
                    player.FourOfTheSameScore = 6 * 4;
                }
                else if (numberOfFives >= 4)
                {
                    player.FourOfTheSameScore = 5 * 4;
                }
                else if (numberOfFoures >= 4)
                {
                    player.FourOfTheSameScore = 4 * 4;
                }
                else if (numberOfThrees >= 4)
                {
                    player.FourOfTheSameScore = 3 * 4;
                }
                else if (numberOfTwoes >= 4)
                {
                    player.FourOfTheSameScore = 2 * 4;
                }
                else if (numberOfOnes >= 4)
                {
                    player.FourOfTheSameScore = 1 * 4;
                }
                else
                {
                    Console.WriteLine("har ikke fundet 4 ens");
                }

                player.FourOfTheSame = true;
                return true;
            }
            else 
            { 
                Console.WriteLine("Du har allerede fundet 4 ens ");
                return false;
            }
        }
        //Lille straight:Fem terninger i rækkefølge fra 1 til 5. 15 point.
        public static bool GetSmallStraightScore(Player player, int numberOfOnes, int numberOfTwoes, int numberOfThrees, int numberOfFoures, int numberOfFives)
        {
            if (player.SmallStraight == false)
            {
                if (numberOfOnes == 1 && numberOfTwoes == 1 && numberOfThrees == 1 && numberOfFoures == 1 &&
                    numberOfFives == 1)
                {
                    player.SmallStraightScore = 15;
                }
                else
                {
                    Console.WriteLine("du har desværre ikke til at bygge et hus og får 0 point...");
                }

                player.SmallStraight = true;
                return true;
            }
            else
            {
                Console.WriteLine("Du har allerede lavet lille straight");
                return false;
            }
        }
        //Stor straight:Fem terninger i rækkefølge fra 2 til 6. 20 point.
        public static bool GetBigStraightScore(Player player, int numberOfTwoes, int numberOfThrees, int numberOfFoures, int numberOfFives, int numberOfSixes)
        {
            if (player.BigStraight == false)
            {
                if (numberOfTwoes == 1 && numberOfThrees == 1 && numberOfFoures == 1 && numberOfFives == 1 &&
                    numberOfSixes == 1)
                {
                    player.BigStraightScore = 20;
                }
                else
                {
                    Console.WriteLine("du har desværre ikke til at bygge et hus og får 0 point...");
                }

                player.BigStraight = true;
                return true;
            }
            else 
            { 
                Console.WriteLine("Du har allerede lavet stor straight");
                return false;
            }
        }
        //Chancen:Summen af alle fem terninger.
        public static bool GetChanceScore(Player player)
        {
            if (player.Chance == false)
            {
                foreach (int value in player.DieValues)
                {
                    player.ChanceScore = player.ChanceScore + value;
                }

                player.Chance = true;
                return true;
            }
            else 
            { 
                Console.WriteLine("Du har allerede brugt chancen");
                return false;
            }
        }

        public static bool GetYatzyScore(Player player, int numberOfOnes, int numberOfTwoes, int numberOfThrees, int numberOfFoures, int numberOfFives, int numberOfSixes)
        {
            if (player.Yatzy == false)
            {
                if (numberOfOnes == 5 || numberOfTwoes == 5 || numberOfThrees == 5 || numberOfFoures == 5 ||
                    numberOfFives == 5 || numberOfSixes == 5)
                {
                    player.YatzyScore = 50;
                }
                else
                {
                    Console.WriteLine("Du har desværre ikke yatzy og får 0 point");
                }

                player.Yatzy = true;
                return true;
            }
            else
            { 
                Console.WriteLine("Du har allerede brugt yatzy");
                return false;
            }
        }
    }

}


