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
        public Monkey(MainWindow mainWindow) : base (FoodTypes.Banana, mainWindow, nameof(Monkey))
        {
            base.Icon = "🐒";
        }

        #endregion

        #region method
        //// <summary>
        /// The monkey is eating the food. If the food is banana it will eat it and Moodlevel will rise else it will not eat and Moodlevel drop
        /// </summary>
        /// <param name="food">A food</param>
        public override void Eat(FoodTypes food)
        {
            base.Eat(food);
            if (food == Diet)
            {
                this.mainWindow.SetTextBlockOutput($"The monkey ís eating {food} and it's mood is {Mood}");
            }
            if (food != Diet)
            {
                this.mainWindow.SetTextBlockOutput($"The monkey don't like {food} and it's mood is now {Mood}");
            }
        }

        /// <summary>
        /// When the monkey gets petted of a zookeeper it will send a message
        /// </summary>
        public override void PetAnimal()
        {
            this.mainWindow.SetTextBlockOutput($"The monkey says uh uh ah ah");
        }

        #endregion

    }
}
