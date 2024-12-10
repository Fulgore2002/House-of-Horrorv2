using System;
using System.Windows;

namespace House_of_Horrorv2
{
    public partial class MainWindow : Window
    {
        private Player player;

        /*
        House of Horror
        In this game you play as an anonymous adventurer trying to make a name for themselves by being the first to explore an old and forgotten house.
        This game is going to be about exploring an old, haunted house trying to find jewels or cash (Money).
        You will also find items that you can take and use in other rooms to help you get through the house.
        Tyler Hitchcock
        12/10/2024
        Credits: idea from the YouTuber Shaun Halverson
        */

        public MainWindow()
        {
            InitializeComponent();
            player = new Player("Your Name");
            ContentArea.Content = new LivingRoom(player); // Set the default content

            // Load and play background music
            string relativePath = @"..\..\..\data\mrthenoronha__horror-theme.mp3";
            BackgroundMusic.Source = new Uri(System.IO.Path.GetFullPath(relativePath));
            BackgroundMusic.Play();

            UpdateInventoryDisplay();
        }

        private void BackgroundMusic_MediaEnded(object sender, RoutedEventArgs e)
        {
            BackgroundMusic.Position = TimeSpan.Zero;
            BackgroundMusic.Play();
        }

        private void UpdateInventoryDisplay()
        {
            InventoryTextBlock.Text = player.Inventory.GetInventoryString();
        }

        private void LivingRoom_Click(object sender, RoutedEventArgs e)
        {
            ContentArea.Content = new LivingRoom(player);
            UpdateInventoryDisplay();
        }

        private void DiningRoom_Click(object sender, RoutedEventArgs e)
        {
            ContentArea.Content = new DiningRoom(player);
            UpdateInventoryDisplay();
        }

        private void Kitchen_Click(object sender, RoutedEventArgs e)
        {
            ContentArea.Content = new Kitchen(player);
            UpdateInventoryDisplay();
        }

        private void Backyard_Click(object sender, RoutedEventArgs e)
        {
            ContentArea.Content = new Backyard(player);
            UpdateInventoryDisplay();
        }

        private void MasterBedroom_Click(object sender, RoutedEventArgs e)
        {
            ContentArea.Content = new MasterBedroom(player);
            UpdateInventoryDisplay();
        }
    }
}
