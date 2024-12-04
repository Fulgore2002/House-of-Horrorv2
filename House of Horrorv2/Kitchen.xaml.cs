using System.Windows;
using System.Windows.Controls;
using System.Windows.Threading;

namespace House_of_Horrorv2
{
    public partial class Kitchen : UserControl
    {
        private Player player;

        public Kitchen(Player player)
        {
            InitializeComponent();
            this.player = player;
        }

        private void FridgeChoiceButton_Click(object sender, RoutedEventArgs e)
        {
            KitchenText.Text += "\nYou open the refrigerator and find some expired food.";
            KitchenText.Text += "\nAs you take a closer look, you hear a noise coming from the pantry.";
            PantryChoiceButton.Visibility = Visibility.Visible;
            FridgeChoiceButton.Visibility = Visibility.Collapsed;
        }

        private void PantryChoiceButton_Click(object sender, RoutedEventArgs e)
        {
            KitchenText.Text += "\nDo you want to investigate the noise coming from the pantry? (yes/no) WARNING!";
            YesButton.Visibility = Visibility.Visible;
            NoButton.Visibility = Visibility.Visible;
            PantryChoiceButton.Visibility = Visibility.Collapsed;
        }

        private void YesButton_Click(object sender, RoutedEventArgs e)
        {
            KitchenText.Text += "\nYou investigate the pantry and find a ghostly figure! It attacks you!";
            KitchenText.Text += "\nGame Over. You have been attacked by a ghost.";
            player.ClearInventory();
            YesButton.Visibility = Visibility.Collapsed;
            NoButton.Visibility = Visibility.Collapsed;
        }

        private void NoButton_Click(object sender, RoutedEventArgs e)
        {
            KitchenText.Text += "\nYou decide not to investigate the noise coming from the pantry.";
            KitchenText.Text += "\nAs you turn to leave, you hear a whispering sound coming from behind the refrigerator. However, a calm feeling washes over you.";
            WhisperChoiceButton.Visibility = Visibility.Visible;
            YesButton.Visibility = Visibility.Collapsed;
            NoButton.Visibility = Visibility.Collapsed;
        }

        private void WhisperChoiceButton_Click(object sender, RoutedEventArgs e)
        {
            KitchenText.Text += "\nDo you want to investigate the noise behind the refrigerator? (yes/no)";
            YesWhisperButton.Visibility = Visibility.Visible;
            NoWhisperButton.Visibility = Visibility.Visible;
            WhisperChoiceButton.Visibility = Visibility.Collapsed;
        }

        private void YesWhisperButton_Click(object sender, RoutedEventArgs e)
        {
            KitchenText.Text += "\nYou investigate the noise and find a ghostly figure!";
            KitchenText.Text += "\nThe ghostly figure holds out a rusty key and whispers, 'Take it...'";
            player.Inventory.AddItem(new Item("Rusty Key"));
            KitchenText.Text += "\nYou take the rusty key and the ghostly figure vanishes.";
            YesWhisperButton.Visibility = Visibility.Collapsed;
            NoWhisperButton.Visibility = Visibility.Collapsed;
        }

        private void NoWhisperButton_Click(object sender, RoutedEventArgs e)
        {
            KitchenText.Text += "\nYou decide not to investigate the noise and leave the kitchen.";

            // Introduce a short delay before shutting down the application
            var timer = new DispatcherTimer { Interval = TimeSpan.FromSeconds(5) };
            timer.Tick += (s, args) =>
            {
                timer.Stop();
                Application.Current.Shutdown(); // End the game
            };
            timer.Start();
        }
    }
}
