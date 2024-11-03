using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
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
        public Monkey(FoodTypes food, MoodLevels hunger) : base (food, hunger)
        {
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
                MainWindow.SetLabelOutput($"The monkey ís eating {food} and it's mood is {Mood}");
            }
            if (food != Diet)
            {
                MainWindow.SetLabelOutput($"The monkey don't like {food} and it's mood is now {Mood}");
            }

        }

        public override void PetAnimal()
        {
            MainWindow.SetLabelOutput($"The monkey says uh uh ah ah");
        }

        #endregion

    }
}
