using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Obligatorisk_opgave____OOP_Rikke
{
    internal class Zoo
    {
        #region field
        private readonly Cage[] cages = new Cage[3];
        private readonly ObservableCollection<Zookeeper> zookeepers = new ObservableCollection<Zookeeper>();
        private readonly string[] availableZookeeperNames = new string[5] { "Jebecky", "Jakob", "Nicolas", "Cage", "Them" };
        private Random random = new Random();

        public enum CageIds
        {
            Cage1 = 0, Cage2 = 1, Cage3 = 2
        }

        #endregion

        #region properties
        internal ObservableCollection<Zookeeper> Zookeepers { get => zookeepers;  }
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
        internal void AddZookeeper()
        {
            int rdm = random.Next(0, 5);
            Zookeeper zookeeper = new Zookeeper() { Name = availableZookeeperNames[rdm] };
            zookeepers.Add(zookeeper);
            this.mainWindow.SetTextBlockOutput("Added zookeeper");
        }

        internal void RemoveZookeeper(Zookeeper zookeeper)
        {
            zookeepers.Remove(zookeeper);
            this.mainWindow.SetTextBlockOutput($"Fired {zookeeper.Name}");

        }

        internal void AddAnimal(Animal animal, CageIds cage)
        {
            cages[(int)cage].AddAnimal(animal);
        }

        internal void RemoveAnimal(Animal animal, CageIds cage)
        {
            cages[(int)cage].RemoveAnimal(animal);
        }

        internal ObservableCollection<Animal> GetCagedAnimals(CageIds cage)
        {
            return cages[(int)cage].Animals;
        }

        #endregion

    }
}
