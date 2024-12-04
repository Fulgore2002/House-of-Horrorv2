using System.Windows;
using System.Windows.Controls;
using System.Windows.Threading;

namespace House_of_Horrorv2
{
    public partial class DiningRoom : UserControl
    {
        private Player player;

        public DiningRoom(Player player)
        {
            InitializeComponent();
            this.player = player;
        }

        private void VaseChoiceButton_Click(object sender, RoutedEventArgs e)
        {
            if (VaseChoiceButton.Content.ToString() == "Open the Vase")
            {
                DiningRoomText.Text += "\nYou open the vase and find a pile of bones.";
                player.Inventory.AddItem(new Item("Bones"));
                VaseChoiceButton.Content = "Leave the Vase";
            }
            else
            {
                DiningRoomText.Text += "\nYou decide not to open the vase.";
                DiningRoomText.Text += "\nAs you turn to leave, you hear a creaking sound coming from the corner.";
                DiningRoomText.Text += "\nA dark figure with glowing red eyes launches at you!";
                DiningRoomText.Text += "\nDo you want to run or fight? (run/fight) WARNING!";
                RunButton.Visibility = Visibility.Visible;
                FightButton.Visibility = Visibility.Visible;
                VaseChoiceButton.Visibility = Visibility.Collapsed;
            }
        }

        private void RunButton_Click(object sender, RoutedEventArgs e)
        {
            DiningRoomText.Text += "\nYou run as fast as you can and manage to escape the dark figure.";

            // Hide the Run and Fight buttons
            RunButton.Visibility = Visibility.Collapsed;
            FightButton.Visibility = Visibility.Collapsed;

        }


        private void FightButton_Click(object sender, RoutedEventArgs e)
        {
            DiningRoomText.Text += "\nYou try to fight the dark figure, but it overpowers you, knocking you unconscious.";
            DiningRoomText.Text += "\nYou wake up in your bed. It was all a dream.";
            player.Inventory.Clear();

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
