﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Documents;

namespace Obligatorisk_opgave____OOP_Rikke
{
    abstract class Animal : IEat
    {
        #region field
        private FoodTypes diet; // enum
        private MoodLevels mood; //enum
        protected MainWindow mainWindow;
        private string name;
        private string icon;

        #endregion

        #region property
        public FoodTypes Diet { get => diet; set => diet = value; }
        public MoodLevels Mood { get => mood; set {  mood = value;
                OnPropertyChanged(nameof(Mood)); } }
        public string Name { get => name; set => name = value; }
        public string Icon { get => icon; protected set => icon = value; }

        public event PropertyChangedEventHandler PropertyChanged;

        
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

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public virtual void Eat(FoodTypes food)
        {
            if (food == Diet)
            {
                
                if ((int)mood < Enum.GetValues(typeof(MoodLevels)).Cast<int>().Max())
                {
                    Mood++;
                }
                else
                {
                    this.mainWindow.SetTextBlockOutput($"The {this.Name} is full and don't want anymore food.");
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
        /// All the animals is getting petted
        /// </summary>
        public abstract void PetAnimal();

        #endregion
    }
}
