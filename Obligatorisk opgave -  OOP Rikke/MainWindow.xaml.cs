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
        private string cage1TextBlock;
        private string cage2TextBlock;
        private string cage3TextBlock;


        public event PropertyChangedEventHandler PropertyChanged;

        public string PrimaryLabel
        {
            get => _primaryLabel; set
            {
                _primaryLabel = value;
                OnPropertyChanged(nameof(PrimaryLabel));
            }
        }

        public string Cage1TextBlock
        {
            get => cage1TextBlock; set
            {
                cage1TextBlock = value;
                OnPropertyChanged(nameof(Cage1TextBlock));
            }
        }

        public string Cage2TextBlock
        {
            get => cage1TextBlock; set
            {
                cage1TextBlock = value;
                OnPropertyChanged(nameof(Cage2TextBlock));
            }
        }

        public string Cage3TextBlock
        {
            get => cage1TextBlock; set
            {
                cage1TextBlock = value;
                OnPropertyChanged(nameof(Cage3TextBlock));
            }
        }

        public MainWindow()
        {
            InitializeComponent();
            zoo = new Zoo(this);
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
            int nicolas = (int)selectedCage;
            this.zoo.AddAnimal(new Tiger(this), nicolas);
            List<Animal> cageThem = zoo.GetAnimals(nicolas);
            this.PrintCage(cageThem);
        }

        private void ParrotButton_Click(object sender, RoutedEventArgs e)
        {
            int nicolas = (int)selectedCage;
            this.zoo.AddAnimal(new Parrot(this), nicolas);
            List<Animal> cageThem = zoo.GetAnimals(nicolas);
            this.PrintCage(cageThem);
        }

        private void MonkeyButton_Click(object sender, RoutedEventArgs e)
        {
            int nicolas = (int)selectedCage;
            this.zoo.AddAnimal(new Monkey(this), nicolas);
            List<Animal> cageThem = zoo.GetAnimals(nicolas);
            this.PrintCage(cageThem);
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
        

        private void PrintCage(List<Animal> animals)
        {
            int count = 0;
            int maxCount = 5;
            
            switch (selectedCage)
            {
                case Zoo.CageIds.Cage1:
                    Cage1TextBlock = "";
                    foreach (var animal in animals)
                    {
                        Cage1TextBlock += animal.Icon;
                        count++;
                        if (count % maxCount == 0)
                        {
                            cage1TextBlock += "\n";
                        }
                    }
                    break;
                case Zoo.CageIds.Cage2:
                    Cage2TextBlock = "";
                    foreach (var animal in animals)
                    {
                        Cage2TextBlock += animal.Icon;
                        count++;
                        if (count % maxCount == 0)
                        {
                            cage1TextBlock += "\n";
                        }
                    }
                    break;
                case Zoo.CageIds.Cage3:
                    Cage3TextBlock = "";
                    foreach (var animal in animals)
                    {
                        Cage3TextBlock += animal.Icon;
                        count++;
                        if (count % maxCount == 0)
                        {
                            cage1TextBlock += "\n";
                        }
                    }
                    break;
            }
        }
    }
}