using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Documents;

namespace Obligatorisk_opgave____OOP_Rikke
{
    abstract class Animal 
    {
        #region field
        protected MainWindow mainWindow;
        
        /// <summary>
        /// The animals diet - enum
        /// </summary>
        private FoodTypes diet; // enum
        
        /// <summary>
        /// The animals moodlevel - enum
        /// </summary>
        private MoodLevels mood; //enum
        
        /// <summary>
        /// The animals name - the name is the species
        /// </summary>
        private string name;
        
        /// <summary>
        /// The animals icon/emoji
        /// </summary>
        private string icon;

        #endregion

        #region property
        public FoodTypes Diet { get => diet; set => diet = value; }
        public MoodLevels Mood { get => mood; set => mood = value; }
        public string Name { get => name; set => name = value; }
        public string Icon { get => icon; protected set => icon = value; }

        #endregion

        #region constructor
        public Animal(FoodTypes diet, MainWindow mainWindow, string name)
        {
            this.diet = diet;
            this.mainWindow = mainWindow;
            this.name = name;
        }
        #endregion


        #region method

        /// <summary>
        /// When an animal is eating food it will affect it's mood. If feed their diet the mood will rise, if it's not the diet the mood will fall and if the animal is "Happy" (highest) the player will get a message 
        /// </summary>
        /// <param name="food">A foodtype (diet)</param>
        public virtual void Eat(FoodTypes food)
        {
            if (food == Diet)
            {
                if ((int)mood == Enum.GetValues(typeof(MoodLevels)).Cast<int>().Max())
                {
                    this.mainWindow.SetTextBlockOutput($"The {this.Name} is full and don't want anymore food.");
                }
                else
                {
                    Mood++;
                }
            }
            else
            {
                if ((int)mood > 0)
                {
                    Mood--;
                }
            }
        }

        /// <summary>
        /// A zookeeper can pet an animal
        /// </summary>
        public abstract void PetAnimal();

        #endregion
    }
}
