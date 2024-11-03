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


        #endregion

        #region constructor

        #endregion

        #region method
        public void AddAnimal(Animal animal)
        {
            foreach (var cagedAnimal in animals)
            {
                if (animals.Count == 0)
                {
                    animals.Add(animal);
                    MainWindow.SetLabelOutput($"The {animal} is added to the cage");
                    break;
                }
                if(cagedAnimal is Tiger && animal is Tiger)
                {
                    animals.Add(animal);
                    MainWindow.SetLabelOutput($"The {animal} is added to the cage");
                    break;
                }
                if (cagedAnimal is Tiger && animal is Parrot || cagedAnimal is Tiger && animal is Monkey)
                {
                    MainWindow.SetLabelOutput($"The {animal} can not be added to the tiger cage");
                    break;
                }
                animals.Add(animal);
                MainWindow.SetLabelOutput($"The {animal} is added to the cage");
            }
        }

        #endregion
    }
}
