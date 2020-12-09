using EasterRaces.Models.Races.Contracts;
using EasterRaces.Repositories.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EasterRaces.Repositories
{
    class RaceRepository : IRepository<IRace>
    {
        private List<IRace> models;

        public RaceRepository()
        {
            models = new List<IRace>();
        }

        public IRace GetByName(string name)
        {
            if (models.Exists(x => x.Name == name))
            {
                return models.First(x => x.Name == name);
            }
            return null;
        }

        public IReadOnlyCollection<IRace> GetAll()
        {
            return models.AsReadOnly();
        }

        public void Add(IRace model)
        {
            models.Add(model);
        }

        public bool Remove(IRace model)
        {
            int count = models.Count;
            return models.Remove(model);
        }
    }
}
