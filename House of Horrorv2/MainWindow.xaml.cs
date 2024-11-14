using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Numerics;

namespace House_of_Horrorv2
{
    public partial class MainWindow : Window
    {
        private Player player;

        public MainWindow()
        {
            InitializeComponent();
            player = new Player("Your Name");
            ContentArea.Content = new LivingRoom(player); // Set the default content
        }

        private void LivingRoom_Click(object sender, RoutedEventArgs e)
        {
            ContentArea.Content = new LivingRoom(player);
        }

        private void DiningRoom_Click(object sender, RoutedEventArgs e)
        {
            ContentArea.Content = new DiningRoom(player);
        }

        private void Kitchen_Click(object sender, RoutedEventArgs e)
        {
            ContentArea.Content = new Kitchen(player);
        }

        private void Backyard_Click(object sender, RoutedEventArgs e)
        {
            ContentArea.Content = new Backyard(player);
        }

        private void MasterBedroom_Click(object sender, RoutedEventArgs e)
        {
            ContentArea.Content = new MasterBedroom(player);
        }
    }
}

