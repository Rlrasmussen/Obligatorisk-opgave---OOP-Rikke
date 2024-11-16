using System.ComponentModel;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace Obligatorisk_opgave____OOP_Rikke
{
    
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window, INotifyPropertyChanged
    {
        #region field
        private readonly Zoo zoo;
        private Zoo.CageIds selectedCage = Zoo.CageIds.Cage1;
        private string _primaryLabel;
        private Animal selectedAnimal;
        private Zookeeper selectedZookeeper;


        public event PropertyChangedEventHandler PropertyChanged;
        #endregion

        #region property
        public string PrimaryLabel
        {
            get => _primaryLabel; set
            {
                _primaryLabel = value;
                OnPropertyChanged(nameof(PrimaryLabel));
            }
        }

        #endregion

        #region constructor
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
            HowToTextBlock.Text = "How to use the zoo \n" +
                "\r\nTo add a animal:\r\n1: Choose a cage \r\n2: Choose an animal \r\n" +
                "\r\nTo remove an animal: \r\n1: Choose an animal \r\n2: Press “Remove animal” \r\n" +
                "\r\nTo feed an animal: \r\n1: Choose a zookeeper \r\n2: Choose an animal \r\n3: Choose a diet \r\n" +
                "\r\nTo pet an animal: \r\n1: Choose a zookeeper \r\n2: Choose an animal \r\n3: Press “Pet animal” \r\n" +
                "\r\nTo add a zookeeper: \r\n1: Press “Add zookeeper” \r\n" +
                "\r\nTo fire a zookeeper: \r\n1: Choose a zookeeper \r\n2: Press “Fire zookeeper” \r\n";
            MoodLevelsTextBlock.Text = $"All the animals start at {MoodLevels.Furious} and gets happier when feed their diet. If they er feed something different their moodlevel lower.\n" +
                $"\nThe different kinds of moods:\n" +
                $"{MoodLevels.Furious}, {MoodLevels.Mad}, {MoodLevels.Hangry}, {MoodLevels.Fine}, {MoodLevels.Contempt} and {MoodLevels.Happy}.";
        }

        #endregion

        #region method
        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        public void SetTextBlockOutput(string outputMessage)
        {
            PrimaryLabel += outputMessage + "\n";
            OutputScrollViewer.ScrollToBottom();
        }

        #region food
        /// <summary>
        /// Feed an animal sugar
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SugarButton_Click(object sender, RoutedEventArgs e)
        {
            if (selectedAnimal == null)
            {
                this.SetTextBlockOutput("You need to choose an animal.");
                return;
            }
            if ( selectedZookeeper == null)
            {
                this.SetTextBlockOutput("You need to choose a zookeeper.");
                return;
            }
            selectedZookeeper.FeedAnimal(selectedAnimal, FoodTypes.Sugar);
            Cage1Animals.Items.Refresh();
            Cage2Animals.Items.Refresh();
            Cage3Animals.Items.Refresh();
        }

        /// <summary>
        /// Feed an animal banana
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BananaButton_Click(object sender, RoutedEventArgs e)
        {
            if (selectedAnimal == null)
            {
                this.SetTextBlockOutput("You need to choose an animal.");
                return;
            }
            if (selectedZookeeper == null)
            {
                this.SetTextBlockOutput("You need to choose a zookeeper.");
                return;
            }
            selectedZookeeper.FeedAnimal(selectedAnimal, FoodTypes.Banana);
            Cage1Animals.Items.Refresh();
            Cage2Animals.Items.Refresh();
            Cage3Animals.Items.Refresh();
        }

        /// <summary>
        /// Feeding an animal meat
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MeatButton_Click(object sender, RoutedEventArgs e)
        {
            if (selectedAnimal == null)
            {
                this.SetTextBlockOutput("You need to choose an animal.");
                return;
            }
            if (selectedZookeeper == null)
            {
                this.SetTextBlockOutput("You need to choose a zookeeper.");
                return;
            }
            selectedZookeeper.FeedAnimal(selectedAnimal, FoodTypes.Meat);
            Cage1Animals.Items.Refresh();
            Cage2Animals.Items.Refresh();
            Cage3Animals.Items.Refresh();
        }

        #endregion

        private void AddZookeeperButton_Click(object sender, RoutedEventArgs e)
        {
            zoo.AddZookeeper();
        }

        #region add animal
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

        #endregion


        private void SelectCage1_Click(object sender, RoutedEventArgs e)
        {
            selectedCage = Zoo.CageIds.Cage1;
            SelectCage1.Background = Brushes.CornflowerBlue;
            SelectCage2.Background = Brushes.LightGray;
            SelectCage3.Background = Brushes.LightGray;
        }

        private void SelectCage2_Click(object sender, RoutedEventArgs e)
        {
            selectedCage = Zoo.CageIds.Cage2;
            SelectCage1.Background = Brushes.LightGray;
            SelectCage2.Background = Brushes.CornflowerBlue;
            SelectCage3.Background = Brushes.LightGray;
        }

        private void SelectCage3_Click(object sender, RoutedEventArgs e)
        {
            selectedCage = Zoo.CageIds.Cage3;
            SelectCage1.Background = Brushes.LightGray;
            SelectCage2.Background = Brushes.LightGray;
            SelectCage3.Background = Brushes.CornflowerBlue;
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
            this.SetTextBlockOutput($"{selectedAnimal.Name} is removed.");
            zoo.RemoveAnimal(selectedAnimal, selectedCage);
        }

        private void PetAnimalButton_Click(object sender, RoutedEventArgs e)
        {
            if(selectedAnimal == null || selectedZookeeper == null)
            {
                this.SetTextBlockOutput("You need to choose an animal and a zookeeper.");
                return;
            }
            selectedZookeeper.PetAnimal(selectedAnimal);
        }
        #endregion
    }
}