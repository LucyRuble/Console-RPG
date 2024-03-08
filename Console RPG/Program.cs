using System;
using System.Collections.Generic;

namespace Console_RPG
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("You can't seem to rember anything, you only have a desire to get money ");
            Location.beach.SetNearbyLocations(south: Location.street, west: Location.ocean, north: Location.street);
            Location.street.SetNearbyLocations(east: Location.morestreet, west: Location.beach, north: Location.restaurant, south: Location.park);
            Location.morestreet.SetNearbyLocations(south: Location.tower, north: Location.coffeeshop, east: Location.library );
            Location.tower.SetNearbyLocations(south: Location.towerending);
            Location.towerending.SetNearbyLocations(south: Location.gamesend);
            Location.beach.Resolve(new List<Player>() {Player.Player1});




          
        }
    }
}
