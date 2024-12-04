using System;

namespace House_of_Horrorv2
{
    public class Item
    {
        public string Name { get; set; }
        public int Quantity { get; set; }

        public Item(string name, int quantity = 1)
        {
            Name = name;
            Quantity = quantity;
        }

        public virtual void Use()
        {
            Console.WriteLine($"{Name} is used.");
        }

        public void Use(int amount)
        {
            Quantity -= amount;
            Console.WriteLine($"{amount} of {Name} is used.");
        }
    }

    public class Weapon : Item
    {
        public int Damage { get; set; }

        public Weapon(string name, int damage, int quantity = 1) : base(name, quantity)
        {
            Damage = damage;
        }

        public override void Use()
        {
            Console.WriteLine($"{Name} deals {Damage} damage.");
        }
    }

    public class HealthPotion : Item
    {
        public int HealthRestore { get; set; }

        public HealthPotion(string name, int healthRestore, int quantity = 1) : base(name, quantity)
        {
            HealthRestore = healthRestore;
        }

        public override void Use()
        {
            Console.WriteLine($"{Name} restores {HealthRestore} health.");
        }
    }

    public class GoldCoin : Item
    {
        public GoldCoin(string name, int quantity = 1) : base(name, quantity) { }

        public override void Use()
        {
            Console.WriteLine($"{Name} can be used to buy items.");
        }
    }
}
