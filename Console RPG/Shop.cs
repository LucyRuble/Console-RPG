using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Text;
using System.Threading;

namespace Console_RPG
{
    class Shop : Event
    {
        public string shopName;
        public List<Item> items;

        public Shop(string shopName, List<Item> items) : base(false)
        {
            this.shopName = shopName;
            this.items = items;
        }
        public override void Resolve(List<Player> players)
        {
            Console.WriteLine($"Weclome to {shopName}!");

            {
                while (true) 
                {
                    Console.WriteLine($"You have {Player.Money}$");
                    Console.WriteLine("What would you like to do");
                    Console.WriteLine("BUY | SELL | LEAVE");
                    string userInput = Console.ReadLine();
                    if (userInput == "buy")
                    {
                        Item item = ChooseItem(this.items);
                        Player.Money -= item.shopPrice;
                        Player.Inventory.Add(item);
                        Console.WriteLine($"You bought a {item.name}!");
                    }
                    else if (userInput == "sell")
                    {
                        Item item = ChooseItem(Player.Inventory);
                        Player.Money += item.shopPrice;
                        Player.Inventory.Remove(item);
                        Console.WriteLine($"You sold a {item.name}!");
                    }
                    else if (userInput == "leave")
                    {
                        break;
                    }
                }
            }
            Console.WriteLine("See ya!");
        }
        public Item ChooseItem(List<Item> Choices)
        {
            Console.WriteLine("Type in the number of the item you want to buy:");
            //Iterate through each choice
            for (int i = 0; i < Choices.Count; i++)
            {
                Console.WriteLine($"{i + 1}: {Choices[i].name} (${Choices[i].shopPrice})");
            }
            Console.WriteLine("10: back");

            //let the usar pick a choice
            int index = Convert.ToInt32(Console.ReadLine());
            if (index > Choices.Count)
            {
                Location.restaurant.Resolve(new List<Player>() { Player.Player1 });
            }
            return Choices[index - 1];
        }
    }
}
