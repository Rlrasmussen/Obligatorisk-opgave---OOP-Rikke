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

        #region property

        #endregion

        #region constructor
        /// <summary>
        /// In the construction of the Tiger it's diet and name is already set. 
        /// A tiger is eating meat and it's name is Tiger.
        /// </summary>
        /// <param name="mainWindow">A mianWindow</param>
        public Tiger(MainWindow mainWindow) : base(FoodTypes.Meat, mainWindow, nameof(Tiger))
        {
            base.Icon = "🐅";
        }
        #endregion

        #region method
        /// <summary>
        /// The tiger is eating the food. If the food is meat it will eat it and Moodlevel will rise else it will not eat and Moodlevel drop
        /// </summary>
        /// <param name="food">A food</param>
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

        /// <summary>
        /// When the tiger gets petted of a zookeeper it will send a message
        /// </summary>
        public override void PetAnimal()
        {
            this.mainWindow.SetTextBlockOutput("The tiger says pur pur");
        }
        #endregion
    }
}
