using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Obligatorisk_opgave____OOP_Rikke
{
    internal class Zookeeper
    {
        #region field
        private string name;

        #endregion

        #region porporty
        public string Name { get => name; set => name = value; }


        #endregion

        #region constructor

        #endregion

        #region method
        /// <summary>
        /// Feed all the animals the same kind of food
        /// </summary>
        /// <param name="animal"></param>
        /// <param name="food"></param>
        public void FeedAnimal(Animal animal, FoodTypes food)
        {
            animal.Eat(food);
        }

        public void PetAnimal(Animal animal)
        {
            animal.PetAnimal();
        }

        #endregion
    }
}
