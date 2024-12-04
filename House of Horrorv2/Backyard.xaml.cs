using System.Windows;
using System.Windows.Controls;
using System.Windows.Threading;

namespace House_of_Horrorv2
{
    public partial class Backyard : UserControl
    {
        private Player player;

        public Backyard(Player player)
        {
            InitializeComponent();
            this.player = player;
        }

        private void KeyCheckButton_Click(object sender, RoutedEventArgs e)
        {
            if (!player.Inventory.HasItem("Rusty Key"))
            {
                BackyardText.Text += "\nYou don't have the key to open the lock.";
            }
            else
            {
                BackyardText.Text += "\nDo you want to try the rusty key on the lock?";
                ShedChoiceButton.Visibility = Visibility.Visible;
                KeyCheckButton.Visibility = Visibility.Collapsed;

            }
        }

        private void ShedChoiceButton_Click(object sender, RoutedEventArgs e)
        {
            BackyardText.Text += "\nYou use the rusty key to open the lock. The key breaks as you unlock the door. Inside, you find a hidden stash of gold coins.";
            player.Inventory.RemoveItem("Rusty Key");
            player.Inventory.AddItem(new Item("Gold Coins"));
            ShedChoiceButton.Visibility = Visibility.Collapsed;
            LeaveButton.Visibility = Visibility.Visible;
        }

        private void LeaveButton_Click(object sender, RoutedEventArgs e)
        {
            BackyardText.Text += "\nAs you turn to leave, you hear a rustling sound coming from the bushes. Do you want to investigate the bushes? (yes/no)";
            YesButton.Visibility = Visibility.Visible;
            NoButton.Visibility = Visibility.Visible;
            LeaveButton.Visibility = Visibility.Collapsed;
        }

        private void YesButton_Click(object sender, RoutedEventArgs e)
        {
            BackyardText.Text += "\nYou decide to investigate the bushes and find a hidden pathway.";
            BackyardText.Text += "\nSuddenly, a raccoon jumps out and attacks you!";
            BackyardText.Text += "\nGame Over. You have been attacked by a raccoon.";

            // Hide the Yes and No buttons
            YesButton.Visibility = Visibility.Collapsed;
            NoButton.Visibility = Visibility.Collapsed;

            // Introduce a short delay before shutting down the application
            var timer = new DispatcherTimer { Interval = TimeSpan.FromSeconds(5) };
            timer.Tick += (s, args) =>
            {
                timer.Stop();
                Application.Current.Shutdown(); // End the game
            };
            timer.Start();
        }


        private void NoButton_Click(object sender, RoutedEventArgs e)
        {
            BackyardText.Text += "\nYou decide not to investigate the bushes and leave the backyard.";
            YesButton.Visibility = Visibility.Collapsed;
            NoButton.Visibility = Visibility.Collapsed;


        }
    }
}
