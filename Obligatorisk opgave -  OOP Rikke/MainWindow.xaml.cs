using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
        private readonly Zoo zoo;
        private Zoo.CageIds selectedCage = Zoo.CageIds.Cage1;
        private string _primaryLabel;
        private Animal selectedAnimal;
        private Zookeeper selectedZookeeper;


        public event PropertyChangedEventHandler PropertyChanged;

        public string PrimaryLabel
        {
            get => _primaryLabel; set
            {
                _primaryLabel = value;
                OnPropertyChanged(nameof(PrimaryLabel));
            }
        }


        public MainWindow()
        {
            InitializeComponent();
            zoo = new Zoo(this);
            zoo.AddZookeeper();
            zoo.AddZookeeper();

            Cage1Animals.ItemsSource = zoo.GetCagedAnimals(Zoo.CageIds.Cage1);
            Cage2Animals.ItemsSource = zoo.GetCagedAnimals(Zoo.CageIds.Cage2);
            Cage3Animals.ItemsSource = zoo.GetCagedAnimals(Zoo.CageIds.Cage3);
            Zookeepers.ItemsSource = zoo.Zookeepers;

            DataContext = this; 
            PrimaryLabel= "Welcome to the zoo \n";
        }

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        public void SetTextBlockOutput(string outputMessage)
        {
            PrimaryLabel += outputMessage + "\n";
            OutputScrollViewer.ScrollToBottom();
        }

        private void SugarButton_Click(object sender, RoutedEventArgs e)
        {
            selectedZookeeper.FeedAnimal(selectedAnimal, FoodTypes.Sugar);
            Cage1Animals.Items.Refresh();
            Cage2Animals.Items.Refresh();
            Cage3Animals.Items.Refresh();
        }

        private void BananaButton_Click(object sender, RoutedEventArgs e)
        {
            selectedZookeeper.FeedAnimal(selectedAnimal, FoodTypes.Banana);
            Cage1Animals.Items.Refresh();
            Cage2Animals.Items.Refresh();
            Cage3Animals.Items.Refresh();
        }

        private void MeatButton_Click(object sender, RoutedEventArgs e)
        {
            selectedZookeeper.FeedAnimal(selectedAnimal, FoodTypes.Meat);
            Cage1Animals.Items.Refresh();
            Cage2Animals.Items.Refresh();
            Cage3Animals.Items.Refresh();
        }

        private void AddZookeeperButton_Click(object sender, RoutedEventArgs e)
        {
            zoo.AddZookeeper();
        }

        private void TigerButton_Click(object sender, RoutedEventArgs e)
        {
            this.zoo.AddAnimal(new Tiger(this), selectedCage);
        }

        private void ParrotButton_Click(object sender, RoutedEventArgs e)
        {
            this.zoo.AddAnimal(new Parrot(this), selectedCage);
        }

        private void MonkeyButton_Click(object sender, RoutedEventArgs e) 
        {
            this.zoo.AddAnimal(new Monkey(this), selectedCage);
        }

        private void SelectCage1_Click(object sender, RoutedEventArgs e)
        {
            selectedCage = Zoo.CageIds.Cage1;
            SelectCage1.Background = Brushes.Turquoise;
            SelectCage2.Background = Brushes.LightGray;
            SelectCage3.Background = Brushes.LightGray;
        }

        private void SelectCage2_Click(object sender, RoutedEventArgs e)
        {
            selectedCage = Zoo.CageIds.Cage2;
            SelectCage1.Background = Brushes.LightGray;
            SelectCage2.Background = Brushes.Turquoise;
            SelectCage3.Background = Brushes.LightGray;
        }

        private void SelectCage3_Click(object sender, RoutedEventArgs e)
        {
            selectedCage = Zoo.CageIds.Cage3;
            SelectCage1.Background = Brushes.LightGray;
            SelectCage2.Background = Brushes.LightGray;
            SelectCage3.Background = Brushes.Turquoise;
        }

        private void Cage3Animals_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Cage1Animals.SelectedIndex = -1;
            Cage2Animals.SelectedIndex = -1;
            this.selectedAnimal = (Animal)Cage3Animals.SelectedItem;
            this.selectedCage = Zoo.CageIds.Cage3;
        }

        private void Cage2Animals_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Cage1Animals.SelectedIndex = -1;
            Cage3Animals.SelectedIndex = -1;
            this.selectedAnimal = (Animal)Cage2Animals.SelectedItem;
            this.selectedCage = Zoo.CageIds.Cage2;
        }

        private void Cage1Animals_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Cage2Animals.SelectedIndex = -1;
            Cage3Animals.SelectedIndex = -1;
            this.selectedAnimal = (Animal)Cage1Animals.SelectedItem;
            this.selectedCage = Zoo.CageIds.Cage1;
        }

        private void Zookeepers_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            this.selectedZookeeper = (Zookeeper)Zookeepers.SelectedItem;
        }

        private void RemoveZookeeperButton_Click(object sender, RoutedEventArgs e)
        {
            if ( selectedZookeeper == null)
            {
                this.SetTextBlockOutput("You need to choose a zookeeper.");
                return;
            }
            
            zoo.RemoveZookeeper(selectedZookeeper);
        }

        private void RemoveAnimalButton_Click(object sender, RoutedEventArgs e)
        {
            if (selectedAnimal == null)
            {
                this.SetTextBlockOutput("You need to choose an animal.");

                return;
            }
            zoo.RemoveAnimal(selectedAnimal, selectedCage);
        }
    }
}