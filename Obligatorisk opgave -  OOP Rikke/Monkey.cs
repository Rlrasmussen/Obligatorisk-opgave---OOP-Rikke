using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Documents;

namespace Obligatorisk_opgave____OOP_Rikke
{
    internal class Monkey : Animal
    {
        #region field

        #endregion

        #region porporty


        #endregion

        #region constructor
        public Monkey(string name, FoodTypes food, MoodLevels hunger) : base (name, food, hunger)
        {
            base.Name = name;
            base.Diet = food;
            base.Mood = hunger;
        }
        #endregion

        #region method
        //public override void Eat(FoodTypes food)
        public override void Eat(FoodTypes food)
        {
            base.Eat(food);
            if (food == Diet)
            {
                
            }
        }

        #endregion

    }
}
