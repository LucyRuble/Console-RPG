using System.Collections.Generic;
using System.Text;

namespace Console_RPG
{
    abstract class Entity
    {
        public string name;

        public int currentHP, maxHP;
        public int currentMoney, maxMoney;

        public Stats stats;

        public Entity(string name, int HP, Stats stats)
        {
            this.name = name;
            this.currentHP = HP;
            this.maxHP = HP;
            this.stats = stats;

        }
        // Abstract functions can be overriden by their derived class
        public abstract void DoTurn(List<Player> players, List<Enemy> enemies);

        public abstract Entity ChooseTarget(List<Entity> targets);

        public abstract void Attack(Entity target);

        //public abstract void ChooseMove(List<Money_Move>);

        public void UseItem(Item item, Entity target)
        {
            item.Use(this, target);
        }
    }
    
}

