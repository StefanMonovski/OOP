using EasterRaces.Models.Cars.Contracts;
using EasterRaces.Repositories.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EasterRaces.Repositories
{
    class CarRepository : IRepository<ICar>
    {
        private List<ICar> models;

        public CarRepository()
        {
            models = new List<ICar>();
        }

        public ICar GetByName(string name)
        {
            if (models.Exists(x => x.Model == name))
            {
                return models.First(x => x.Model == name);
            }
            return null;
        }

        public IReadOnlyCollection<ICar> GetAll()
        {
            return models.AsReadOnly();
        }

        public void Add(ICar model)
        {
            models.Add(model);
        }

        public bool Remove(ICar model)
        {
            int count = models.Count;
            return models.Remove(model);
        }
    }
}
