﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Obligatorisk_opgave____OOP_Rikke
{
    internal class Animal
    {
        #region field
        private string name;
        private string food;
        private int hunger;


        #endregion

        #region porporty
        public string Name { get => name; set => name = value; }
        public string Food { get => food; set => food = value; }
        public int Hunger { get => hunger; set => hunger = value; }

        #endregion

        #region contructor
        public Animal(string name, string food, int hunger)
        {
            this.name = name;
            this.food = food;
            this.hunger = hunger;
        }
        #endregion


        #region method

        public void Eat()
        {

        }
        #endregion
    }
}
