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

        #region property


        #endregion

        #region constructor
        public Monkey(MainWindow mainWindow) : base (FoodTypes.Banana, mainWindow)
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
                this.mainWindow.SetLabelOutput($"The monkey ís eating {food} and it's mood is {Mood}");
            }
            if (food != Diet)
            {
                this.mainWindow.SetLabelOutput($"The monkey don't like {food} and it's mood is now {Mood}");
            }

        }

        public override void PetAnimal()
        {
            this.mainWindow.SetLabelOutput($"The monkey says uh uh ah ah");
        }

        #endregion

    }
}
