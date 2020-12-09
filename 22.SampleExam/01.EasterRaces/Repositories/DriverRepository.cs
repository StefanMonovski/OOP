using EasterRaces.Models.Drivers.Contracts;
using EasterRaces.Repositories.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EasterRaces.Repositories
{
    class DriverRepository : IRepository<IDriver>
    {
        private List<IDriver> models;

        public DriverRepository()
        {
            models = new List<IDriver>();
        }

        public IDriver GetByName(string name)
        {
            if (models.Exists(x => x.Name == name))
            {
                return models.First(x => x.Name == name);
            }
            return null;
        }

        public IReadOnlyCollection<IDriver> GetAll()
        {
            return models.AsReadOnly();
        }

        public void Add(IDriver model)
        {
            models.Add(model);
        }

        public bool Remove(IDriver model)
        {
            int count = models.Count;
            return models.Remove(model);
        }
    }
}
