using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Console_RPG
{
    class Player : Entity
    {
        public static List<Item> Inventory = new List<Item>() { Item.potionI, Item.potionII };
        public static int Money = 10;

        public static Player Player1 = new Player("Player", 50, new Stats(15, 20), 10);

        public int level;

        public Player(string name, int HP, Stats stats, int level) : base(name, HP, stats)
        {
            this.level = level;
        }


        public override Entity ChooseTarget(List<Entity> Choices)
        {
            Console.WriteLine("Type in the number of the enemy you want to attack!");
            //Iterate through each choice
            for (int i = 0; i < Choices.Count; i++)
            {
                Console.WriteLine($"{i + 1}: {Choices[i].name}");
            }
            //let the usar pick a choice
            try
            {
                int index = Convert.ToInt32(Console.ReadLine());
                return Choices[index - 1];
            }
            catch (Exception e)
            {
                return ChooseTarget(Choices);
            }
        }


        public Item ChooseItem(List<Item> Choices)
        {
            Console.WriteLine("Type in the number of the item you want to use!");
            //Iterate through each choice
            for (int i = 0; i < Choices.Count; i++)
            {
                Console.WriteLine($"{i + 1}: {Choices[i].name}");
            }
            //let the usar pick a choice
            int index = Convert.ToInt32(Console.ReadLine());
            return Choices[index - 1];
        }



        public override void Attack(Entity target)
        {
            Console.WriteLine(this.name + " attacked " + target.name);
            target.currentHP -= this.stats.Damage - target.stats.Defense;
            Console.WriteLine($"{this.name}  dealt  {this.stats.Damage - target.stats.Defense}  damage! ");
            Console.WriteLine($"{target.name} has {target.currentHP} remaining");
        }


public void UseItem(Item item, Entity target)
    {
        item.Use(this, target);
    }

        public override void DoTurn(List<Player> players, List<Enemy> enemies)
        {
            Console.WriteLine("What would you like to do?");
            Console.WriteLine("attack | money move (mm) | item");
            string choice = Console.ReadLine();

            if (choice == "attack")
            {
                Entity target = ChooseTarget(enemies.Cast<Entity>().ToList());
                Attack(target);
            }
            else if (choice == "mm")
            {
                Entity target = ChooseTarget(enemies.Cast<Entity>().ToList());
                Attack(target);
            }
            else if (choice == "item")
            {
            Item item = ChooseItem(Inventory);
            Entity target = ChooseTarget(players.Cast<Entity>().ToList());

            item.Use(this, target);
            Inventory.Remove(item);
            }
        }
    }
}
