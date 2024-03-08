using System;
using System.Collections.Generic;
using System.Text;

namespace Console_RPG
{
    abstract class Equipment : Item
    {
        public bool isEquipped;

        protected Equipment(string name, string description, int shopPrice, int sellPrice) : base(name, description, shopPrice, sellPrice)
        {
            this.isEquipped = false;
        }
    }

    class Armor : Equipment
    {
        public static Armor BetterArmor = new Armor("Better Armor", "Seems sturdy", 10, 10, 25);
        public int defense;

        public Armor(string name, string description, int shopPrice, int sellPrice, int defense) : base(name, description, shopPrice, sellPrice)
        {
            this.defense = defense;
        }

        public override void Use(Entity user, Entity target)
        {
            //flips the value of wether or not its equipped
            this.isEquipped = !this.isEquipped;

            if (this.isEquipped) 
            {
                //Increase the targets defense if they equip the item
                target.stats.Defense += this.defense;
            }
            else
            {
                //Describe the targets defense if they unequip the item
                target.stats.Defense -= this.defense;
            }
        }
    }

    class Weapon : Equipment
    {
        public static Weapon BetterSword = new Weapon("Better Sword", "Looks sharp", 10, 10, 25);
        public int damage;

        public Weapon(string name, string description, int shopPrice, int sellPrice, int damage) : base(name, description, shopPrice, sellPrice)
        {
            this.damage = damage;
        }

        public override void Use(Entity user, Entity target)
        {
            //flips the value of wether or not its equipped
            this.isEquipped = !this.isEquipped;

            if (this.isEquipped)
            {
                //Increase the targets damage if they equip the item
                target.stats.Damage += this.damage;
            }
            else
            {
                //Describe the targets damage if they unequip the item
                target.stats.Damage -= this.damage;
            }
        }
    }
}
