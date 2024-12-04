namespace House_of_Horrorv2
{
    public class Player
    {
        public string Name { get; set; }
        public Inventory Inventory { get; private set; }
        public bool GameOver { get; set; }

        public Player(string name)
        {
            Name = name;
            Inventory = new Inventory();
            GameOver = false;
        }

        public void ShowInventory()
        {
            Inventory.ShowInventory();
        }

        public void ClearInventory()
        {
            Inventory.Clear();
        }
    }
}
