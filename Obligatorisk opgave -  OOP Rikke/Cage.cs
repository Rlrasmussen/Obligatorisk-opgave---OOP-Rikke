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
            foreach (var cagedAnimal in Animals)
            {
                if (Animals.Count == 0)
                {
                    Animals.Add(animal);
                    this.mainWindow.SetLabelOutput($"The {animal} is added to the cage");
                    break;
                }
                if(cagedAnimal is Tiger && animal is Tiger)
                {
                    Animals.Add(animal);
                    this.mainWindow.SetLabelOutput($"The {animal} is added to the cage");
                    break;
                }
                if (cagedAnimal is Tiger && animal is Parrot || cagedAnimal is Tiger && animal is Monkey)
                {
                    this.mainWindow.SetLabelOutput($"There is a tiger in the cage and the {animal} is now dead. The tiger is now put down and the entire cage is now empty.");
                    Animals.Clear();
                    break;
                }
                if (cagedAnimal is Parrot && animal is Tiger || cagedAnimal is Monkey && animal is Tiger)
                {
                    this.mainWindow.SetLabelOutput("The tiger ate all the animals in the cage. The tiger is now put down and the entire cage is now empty.");
                    Animals.Clear();
                    break;
                }
                Animals.Add(animal);
                this.mainWindow.SetLabelOutput($"The {animal} is added to the cage");
            }
        }


        #endregion
    }
}
