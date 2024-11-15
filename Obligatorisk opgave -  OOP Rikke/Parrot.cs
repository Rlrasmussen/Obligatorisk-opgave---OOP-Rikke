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
        /// <summary>
        /// In the construction of the Parrot it's diet and name is already set. 
        /// A parrot is eating sugar and it's name is Parrot.
        /// </summary>
        /// <param name="mainWindow">A mainwindow</param>
        public Parrot(MainWindow mainWindow) : base(FoodTypes.Sugar, mainWindow, nameof(Parrot))
        {
            base.Icon = "🦜";
        }
        #endregion

        #region method
        /// <summary>
        /// The parrot is eating the food. If the food is sugar it will eat it and Moodlevel will rise else it will not eat and Moodlevel drop
        /// </summary>
        /// <param name="food">A food</param>
        public override void Eat(FoodTypes food)
        {
            base.Eat(food);
            if (food == Diet)
            {
                this.mainWindow.SetTextBlockOutput($"The parrot is eating {food} and it's mood is {Mood}");
            }
            if (food != Diet)
            {
                this.mainWindow.SetTextBlockOutput($"The parrot don't like {food} and it's mood is now {Mood}");
            }
            if (MoodLevels.Happy == Mood)
            {
                this.mainWindow.SetTextBlockOutput($"The parrot is not hungry anymore");
            }
        }

        /// <summary>
        /// When the parrot gets petted of a zookeeper it will send a message
        /// </summary>
        public override void PetAnimal()
        {
            this.mainWindow.SetTextBlockOutput($"The parrot sqwuaks");
        }

        #endregion
    }
}
