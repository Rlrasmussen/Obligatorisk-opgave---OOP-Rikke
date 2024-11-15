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
        /// <summary>
        /// The zoo is made of 3 cages
        /// </summary>
        private readonly Cage[] cages = new Cage[3];

        /// <summary>
        /// It's a dynamic collection of zookeepers 
        /// </summary>
        private readonly ObservableCollection<Zookeeper> zookeepers = new ObservableCollection<Zookeeper>();

        /// <summary>
        /// A list of predefined zookeeper names
        /// </summary>
        private readonly string[] availableZookeeperNames = new string[5] { "Jebecky", "Jacob", "Thor", "Skjold", "Max" };
        
        /// <summary>
        /// A random for choosing one random name of availableZookeeperNames
        /// </summary>
        private Random random = new Random();

        private MainWindow mainWindow;

        /// <summary>
        /// Enum of the 3 cages and their index array number 
        /// </summary>
        public enum CageIds
        {
            Cage1 = 0, Cage2 = 1, Cage3 = 2
        }

        #endregion

        #region properties
        internal ObservableCollection<Zookeeper> Zookeepers { get => zookeepers;  }
        internal Cage[] Cages { get => cages; }

        #endregion

        #region constructor
        /// <summary>
        /// When the zoo is declaired it will contain the 3 cages
        /// </summary>
        /// <param name="mainWindow">A MainWindow</param>
        public Zoo (MainWindow mainWindow)
        {
            this.mainWindow = mainWindow;
            cages[0] = new Cage(mainWindow);
            cages[1] = new Cage(mainWindow);
            cages[2] = new Cage(mainWindow);
        }

        #endregion

        #region method
        /// <summary>
        /// Adding a zookeeper to the zoo where the zookeeper is getting one random name from availableZookeeperNames
        /// When the zookeeper is added there will be showend a receipt
        /// </summary>
        internal void AddZookeeper()
        {
            int rdm = random.Next(0, 5);
            Zookeeper zookeeper = new Zookeeper() { Name = availableZookeeperNames[rdm] };
            zookeepers.Add(zookeeper);
            this.mainWindow.SetTextBlockOutput($"Hired {zookeeper.Name}");
        }

        /// <summary>
        /// When a zookeeper is choosed the zookeeper can be removed/fired. When the zookeeper is removed there will be showend a receipt.
        /// </summary>
        /// <param name="zookeeper">A zookeeper</param>
        internal void RemoveZookeeper(Zookeeper zookeeper)
        {
            zookeepers.Remove(zookeeper);
            this.mainWindow.SetTextBlockOutput($"Fired {zookeeper.Name}");

        }

        /// <summary>
        /// Adding a animal to a cage
        /// </summary>
        /// <param name="animal">An animal</param>
        /// <param name="cage">A cage</param>
        internal void AddAnimal(Animal animal, CageIds cage)
        {
            cages[(int)cage].AddAnimal(animal);
        }

        /// <summary>
        /// Removing an animal from a cage
        /// </summary>
        /// <param name="animal">An animal</param>
        /// <param name="cage">A cage</param>
        internal void RemoveAnimal(Animal animal, CageIds cage)
        {
            cages[(int)cage].RemoveAnimal(animal);
        }

        /// <summary>
        /// Return all the animals in the cage
        /// </summary>
        /// <param name="cage">A cage</param>
        /// <returns>It's a dynamic collection of the caged animals</returns>
        internal ObservableCollection<Animal> GetCagedAnimals(CageIds cage)
        {
            return cages[(int)cage].Animals;
        }

        #endregion

    }
}
