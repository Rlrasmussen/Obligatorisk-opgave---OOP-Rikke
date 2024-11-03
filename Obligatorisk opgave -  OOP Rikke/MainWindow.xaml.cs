using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Obligatorisk_opgave____OOP_Rikke
{
    
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window, INotifyPropertyChanged
    {
        private Zoo zoo;
        private Zoo.CageIds selectedCage = Zoo.CageIds.Cage1;
        private string _primaryLabel;

        public event PropertyChangedEventHandler PropertyChanged;

        public string PrimaryLabel { get => _primaryLabel; set { 
                _primaryLabel = value; 
                OnPropertyChanged(nameof(PrimaryLabel));  } }

        public MainWindow()
        {
            InitializeComponent();
            zoo = new Zoo(this);
            DataContext = this;
            PrimaryLabel= "Welcome to the zoo";
        }

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        public void SetLabelOutput(string outputMessage)
        {
            PrimaryLabel = outputMessage;
        }

        private void FeedAllButton_Click(object sender, RoutedEventArgs e)
        {
            zoo.Zookeepers[0].FeedAllAnimals(zoo.Cages);
        }

        private void AddZookeeperButton_Click(object sender, RoutedEventArgs e)
        {
            zoo.AddZookeeper(new Zookeeper());
        }

        private void TigerButton_Click(object sender, RoutedEventArgs e)
        {
            zoo.AddAnimal(new Tiger(this), (int)selectedCage);
        }

        private void ParrotButton_Click(object sender, RoutedEventArgs e)
        {
            zoo.AddAnimal(new Parrot(this), (int)selectedCage);
        }

        private void MonkeyButton_Click(object sender, RoutedEventArgs e)
        {
            zoo.AddAnimal(new Monkey(this), (int)selectedCage);
        }

        private void SelectCage1_Click(object sender, RoutedEventArgs e)
        {
            selectedCage = Zoo.CageIds.Cage1;
        }

        private void SelectCage2_Click(object sender, RoutedEventArgs e)
        {
            selectedCage = Zoo.CageIds.Cage2;
        }

        private void SelectCage3_Click(object sender, RoutedEventArgs e)
        {
            selectedCage = Zoo.CageIds.Cage3;
        }
    }
}
