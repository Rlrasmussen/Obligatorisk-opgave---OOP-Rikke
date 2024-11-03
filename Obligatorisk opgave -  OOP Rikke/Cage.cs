using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Obligatorisk_opgave____OOP_Rikke
{
    internal class Cage
    {

        #region field
        private List<Animal> animals = new List<Animal>();


        #endregion

        #region property
        internal List<Animal> Animals { get => animals; }

        private MainWindow mainWindow;
        #endregion

        #region constructor
        public Cage(MainWindow mainWindow)
        {
            this.mainWindow = mainWindow;
        }

        #endregion

        /// <summary>
        /// Adding an animal to the cage where a Tiger only can be in a tiger cage og it will eat the other animals
        /// </summary>
        /// <param name="animal">The animal is going in the cage</param>
        #region method
        public void AddAnimal(Animal animal)
        {
            if (Animals.Count == 0)
            {
                Animals.Add(animal);
                this.mainWindow.SetTextBlockOutput($"The {animal.Name} is added to the cage");
                return;
            }

            foreach (var cagedAnimal in Animals)
            {
                if(cagedAnimal is Tiger && animal is Tiger)
                {
                    animals.Add(animal);
                    this.mainWindow.SetTextBlockOutput($"The {animal.Name} is added to the cage");
                    return;
                }
                if (cagedAnimal is Tiger && animal is Parrot || cagedAnimal is Tiger && animal is Monkey)
                {
                    this.mainWindow.SetTextBlockOutput($"There is a tiger in the cage and the {animal.Name} is now dead. The tiger is now put down and the entire cage is now empty.");
                    animals.Clear();
                    return;
                }
                if (cagedAnimal is Parrot && animal is Tiger || cagedAnimal is Monkey && animal is Tiger)
                {
                    this.mainWindow.SetTextBlockOutput("The tiger ate all the animals in the cage. The tiger is now put down and the entire cage is now empty.");
                    animals.Clear();
                    return;
                }  
            }
            animals.Add(animal);
            this.mainWindow.SetTextBlockOutput($"The {animal.Name} is added to the cage");
        }


        #endregion
    }
}
