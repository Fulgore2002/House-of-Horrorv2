using System;
using System.Collections.Generic;
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
using House_of_Horrorv2;

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
            }
        }

        private void ShedChoiceButton_Click(object sender, RoutedEventArgs e)
        {
            BackyardText.Text += "\nYou use the rusty key to open the lock. The key breaks as you unlock the door. Inside, you find a hidden stash of gold coins.";
            player.Inventory.RemoveItem("Rusty Key");
            player.Inventory.AddItem("Gold Coins");
            ShedChoiceButton.Visibility = Visibility.Collapsed;
            LeaveButton.Visibility = Visibility.Visible;
        }

        private void LeaveButton_Click(object sender, RoutedEventArgs e)
        {
            BackyardText.Text += "\nAs you turn to leave, you hear a rustling sound coming from the bushes. Do you want to investigate the bushes? (yes/no) WARNING!";
            // Add logic for handling the investigation choice and possible game over scenario here.
        }
    }
}

