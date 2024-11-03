using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Documents;

namespace Obligatorisk_opgave____OOP_Rikke
{
    internal class Monkey : Animal
    {
        #region field

        #endregion

        #region porporty


        #endregion

        #region constructor
        public Monkey(string name, FoodTypes food, MoodLevels hunger) : base (name, food, hunger)
        {
            base.Name = name;
            base.Diet = food;
            base.Mood = hunger;
        }
        #endregion

        #region method
        //public override void Eat(FoodTypes food)
        public override void Eat(FoodTypes food)
        {
            base.Eat(food);
            if (food == Diet)
            {
                MainWindow.SetLabelOutput($"{Name} is eating {food} and it's mood is {Mood}");
            }
            if (food != Diet)
            {
                MainWindow.SetLabelOutput($"{Name} don't like {food} and it's mood is now {Mood}");
            }

        }

        public override void PetAnimal()
        {
            MainWindow.SetLabelOutput($"{Name} says: Uh uh ah ah");
        }

        #endregion

    }
}
