using System;
using System.Collections.Generic;
using System.Linq;
namespace Console_RPG

{
    class Enemy : Entity
    {
        public static Enemy slime = new Enemy("slime", 5, new Stats(3, 3), 10, 5);
        public static Enemy slime2 = new Enemy("slime2", 5, new Stats(3, 3), 10, 5);
        public static Enemy gremlin = new Enemy("gremlin", 10, new Stats(8, 5), 10, 10);
        public static Enemy angrypup = new Enemy("angry pup", 7, new Stats(15, 7), 10, 15);
        public static Enemy BigBad = new Enemy("big bad", 20, new Stats(15, 15), 50, 50);

        public int xpOnDrop;
        public int MoneyDroppedOnDefeat;

        public Enemy(string name, int HP, Stats stats, int xpOnDrop, int MoneyDroppedOnDefeat) : base(name, HP, stats)
        {
            this.xpOnDrop = xpOnDrop;
            this.MoneyDroppedOnDefeat = MoneyDroppedOnDefeat;
        }
        
        //make a enemy hit you randomy
        public override Entity ChooseTarget(List<Entity> targets)
        {
            Random random = new Random();
            return targets[random.Next(0, targets.Count)];
        }
        public override void Attack(Entity target)
        {
            Console.WriteLine(this.name + " attacked " + target.name);
            target.currentHP -= this.stats.Damage - target.stats.Defense;
            Console.WriteLine($"{target.name}  took  {this.stats.Damage - target.stats.Defense}  damage ");
            Console.WriteLine($"{target.name} has {target.currentHP} remaining");
        }

        public override void DoTurn(List<Player> players, List<Enemy> enemies)
        {
            Entity target = ChooseTarget(players.Cast<Entity>().ToList());
            Attack(target);
        }
    }
}
