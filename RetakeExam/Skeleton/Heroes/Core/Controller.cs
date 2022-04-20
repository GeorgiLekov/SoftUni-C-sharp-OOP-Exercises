using Heroes.Core.Contracts;
using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using Heroes.Repositories;
using Heroes.Repositories.Contracts;
using Heroes.Models.Heroes;
using Heroes.Models.Weapons;
using Heroes.Models.Map;
using Heroes.Models.Contracts;

namespace Heroes.Core
{
    public class Controller : IController
    {
        private HeroRepository heroes;
        private WeaponRepository weapons;

        public Controller()
        {
            heroes = new HeroRepository();
            weapons = new WeaponRepository();
        }
        public string AddWeaponToHero(string weaponName, string heroName)
        {
            var heroTemp = heroes.FindByName(heroName);

            if(heroTemp == default)
            {
                throw new InvalidOperationException($"Hero { heroName } does not exist.");
            }

            var weaponTemp = weapons.FindByName(weaponName);

            if(weaponTemp == default)
            {
                throw new InvalidOperationException($"Weapon { weaponName } does not exist.");
            }

            if (heroTemp.Weapon != null)
            {
                throw new InvalidOperationException($"Hero { heroName } is well-armed.");
            }

            heroTemp.AddWeapon(weaponTemp);

            return $"Hero {heroName} can participate in battle using a { weaponTemp.GetType().Name.ToLower()}.";
        }

        public string CreateHero(string type, string name, int health, int armour)
        {
            var temp = heroes.FindByName(name);

            if (temp != default)
            {
                throw new InvalidOperationException($"The hero {name} already exists.");
            }

            if(type == "Barbarian")
            {
                Barbarian barbarian = new Barbarian(name, health, armour);
                heroes.Add(barbarian);
            }
            else if(type == "Knight")
            {
                Knight knight = new Knight(name, health, armour);
                heroes.Add(knight);

                return $"Successfully added Sir { name } to the collection.";
            }
            else
            {
                throw new InvalidOperationException("Invalid hero type.");
            }
            return $"Successfully added Barbarian { name } to the collection.";
        }

        public string CreateWeapon(string type, string name, int durability)
        {
            var temp = weapons.FindByName(name);

            if(temp != default)
            {
                throw new InvalidOperationException($"The weapon { name } already exists.");
            }

            if(type == "Claymore")
            {
                Claymore claymore = new Claymore(name, durability);
                weapons.Add(claymore);
            }
            else if (type == "Mace")
            {
                Mace mace = new Mace(name, durability);
                weapons.Add(mace);
            }
            else
            {
                throw new InvalidOperationException("Invalid weapon type.");
            }

            var printType = type.ToLower();

            return $"A { printType } { name } is added to the collection.";
        }

        public string HeroReport()
        {
            var result = heroes.Models.OrderBy(x => x.GetType().Name).ThenByDescending(x => x.Health).ThenBy(x => x.Name).ToList();

            StringBuilder stringBuilder = new StringBuilder();

            foreach(var item in result)
            {
                stringBuilder.AppendLine($"{item.GetType().Name}: { item.Name}");
                stringBuilder.AppendLine($"--Health: {item.Health}");
                stringBuilder.AppendLine($"--Armour: {item.Armour}");

                if(item.Weapon == null)
                {
                    stringBuilder.AppendLine($"--Weapon: Unarmed");
                }
                else
                {
                    stringBuilder.AppendLine($"--Weapon: {item.Weapon.Name}");
                }
            }

            return stringBuilder.ToString().TrimEnd();
        }

        public string StartBattle()
        {
            Map map = new Map();

            List<IHero> combatants = new List<IHero>();

            foreach(var item in heroes.Models)
            {
                if(item.Weapon != null && item.Health > 0)
                {
                    combatants.Add(item);
                }
            }

            return map.Fight(combatants);
        }
    }
}
