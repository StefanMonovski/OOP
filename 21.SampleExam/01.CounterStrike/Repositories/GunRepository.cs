using CounterStrike.Models.Guns.Contracts;
using CounterStrike.Repositories.Contracts;
using CounterStrike.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Text;

namespace CounterStrike.Repositories
{
    class GunRepository : IRepository<IGun>
    {
        private List<IGun> models;
        public IReadOnlyCollection<IGun> Models { get { return models.AsReadOnly(); } }

        public GunRepository()
        {
            models = new List<IGun>();
        }

        public void Add(IGun model)
        {
            if (model is null)
            {
                throw new ArgumentException(ExceptionMessages.InvalidGunRepository);
            }
            models.Add(model);
        }

        public bool Remove(IGun model)
        {
            int count = models.Count;
            models.Remove(model);
            if (models.Count == count - 1)
            {
                return true;
            }
            return false;
        }

        public IGun FindByName(string name)
        {
            foreach (var item in models)
            {
                if (item.Name == name)
                {
                    return item;
                }
            }
            return null;
        }
    }
}
