using NavalVessels.Models.Contracts;
using NavalVessels.Repositories.Contracts;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace NavalVessels.Repositories
{
    public class VesselRepository : IRepository<IVessel>
    {
        private readonly List<IVessel> modelsField;

        public VesselRepository()
        {
            modelsField = new List<IVessel>();
        }
        public IReadOnlyCollection<IVessel> Models { get { return modelsField; } }

        public void Add(IVessel model)
        {
            modelsField.Add(model);
        }

        public IVessel FindByName(string name)
        {

            return modelsField.FirstOrDefault(x => x.Name == name);
        }

        public bool Remove(IVessel model)
        {
            bool result = modelsField.Remove(model);

            return result;
        }
    }
}
