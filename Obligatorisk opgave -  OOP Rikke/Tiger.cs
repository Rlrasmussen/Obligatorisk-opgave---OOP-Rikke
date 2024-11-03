using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Obligatorisk_opgave____OOP_Rikke
{
    internal class Tiger : Animal
    {
        #region field

        #endregion

        #region porporty


        #endregion

        #region constructor
        public Tiger(MainWindow mainWindow) : base(FoodTypes.Meat, mainWindow, nameof(Tiger))
        {
            base.Icon = "🐅";
        }
        #endregion

        #region method
        //public override void Eat(FoodTypes food)
        public override void Eat(FoodTypes food)
        {
            base.Eat(food);
            if (food == Diet)
            {
                this.mainWindow.SetTextBlockOutput($"The tiger is eating {food} and it's mood is {Mood}");
            }
            if (food != Diet)
            {
                this.mainWindow.SetTextBlockOutput($"The tiger don't like {food} and it's mood is now {Mood}");
            }

        }

        public override void PetAnimal()
        {
            this.mainWindow.SetTextBlockOutput($"The tiger says pur pur");
        }

        #endregion
    }
}
