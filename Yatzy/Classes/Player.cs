using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using static System.Formats.Asn1.AsnWriter;

namespace Yatzy.Classes
{
    public class Player
    {
        public string Name;
        public int Score = 0;
        public int Sum = 0;
        public int Bonus = 0;
        public int Number;
        public int RoundScore;

        public bool Ones = false;
        public int OnesScore;
        public bool Twos = false;
        public int TwosScore;
        public bool Threes = false;
        public int ThreesScore;
        public bool Fours = false;
        public int FoursScore;
        public bool Fives = false;
        public int FivesScore;
        public bool Sixes = false;
        public int SixesScore;
        public bool OnePair = false;
        public int OnePairScore;
        public bool TwoPaires = false;
        public int TwoPairesScore;
        public bool ThreeOfTheSame = false;
        public int ThreeOfTheSameScore;
        public bool FourOfTheSame = false;
        public int FourOfTheSameScore;
        public bool House = false;
        public int HouseScore;
        public bool SmallStraight = false;
        public int SmallStraightScore;
        public bool BigStraight = false;
        public int BigStraightScore;
        public bool Chance = false;
        public int ChanceScore;
        public bool Yatzy = false;
        public int YatzyScore = 0;

        public readonly List<int> DieValues = [];
        public Player(string Name, int Number)
        {
            this.Name = Name;
            this.Number = Number;
        }

        public void ChooseCombination()
        {
            var found = false;
            while (found==false)
            {
                Console.WriteLine("vælg en kombination!");
                string choosenCombination = Console.ReadLine();

                int numberOfOnes = 0;
                int numberOfTwoes = 0;
                int numberOfThrees = 0;
                int numberOfFoures = 0;
                int numberOfFives = 0;
                int numberOfSixes = 0;

                foreach (int value in DieValues)
                {
                    if (value == 1)
                    {
                        numberOfOnes++;
                    }
                    else if (value == 2)
                    {
                        numberOfTwoes++;
                    }
                    else if (value == 3)
                    {
                        numberOfThrees++;
                    }
                    else if (value == 4)
                    {
                        numberOfFoures++;
                    }
                    else if (value == 5)
                    {
                        numberOfFives++;
                    }
                    else if (value == 6)
                    {
                        numberOfSixes++;
                    }
                }

                //Almindelige
                if (choosenCombination == "enere" || choosenCombination == "a")
                {
                    found = CombinationResolver.GetOnesScore(this, numberOfOnes);
                }
                else if (choosenCombination == "toere" || choosenCombination == "b")
                {
                    found = CombinationResolver.GetTwosScore(this, numberOfTwoes);
                }
                else if (choosenCombination == "treere" || choosenCombination == "c")
                {
                    found = CombinationResolver.GetThreesScore(this, numberOfThrees);
                }
                else if (choosenCombination == "firere" || choosenCombination == "d")
                {
                    found = CombinationResolver.GetFoursScore(this, numberOfFoures);
                }
                else if (choosenCombination == "femere" || choosenCombination == "e")
                {
                    found = CombinationResolver.GetFivesScore(this, numberOfFives);
                }
                else if (choosenCombination == "seksere" || choosenCombination == "f")
                {
                    found = CombinationResolver.GetSixesScore(this, numberOfSixes);
                }

                //kombinationer
                //Et par:To terninger med samme værdi.Summen af terningerne.
                else if (choosenCombination == "et par" || choosenCombination == "g")
                {
                    found = CombinationResolver.GetOnePairScore(this, numberOfOnes, numberOfTwoes, numberOfThrees, numberOfFoures, numberOfFives, numberOfSixes);
                }
                //To par:To forskellige par. Summen af terningerne. 
                else if (choosenCombination == "to par" || choosenCombination == "h")
                {
                    found = CombinationResolver.GetTwoPairesScore(this, numberOfOnes, numberOfTwoes, numberOfThrees, numberOfFoures, numberOfFives, numberOfSixes);
                }
                //Tre ens:Tre terninger med samme værdi. Summen af terningerne.
                else if (choosenCombination == "tre ens" || choosenCombination == "i")
                {
                    found = CombinationResolver.GetThreeOfTheSameScore(this, numberOfOnes, numberOfTwoes, numberOfThrees, numberOfFoures, numberOfFives, numberOfSixes);
                }
                //Fire ens:Fire terninger med samme værdi. Summen af terningerne.
                else if (choosenCombination == "fire ens" || choosenCombination == "j")
                {
                    found = CombinationResolver.GetFourOfTheSameScore(this, numberOfOnes, numberOfTwoes, numberOfThrees, numberOfFoures, numberOfFives, numberOfSixes);
                }
                //hus tre ens samtidigt med et andet par
                else if (choosenCombination == "hus" || choosenCombination == "k")
                {
                    found = CombinationResolver.GetHouseScore(this, numberOfOnes, numberOfTwoes, numberOfThrees, numberOfFoures, numberOfFives, numberOfSixes);
                }
                //Lille straight:Fem terninger i rækkefølge fra 1 til 5. 15 point.
                else if (choosenCombination == "lille" || choosenCombination == "l")
                {
                    found = CombinationResolver.GetSmallStraightScore(this, numberOfOnes, numberOfTwoes, numberOfThrees, numberOfFoures, numberOfFives);
                }
                //Stor straight:Fem terninger i rækkefølge fra 2 til 6. 20 point.
                else if (choosenCombination == "stor" || choosenCombination == "m")
                {
                    found = CombinationResolver.GetBigStraightScore(this, numberOfTwoes, numberOfThrees, numberOfFoures, numberOfFives, numberOfSixes);
                }
                //Chancen:Summen af alle fem terninger.
                else if (choosenCombination == "chance" || choosenCombination == "n")
                {
                    found = CombinationResolver.GetChanceScore(this);
                }
                //Yatzy:Fem terninger med samme værdi. 50 point
                else if (choosenCombination == "Yatzy" || choosenCombination == "o")
                {
                    found = CombinationResolver.GetYatzyScore(this, numberOfOnes, numberOfTwoes, numberOfThrees, numberOfFoures, numberOfFives, numberOfSixes);
                }
            }

            this.CalculateScore();
        }


        //udregn score 
        private void CalculateScore()
        {
            Sum = OnesScore + TwosScore + ThreesScore + FoursScore + FivesScore + SixesScore;
            if (Sum > 93) { Bonus = 100; }
            else if (Sum > 63) { Bonus = 63; }
            int oldScore = Score;
            Score = OnesScore + TwosScore + ThreesScore + FoursScore + FivesScore + SixesScore + OnePairScore + TwoPairesScore + ThreeOfTheSameScore + FourOfTheSameScore + HouseScore + SmallStraightScore + BigStraightScore + ChanceScore + YatzyScore + Bonus;
            RoundScore = Score - oldScore;
        }
    }
}
