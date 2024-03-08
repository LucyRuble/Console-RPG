using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace Console_RPG
{
    class Battle : Event
    {
        public List<Enemy> enemies;

        public Battle(List<Enemy> enemies) : base(false)
        {
            this.enemies = enemies;
        }

        public override void Resolve(List<Player> players)
        {
            Console.WriteLine("You find youself surrounded");
            while (true)
            {
                //Run this code on each player
                foreach (var player in players)
                {
                    if (player.currentHP > 0)
                    {
                        
                        Console.WriteLine("It's " + player.name + "'s turn.");
                        player.DoTurn(players, enemies);
                    }
                }
                // Run this code on each enemies
                foreach (var enemy in enemies)
                {
                    if (enemy.currentHP > 0)
                    {
                        Console.WriteLine("It's " + enemy.name + "'s turn.");
                        enemy.DoTurn(players, enemies);
                    }
                }
                // If all players die.....
                if (players.TrueForAll(player => player.currentHP <= 0))
                {
                    Console.WriteLine("You suck");
                    break;
                }
                //If all enemies die
                if (enemies.TrueForAll(Enemy => Enemy.currentHP <= 0))
                {
                    Console.WriteLine("Victory");
                    // Other enemy death stuff like EXP and money
                    foreach (var item in enemies)
                    {
                        Player.Money += item.MoneyDroppedOnDefeat;
                    }
                    break;
                }
            }
            // Anything thatt happens no matter who wins

        }
    }
}
