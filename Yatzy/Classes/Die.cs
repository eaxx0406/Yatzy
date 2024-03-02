using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Yatzy.Classes
{
    public class Die
    {
        public int ID;
        public int Eyes;
        public bool Saved = false;


        public Die(int ID) { this.ID = ID; }

        public int GetDiceEyes()
        {
            return Eyes;
        }

        public void Roll()
        {
            Random rnd = new Random();
            int num = rnd.Next(1, 7);
            Eyes = num;
        }

    }
}
