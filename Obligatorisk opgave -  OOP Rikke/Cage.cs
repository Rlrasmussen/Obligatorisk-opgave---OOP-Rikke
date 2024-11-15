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
        internal ObservableCollection<Animal> Animals { get => animals; }

        #endregion

        #region constructor
        /// <summary>
        /// 
        /// </summary>
        /// <param name="mainWindow">A mainwindow</param>
        public Cage(MainWindow mainWindow)
        {
            this.mainWindow = mainWindow;
        }

        #endregion

        
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
                    this.mainWindow.SetTextBlockOutput($"You can not put {animal.Name} in the cage because there is a tiger.");
                    return;
                }
                if (cagedAnimal is Parrot && animal is Tiger || cagedAnimal is Monkey && animal is Tiger)
                {
                    this.mainWindow.SetTextBlockOutput("You cannot put a tiger in a cage with other animals.");
                    return;
                }  
            }
            animals.Add(animal);
            this.mainWindow.SetTextBlockOutput($"The {animal.Name} is added to the cage");
        }

        internal void RemoveAnimal(Animal animal)
        {
            Animals.Remove(animal);
        }


        #endregion
    }
}
