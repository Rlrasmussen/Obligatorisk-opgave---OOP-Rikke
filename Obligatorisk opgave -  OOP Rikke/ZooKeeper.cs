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
        /// <summary>
        /// The visual identification of the zookeeper
        /// </summary>
        private string name;

        #endregion

        #region property
        public string Name { get => name; set => name = value; }

        #endregion

        #region constructor
        /// <summary>
        /// When the zookeeper is declaried the will be by default null
        /// </summary>
        /// <param name="name">Zookeepers name</param>
        public Zookeeper(string name = null)
        {
            this.Name = name;
        }
        #endregion

        #region method
        /// <summary>
        /// Feed the animal food
        /// </summary>
        /// <param name="animal">An animal</param>
        /// <param name="food">Food for the animal - can choose between the diets from FoodTypes</param>
        public void FeedAnimal(Animal animal, FoodTypes food)
        {
            animal.Eat(food);
        }

        /// <summary>
        /// The zookeeper is petting an animal
        /// </summary>
        /// <param name="animal">An animal</param>
        public void PetAnimal(Animal animal)
        {
            animal.PetAnimal();
        }

        #endregion
    }
}
