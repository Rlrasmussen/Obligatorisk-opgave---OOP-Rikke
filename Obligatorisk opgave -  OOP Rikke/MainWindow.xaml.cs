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
        /// <summary>
        /// The zoo. Made readonly for making a fixed variable after the zoo is constructed 
        /// </summary>
        private readonly Zoo zoo;

        /// <summary>
        /// Message which is printing out in "OutputScrollViewer"
        /// </summary>
        private string _primaryLabel;
        
        /// <summary>
        /// Selected cage
        /// </summary>
        private Zoo.CageIds selectedCage = Zoo.CageIds.Cage1;
        
        /// <summary>
        /// Selected animal
        /// </summary>
        private Animal selectedAnimal;
        
        /// <summary>
        /// Seleted zookeeper
        /// </summary>
        private Zookeeper selectedZookeeper;

        /// <summary>
        /// Handles the changes for the property which PrimaryLabel
        /// </summary>
        public event PropertyChangedEventHandler PropertyChanged;
        #endregion

        #region property
        public string PrimaryLabel
        {
            get => _primaryLabel; set
            {
                _primaryLabel = value;
                OnPropertyChanged(nameof(PrimaryLabel)); //Call OnPropertyChanged when the property is changes
            }
        }

        #endregion

        #region constructor
        public MainWindow()
        {
            InitializeComponent();
            zoo = new Zoo(this);
            zoo.AddZookeeper(); //First prehired zookeeper
            zoo.AddZookeeper(); //Second prehired zookeeper

            //The three cages 
            Cage1Animals.ItemsSource = zoo.GetCagedAnimals(Zoo.CageIds.Cage1);
            Cage2Animals.ItemsSource = zoo.GetCagedAnimals(Zoo.CageIds.Cage2);
            Cage3Animals.ItemsSource = zoo.GetCagedAnimals(Zoo.CageIds.Cage3);
            
            //The zookeepers
            Zookeepers.ItemsSource = zoo.Zookeepers;

            //For elemtens which is part of binding
            DataContext = this;

            //Welcome message
            PrimaryLabel = "Welcome to the zoo \n";

            //How to manual for operating the zoo and defining the different moods
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
        /// <summary>
        /// Make changes when there are changes to propertyName
        /// </summary>
        /// <param name="propertyName">A property which is going to be changed</param>
        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        /// <summary>
        /// Print out message at "OutputScrollViewer"
        /// </summary>
        /// <param name="outputMessage">Message</param>
        public void SetTextBlockOutput(string outputMessage)
        {
            PrimaryLabel += outputMessage + "\n";
            OutputScrollViewer.ScrollToBottom();
        }

        #region food
        /// <summary>
        /// Feed an animal sugar
        /// </summary>
        /// <param name="sender">Caster over to the buttom</param>
        /// <param name="e">Registered changes in event</param>
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
        /// <param name="sender">Caster over to the buttom</param>
        /// <param name="e">Registered changes in event</param>
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

        #region animal
        /// <summary>
        /// Ad a tiger
        /// </summary>
        /// <param name="sender">Caster over to the buttom</param>
        /// <param name="e">Registered changes in event</param>
        private void TigerButton_Click(object sender, RoutedEventArgs e)
        {
            this.zoo.AddAnimal(new Tiger(this), selectedCage);
        }

        /// <summary>
        /// Ad a parrot
        /// </summary>
        /// <param name="sender">Caster over to the buttom</param>
        /// <param name="e">Registered changes in event</param>
        private void ParrotButton_Click(object sender, RoutedEventArgs e)
        {
            this.zoo.AddAnimal(new Parrot(this), selectedCage);
        }

        /// <summary>
        /// Add a monkey
        /// </summary>
        /// <param name="sender">Caster over to the buttom</param>
        /// <param name="e">Registered changes in event</param>
        private void MonkeyButton_Click(object sender, RoutedEventArgs e) 
        {
            this.zoo.AddAnimal(new Monkey(this), selectedCage);
        }

        /// <summary>
        /// Remove animal
        /// </summary>
        /// <param name="sender">Caster over to the buttom</param>
        /// <param name="e">Registered changes in event</param>
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

        /// <summary>
        /// Pet animal
        /// </summary>
        /// <param name="sender">Caster over to the buttom</param>
        /// <param name="e">Registered changes in event</param>
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

        #region cage
        /// <summary>
        /// Select cage 1
        /// </summary>
        /// <param name="sender">Caster over to the buttom</param>
        /// <param name="e">Registered changes in event</param>
        private void SelectCage1_Click(object sender, RoutedEventArgs e)
        {
            selectedCage = Zoo.CageIds.Cage1;
            SelectCage1.Background = Brushes.CornflowerBlue;
            SelectCage2.Background = Brushes.LightGray;
            SelectCage3.Background = Brushes.LightGray;
        }

        /// <summary>
        /// Select cage 2
        /// </summary>
        /// <param name="sender">Caster over to the buttom</param>
        /// <param name="e">Registered changes in event</param>
        private void SelectCage2_Click(object sender, RoutedEventArgs e)
        {
            selectedCage = Zoo.CageIds.Cage2;
            SelectCage1.Background = Brushes.LightGray;
            SelectCage2.Background = Brushes.CornflowerBlue;
            SelectCage3.Background = Brushes.LightGray;
        }

        /// <summary>
        /// Select cage 3
        /// </summary>
        /// <param name="sender">Caster over to the buttom</param>
        /// <param name="e">Registered changes in event</param>
        private void SelectCage3_Click(object sender, RoutedEventArgs e)
        {
            selectedCage = Zoo.CageIds.Cage3;
            SelectCage1.Background = Brushes.LightGray;
            SelectCage2.Background = Brushes.LightGray;
            SelectCage3.Background = Brushes.CornflowerBlue;
        }

        /// <summary>
        /// Select cage 1 animal
        /// </summary>
        /// <param name="sender">Caster over to the buttom</param>
        /// <param name="e">Registered changes in event</param>
        private void Cage1Animals_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Cage2Animals.SelectedIndex = -1;
            Cage3Animals.SelectedIndex = -1;
            this.selectedAnimal = (Animal)Cage1Animals.SelectedItem;
            this.selectedCage = Zoo.CageIds.Cage1;
        }


        /// <summary>
        /// Select cage 2 animal
        /// </summary>
        /// <param name="sender">Caster over to the buttom</param>
        /// <param name="e">Registered changes in event</param>
        private void Cage2Animals_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Cage1Animals.SelectedIndex = -1;
            Cage3Animals.SelectedIndex = -1;
            this.selectedAnimal = (Animal)Cage2Animals.SelectedItem;
            this.selectedCage = Zoo.CageIds.Cage2;
        }

        /// <summary>
        /// Selec cage 3 animal
        /// </summary>
        /// <param name="sender">Caster over to the buttom</param>
        /// <param name="e">Registered changes in event</param>
        private void Cage3Animals_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Cage1Animals.SelectedIndex = -1;
            Cage2Animals.SelectedIndex = -1;
            this.selectedAnimal = (Animal)Cage3Animals.SelectedItem;
            this.selectedCage = Zoo.CageIds.Cage3;
        }

        #endregion

        #region zookeeper
        /// <summary>
        /// Adding/hiring a new zookeeper
        /// </summary>
        /// <param name="sender">Caster over to the buttom</param>
        /// <param name="e">Registered changes in event</param>
        private void AddZookeeperButton_Click(object sender, RoutedEventArgs e)
        {
            zoo.AddZookeeper();
        }

        /// <summary>
        /// Selecting a zookeeper
        /// </summary>
        /// <param name="sender">Caster over to the buttom</param>
        /// <param name="e">Registered changes in event</param>
        private void Zookeepers_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            this.selectedZookeeper = (Zookeeper)Zookeepers.SelectedItem;
        }

        /// <summary>
        /// Remove/fyre a zookeeper
        /// </summary>
        /// <param name="sender">Caster over to the buttom</param>
        /// <param name="e">Registered changes in event</param>
        private void RemoveZookeeperButton_Click(object sender, RoutedEventArgs e)
        {
            if ( selectedZookeeper == null)
            {
                this.SetTextBlockOutput("You need to choose a zookeeper.");
                return;
            }
            zoo.RemoveZookeeper(selectedZookeeper);
        }
        #endregion

        #endregion
    }
}