using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Documents;

namespace Obligatorisk_opgave____OOP_Rikke
{
    abstract class Animal
    {
        #region field
        private FoodTypes diet; // enum
        private MoodLevels mood; //enum

        
        #endregion

        #region property
        public FoodTypes Diet { get => diet; set => diet = value; }
        public MoodLevels Mood { get => mood; set => mood = value; }


        #endregion

        #region constructor
        public Animal(FoodTypes diet, MoodLevels mood)
        {
            this.diet = diet;
            this.mood = mood;
        }
        #endregion


        #region method

        public virtual void Eat(FoodTypes food)
        {
            if (food == Diet)
            {
                
                if ((int)mood < Enum.GetValues(typeof(MoodLevels)).Cast<int>().Max())
                {
                    mood++;
                }
            }
           
            else
            {
                if ((int)mood > 0)
                {
                    mood--;
                }
            }
        }

        /// <summary>
        /// All the animals is getting petted
        /// </summary>
        public abstract void PetAnimal();

        #endregion
    }
}
