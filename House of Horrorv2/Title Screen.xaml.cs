using System;
using System.Windows;

namespace House_of_Horrorv2
{
    public partial class TitleScreen : Window
    {
        public TitleScreen()
        {
            InitializeComponent();
        }

        private void StartGame_Click(object sender, RoutedEventArgs e)
        {
            // Display the game intro
            DisplayGameIntro();
        }

        private void DisplayGameIntro()
        {
            MessageBox.Show("You are a distant family member of a rich millionaire who just passed away, leaving his mansion to you.\n" +
                            "Now that you are the newfound owner, you decide to take a look inside.\n" +
                            "The house is dated, creaky, and falling apart. You cautiously step through the front door, ready for adventure.",
                            "Game Introduction", MessageBoxButton.OK, MessageBoxImage.Information);

            // Open the main game window after the intro is displayed
            MainWindow mainWindow = new MainWindow();
            mainWindow.Show();
            this.Close(); // Close the title screen
        }
    }
}
