using Heroes.Models.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Heroes.Repositories.Contracts
{
    public class WeaponRepository : IRepository<IWeapon>
    {
        private List<IWeapon> modelsField;

        public WeaponRepository()
        {
            modelsField = new List<IWeapon>();
        }
        public IReadOnlyCollection<IWeapon> Models { get { return modelsField; } }

        public void Add(IWeapon model)
        {
            modelsField.Add(model);
           
        }

        public IWeapon FindByName(string name)
        {
            var temp = modelsField.FirstOrDefault(x => x.Name == name);

            return temp;
        }

        public bool Remove(IWeapon model)
        {
            return modelsField.Remove(model);
        }
    }
}
