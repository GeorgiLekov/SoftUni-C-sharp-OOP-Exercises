using Formula1.Models.Contracts;
using Formula1.Repositories.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Formula1.Repositories
{
    public class PilotRepository : IRepository<IPilot>
    {
        private readonly List<IPilot> modelsField;

        public PilotRepository()
        {
            modelsField = new List<IPilot>();
        }
        public IReadOnlyCollection<IPilot> Models
        {
            get
            {
                return modelsField;
            }
        }

        public void Add(IPilot model)
        {
            modelsField.Add(model);
        }

        public IPilot FindByName(string fullname)
        {
            var result = modelsField.FirstOrDefault(x => x.FullName == fullname);

            if (result == default)
            {
               result = null;
            }

            return result;
        }

        public bool Remove(IPilot pilot)
        {
            bool result = modelsField.Remove(pilot);

            return result;
        }
    }
}
