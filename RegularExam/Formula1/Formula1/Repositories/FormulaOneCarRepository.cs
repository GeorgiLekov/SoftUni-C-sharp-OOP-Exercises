using Formula1.Models.Contracts;
using Formula1.Repositories.Contracts;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace Formula1.Repositories
{
    public class FormulaOneCarRepository : IRepository<IFormulaOneCar>
    {
        private readonly List<IFormulaOneCar> modelsField;

        public FormulaOneCarRepository()
        {
            modelsField = new List<IFormulaOneCar>();
        }
        public IReadOnlyCollection<IFormulaOneCar> Models 
        {
            get
            {
                return modelsField;
            }
        }

        public void Add(IFormulaOneCar model)
        {
            modelsField.Add(model);
        }

        public IFormulaOneCar FindByName(string model)
        {
            var result = modelsField.FirstOrDefault(x => x.Model == model);

            if(result == default)
            {
                result = null;
            }

            return result;
        }

        public bool Remove(IFormulaOneCar model)
        {
            bool result = modelsField.Remove(model);

            return result;
        }
    }
}
