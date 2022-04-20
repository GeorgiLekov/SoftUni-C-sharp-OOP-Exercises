using Heroes.Models.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace Heroes.Models.Heroes
{
    public abstract class Hero : IHero
    {
        private string nameField;
        private int healthField;
        private int armorField;
        private IWeapon weaponField;

        public Hero(string name, int health, int armour)
        {
            Name = name;
            Health = health;
            Armour = armour;
        }
        public string Name
        {
            get
            {
                return nameField;
            }
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("Hero name cannot be null or empty.");
                }
                nameField = value;
            }
        }

        public int Health
        {
            get
            {
                return healthField;
            }
            private set
            {
                if (value < 0)
                {
                    throw new ArgumentException("Hero health cannot be below 0.");
                }
                healthField = value;
            }
        }


        public int Armour
        {
            get
            {
                return armorField;
            }
            private set
            {
                if (value < 0)
                {
                    throw new ArgumentException("Hero armour cannot be below 0.");
                }
                armorField = value;
            }
        }

        public IWeapon Weapon 
        {
            get
            {
                return weaponField;
            }
            private set
            {
                if (value == null)
                {
                    throw new ArgumentException("Weapon cannot be null.");
                }
                weaponField = value;
            }
        }

        public bool IsAlive 
        {
            get
            {
                if (Health > 0)
                {
                    return true;
                }
                return false;
            }
        }

        public void AddWeapon(IWeapon weapon)
        {
            Weapon = weapon;
        }

        public void TakeDamage(int points)
        {
            int temp = Armour - points;

            if(temp > 0)
            {
                Armour = temp;
            }
            else
            {
                Armour = 0;
                int dmgToHP = Math.Abs(temp);

                int result = Health - dmgToHP;

                if (result > 0)
                {
                    Health = result;
                }
                else
                {
                    Health = 0;
                }
            }
        }
    }
}
