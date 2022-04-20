using Heroes.Models.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace Heroes.Models.Weapons
{
    public abstract class Weapon : IWeapon
    {
        private string nameField;
        private int durabilityField;

        public Weapon(string name, int durability)
        {
            Name = name;
            Durability = durability;
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
                    throw new ArgumentException("Weapon type cannot be null or empty.");
                }
                nameField = value;
            }
        }

        public int Durability
        {
            get
            {
                return durabilityField;
            }
            protected set
            {
                if (value < 0)
                {
                    throw new ArgumentException("Durability cannot be below 0.");
                }
                durabilityField = value;
            }
        }

        public abstract int DoDamage();
    }
}
