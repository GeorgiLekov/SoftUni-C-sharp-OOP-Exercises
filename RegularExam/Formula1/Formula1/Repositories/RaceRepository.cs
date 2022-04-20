using Formula1.Models.Contracts;
using Formula1.Repositories.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Formula1.Repositories
{
    public class RaceRepository : IRepository<IRace>
    {
        private readonly List<IRace> modelsField;

        public RaceRepository()
        {
            modelsField = new List<IRace>();
        }
        public IReadOnlyCollection<IRace> Models
        {
            get
            {
                return modelsField;
            }
        }

        public void Add(IRace model)
        {
            modelsField.Add(model);
        }

        public IRace FindByName(string raceName)
        {
            var result = modelsField.FirstOrDefault(x => x.RaceName == raceName);

            if (result == default)
            {
                result = null;
            }

            return result;
        }

        public bool Remove(IRace race)
        {
            bool result = modelsField.Remove(race);

            return result;
        }
    }
}
