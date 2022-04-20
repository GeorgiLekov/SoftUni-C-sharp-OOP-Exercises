using Gym.Models.Equipment.Contracts;
using Gym.Repositories.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Gym.Repositories
{
    public class EquipmentRepository : IRepository<IEquipment>
    {
        private List<IEquipment> modelsField;
        public EquipmentRepository()
        {
            modelsField = new List<IEquipment>();
        }
        public IReadOnlyCollection<IEquipment> Models { get; }

        public void Add(IEquipment model)
        {
            modelsField.Add(model);
        }

        public IEquipment FindByType(string type)
        {
            IEquipment result = modelsField.FirstOrDefault(model => model.GetType().Name == type);

            return result;
        }

        public bool Remove(IEquipment model)
        {
            bool result = modelsField.Remove(model);

            return result;
        }
    }
}
