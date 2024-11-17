using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Obligatorisk_opgave____OOP_Rikke
{
    internal class Cage
    {

        #region field
        /// <summary>
        /// It's a dynamic collection of animals
        /// </summary>
        private ObservableCollection<Animal> animals = new ObservableCollection<Animal>();

        private MainWindow mainWindow;
        #endregion

        #region property
        internal ObservableCollection<Animal> Animals { get => animals; } //IT's internal so other classes can acces the collection

        #endregion

        #region constructor
        /// <summary>
        /// Constructer for the animal cage
        /// </summary>
        /// <param name="mainWindow">A mainwindow</param>
        public Cage(MainWindow mainWindow)
        {
            this.mainWindow = mainWindow;
        }

        #endregion

        
        #region method
        /// <summary>
        /// Adding an animal to a cage where tigers can not be in the same cage as parrots and monkeys. Parrots and monkeys can be in the same cage
        /// </summary>
        /// <param name="animal">An animal</param>
        public void AddAnimal(Animal animal)
        {
            //If the cage is empty
            if (Animals.Count == 0)
            {
                Animals.Add(animal);
                this.mainWindow.SetTextBlockOutput($"The {animal.Name} is added to the cage");
                return;
            }

            //If the cage isn't empty and tjecking if the animal and/or the aldready caged animal(s) is a tiger
            foreach (Animal cagedAnimal in Animals)
            {
                if(cagedAnimal is Tiger && animal is Tiger)
                {
                    animals.Add(animal);
                    this.mainWindow.SetTextBlockOutput($"The {animal.Name} is added to the cage");
                    return;
                }
                if (cagedAnimal is Tiger && animal is Parrot || cagedAnimal is Tiger && animal is Monkey)
                {
                    this.mainWindow.SetTextBlockOutput($"You can not put {animal.Name} in the cage because there is a tiger.");
                    return;
                }
                if (cagedAnimal is Parrot && animal is Tiger || cagedAnimal is Monkey && animal is Tiger)
                {
                    this.mainWindow.SetTextBlockOutput("You cannot put a tiger in a cage with other animals.");
                    return;
                }  
            }
            //If none of the animals are a tiger
            animals.Add(animal);
            this.mainWindow.SetTextBlockOutput($"The {animal.Name} is added to the cage");
        }

        /// <summary>
        /// Remove an animal from the cage
        /// </summary>
        /// <param name="animal">An animal</param>
        internal void RemoveAnimal(Animal animal)
        {
            Animals.Remove(animal);
        }


        #endregion
    }
}
