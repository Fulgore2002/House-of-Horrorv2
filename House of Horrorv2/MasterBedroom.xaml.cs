using System.IO;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Threading;

namespace House_of_Horrorv2
{
    public partial class MasterBedroom : UserControl
    {
        private Player player;

        public MasterBedroom(Player player)
        {
            InitializeComponent();
            this.player = player;
        }

        private void WardrobeChoiceButton_Click(object sender, RoutedEventArgs e)
        {
            MasterBedroomText.Text += "\nYou open the wardrobe and find a skeleton holding a golden locket and a Holy Relic.";
            MasterBedroomText.Text += "\nDo you want to take the locket and the Holy Relic? (yes/no)";
            ItemChoiceButton.Visibility = Visibility.Visible;
        }

        private void ItemChoiceButton_Click(object sender, RoutedEventArgs e)
        {
            MasterBedroomText.Text += "\nYou take the golden locket and the Holy Relic, feeling a chill run down your spine.";
            player.Inventory.AddItem(new Item("Golden Locket"));
            player.Inventory.AddItem(new Item("Holy Relic"));
            ItemChoiceButton.Visibility = Visibility.Collapsed;
            LeaveButton.Visibility = Visibility.Visible;
        }

        private void LeaveButton_Click(object sender, RoutedEventArgs e)
        {
            MasterBedroomText.Text += "\nAs you explore further, you suddenly feel a cold presence in the room.";
            MasterBedroomText.Text += "\nThe ghost from the dining room appears and floats towards you.";
            MasterBedroomText.Text += "\nIt looks at you with longing but doesn't take anything.";
            MasterBedroomText.Text += "\nThe ghost nods and vanishes, leaving you to explore the rest of the room.";

            if (player.Inventory.HasItem("Gold Coins") && player.Inventory.HasItem("Gold Jewelry") && player.Inventory.HasItem("Holy Relic") && player.Inventory.HasItem("Golden Locket"))
            {
                MasterBedroomText.Text += "\nAs you explore further, you notice a hidden door behind a tapestry.";
                MasterBedroomText.Text += "\nWith the gold coins, gold jewelry, golden locket, and Holy Relic in your possession, the ghost reappears and nods approvingly.";
                MasterBedroomText.Text += "\nThe ghost opens the hidden door, revealing a staircase to the attic.";
                CleansingHouse(); // Call the CleansingHouse method
            }
            else
            {
                MasterBedroomText.Text += "\nYou notice a hidden door behind a tapestry, but it remains tightly shut. It seems you need more items to unlock it.";
            }

            // Introduce a short delay before shutting down the application
            var timer = new DispatcherTimer { Interval = TimeSpan.FromSeconds(30) };
            timer.Tick += (s, args) =>
            {
                timer.Stop();
                Application.Current.Shutdown(); // End the game
            };
            timer.Start();
        }

        private void CleansingHouse()
        {
            MasterBedroomText.Text += "\nYou use the Holy Relic and the golden locket, Gold Jewelry, and gold coins to cleanse the house of all ghosts.";
            MasterBedroomText.Text += "\nThe spirits are finally at peace, and the mansion feels lighter and more welcoming.";

            // Remove items from the inventory
            player.Inventory.RemoveItem("Gold Coins");
            player.Inventory.RemoveItem("Gold Jewelry");
            player.Inventory.RemoveItem("Holy Relic");
            player.Inventory.RemoveItem("Golden Locket");

            // Display the congratulatory message
            //External Data
            string relativePath = @"..\..\..\data\Congratulations.txt";
            string absolutePath = Path.GetFullPath(relativePath);

            try
            {
                string fileContent = File.ReadAllText(absolutePath);
                MasterBedroomText.Text += "\n" + fileContent;
            }
            catch (FileNotFoundException)
            {
                MasterBedroomText.Text += "\nFile not found. Please check the path and filename.";
            }

            player.ClearInventory();
        }
    }
}
