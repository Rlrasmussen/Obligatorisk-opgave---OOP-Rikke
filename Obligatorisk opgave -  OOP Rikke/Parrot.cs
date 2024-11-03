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

        #region property


        #endregion

        #region constructor
        public Parrot(MainWindow mainWindow) : base(FoodTypes.Sugar, mainWindow)
        {
        }
        #endregion

        #region method
        //public override void Eat(FoodTypes food)
        public override void Eat(FoodTypes food)
        {
            base.Eat(food);
            if (food == Diet)
            {
                this.mainWindow.SetLabelOutput($"The parrot is eating {food} and it's mood is {Mood}");
            }
            if (food != Diet)
            {
                this.mainWindow.SetLabelOutput($"The parrot don't like {food} and it's mood is now {Mood}");
            }
            if (MoodLevels.Happy == Mood)
            {
                this.mainWindow.SetLabelOutput($"The parrot is not hungry anymore");
            }
        }

        public override void PetAnimal()
        {
            this.mainWindow.SetLabelOutput($"The parrot sqwuaks");
        }

        #endregion
    }
}
