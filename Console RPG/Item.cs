using System;
using System.Collections.Generic;
using System.Text;

namespace Console_RPG
{

    abstract class Item
    {
        public static HealthPotionItem potionI = new HealthPotionItem("Health Potion I", "yuck", 10, 20, 10);
        public static HealthPotionItem potionII = new HealthPotionItem("Health Potion II", "yummy", 20, 10, 25);


        public string name;
        public string description;
        public int shopPrice;
        public int maxAmount;

        public Item(string name, string description, int shopPrice, int maxAmount)
        {
            this.name = name;
            this.description = description;
            this.shopPrice = shopPrice;
            this.maxAmount = maxAmount;
        }
        public abstract void Use(Entity user, Entity target);
    }

    class HealthPotionItem : Item
    {
        public int healAmount;

        public HealthPotionItem(string name, string description, int shopPrice, int maxAmount, int healAmount) : base(name, description, shopPrice, maxAmount)
        {
            this.healAmount = healAmount;
        }
        public override void Use(Entity user, Entity target)
        {
            user.currentHP += this.healAmount;
        }
        class ShootingBigBoomStickItem : Item
        {
            public int damage;
            public int ammo;

            public ShootingBigBoomStickItem(string name, string description, int shopPrice, int maxAmount, int damage, int ammo) : base(name, description, shopPrice, maxAmount)
            {
                this.damage = damage;
                this.ammo = ammo;
            }
            public override void Use(Entity user, Entity target)
            {
                if (ammo == 0)
                    return;

                target.currentHP -= this.damage;
                --ammo;
            }
         }
     }
}
