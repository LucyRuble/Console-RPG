using System;
using System.Collections.Generic;
using System.Text;

namespace Console_RPG
{
    class Location
    {
     public static Location beach = new Location("beach", " its oddly calming  \n  the only place you can to go (other than the ocean) is the street behind you");
     public static Location street = new Location("street", "looks perfect for a fight", new Battle(new List<Enemy>() { Enemy.slime, Enemy.slime2, Enemy.gremlin }));
     public static Location ocean = new Location("ocean", "I guess im gonna take a swim");
     public static Location park = new Location("park", "Reminds me of better times, I think im gonna go on the swings!");
     public static Location restaurant = new Location("restaurant", "looks tasty!", new Shop("Tasty eats", new List<Item>() { Item.potionI, Item.potionII, }));
     public static Location morestreet = new Location("more street", "more street so more to explore", new Battle(new List<Enemy>() { Enemy.angrypup}));
     public static Location coffeeshop = new Location("coffee shop", "ohhhh I wanna get somthing to drink!", new Shop("Hidden armory", new List<Item>() { Armor.BetterArmor, Weapon.BetterSword }));
     public static Location library = new Location("library", "I was just hoping to find a new read!");
     public static Location tower = new Location("tower", "Hrmm most likely worth exploring");
     public static Location towerending = new Location("tower's end", "seems climatic", new Battle(new List<Enemy>() { Enemy.BigBad}));
        public static Location gamesend = new Location("safty", "It seems my jouny has been compleat, I feel compleld to close the game");


        public string name;
        public string description;
        public Event Interaction;

        public Location north, east, south, west;

        public Location(string name, string description, Event interaction = null)
        {
            this.name = name;
            this.description = description;
            this.Interaction = interaction;
        }

        public void SetNearbyLocations(Location north = null, Location east = null, Location south = null, Location west = null)
        {    
            if (!(north is null))
            {
                this.north = north;
                north.south = this;
            }

            if (!(east is null))
            {
                this.east = east;
                 east.west = this;
            }

            if (!(south is null))
            {
                this.south = south;
                south.north = this;
            }

            if (!(west is null))
            {
                this.west = west;
                west.east = this;
            }
        }

        public void Resolve(List<Player> players)
        {
            //only resloves a battle if one is happeneing (Null checking)

            Console.WriteLine("You find yourself at a " + this.name + ".");
            Console.WriteLine(this.description);
            Interaction?.Resolve(players);
            if (!(north is null))
                Console.WriteLine("NORTH: " + this.north.name);

            if (!(east is null))
                Console.WriteLine("EAST: " + this.east.name);

            if (!(south is null))
                Console.WriteLine("SOUTH: " + this.south.name);

            if (!(west is null))
                Console.WriteLine("WEST: " + this.west.name);




            bool textloop = true;  
                Location nextLocation = null;
            while (textloop)
            {
                string direction = Console.ReadLine();

                if (direction == "north")
                {
                    nextLocation = this.north;
                    textloop = false;
                }

                else if (direction == "east")
                {
                    nextLocation = this.east;
                    textloop = false;
                }

                else if (direction == "south")
                {
                    nextLocation = this.south;
                    textloop = false;
                }

                else if (direction == "west")
                {
                    nextLocation = this.west;
                    textloop = false;
                }
                else
                {
                    Console.WriteLine("type a diretion in lower case");
                }
            }

            nextLocation.Resolve(players);

        }
    }
}
