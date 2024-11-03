using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Obligatorisk_opgave____OOP_Rikke
{
    internal class Parrot : Animal
    {
        #region field

        #endregion

        #region porporty


        #endregion

        #region constructor
        public Parrot(FoodTypes food, MoodLevels hunger) : base(food, hunger)
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
                MainWindow.SetLabelOutput($"The parrot is eating {food} and it's mood is {Mood}");
            }
            if (food != Diet)
            {
                MainWindow.SetLabelOutput($"The parrot don't like {food} and it's mood is now {Mood}");
            }
            if (MoodLevels.Happy == Mood)
            {
                MainWindow.SetLabelOutput($"The parrot is not hungry anymore");
            }
        }

        public override void PetAnimal()
        {
            MainWindow.SetLabelOutput($"The parrot sqwuaks");
        }

        #endregion
    }
}
