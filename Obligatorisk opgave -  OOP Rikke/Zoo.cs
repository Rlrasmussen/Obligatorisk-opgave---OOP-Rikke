using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Obligatorisk_opgave____OOP_Rikke
{
    internal class Zoo
    {
        #region field
        private Cage[] cages = new Cage[3];
        private List<Zookeeper> zookeepers = new List<Zookeeper>();

        public enum CageIds
        {
            Cage1, Cage2, Cage3
        }

        #endregion

        #region properties
        internal List<Zookeeper> Zookeepers { get => zookeepers;  }
        internal Cage[] Cages { get => cages; }

        private MainWindow mainWindow;


        #endregion

        #region constructor
        public Zoo (MainWindow mainWindow)
        {
            this.mainWindow = mainWindow;
            cages[0] = new Cage(mainWindow);
            cages[1] = new Cage(mainWindow);
            cages[2] = new Cage(mainWindow);
        }

        #endregion

        #region method
        internal void AddZookeeper(Zookeeper zookeeper)
        {
            this.mainWindow.SetLabelOutput("Added zookeeper");
            zookeepers.Add(zookeeper);
        }

        internal void AddAnimal(Animal animal, int cage)
        {
            cages[cage].AddAnimal(animal);
        }

        #endregion

    }
}
