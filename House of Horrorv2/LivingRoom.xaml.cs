using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Threading;

namespace House_of_Horrorv2
{
    public partial class LivingRoom : UserControl
    {
        private Player player;

        public LivingRoom(Player player)
        {
            InitializeComponent();
            this.player = player;
        }

        private void PitbullChoiceButton_Click(object sender, RoutedEventArgs e)
        {
            if (player.Inventory.HasItem("Bones"))
            {
                LivingRoomText.Text += "\nYou give the bones to the pitbull, who happily munches on them.";
                LivingRoomText.Text += "\nYou take the jewelry while the pitbull is distracted.";
                player.Inventory.AddItem(new Item("Gold Jewelry"));
                player.Inventory.RemoveItem("Bones");
            }
            else
            {
                LivingRoomText.Text += "\nYou attempt to steal the jewelry, but the pitbull wakes up and rips your shirt to shreds.";
                LivingRoomText.Text += "\nGame Over. You have been attacked by the pitbull.";
                player.GameOver = true;
                player.ClearInventory();
            }

            PitbullChoiceButton.Visibility = Visibility.Collapsed;
            RunButton.Visibility = Visibility.Collapsed;
            LeaveButton.Visibility = Visibility.Visible;
        }

        private void RunButton_Click(object sender, RoutedEventArgs e)
        {
            // Implement any logic needed when the player chooses to run
        }

        private void LeaveButton_Click(object sender, RoutedEventArgs e)
        {
            LivingRoomText.Text += "\nYou decide not to steal the dog's jewelry.";
            LivingRoomText.Text += "\nYou turn back and find your way out of the house safely.";

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
