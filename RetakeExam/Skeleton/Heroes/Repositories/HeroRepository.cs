using Heroes.Models.Contracts;
using Heroes.Repositories.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Heroes.Repositories
{
    public class HeroRepository : IRepository<IHero>
    {
        private List<IHero> modelsField;

        public HeroRepository()
        {
            modelsField = new List<IHero>();
        }
        public IReadOnlyCollection<IHero> Models { get { return modelsField; } }

        public void Add(IHero model)
        {
            modelsField.Add(model);
        }

        public IHero FindByName(string name)
        {
            var temp = modelsField.FirstOrDefault(x => x.Name == name);

            return temp;
        }

        public bool Remove(IHero model)
        {
            return modelsField.Remove(model);
        }
    }
}
