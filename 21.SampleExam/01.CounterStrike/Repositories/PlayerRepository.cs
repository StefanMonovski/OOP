using CounterStrike.Models.Players.Contracts;
using CounterStrike.Repositories.Contracts;
using CounterStrike.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Text;

namespace CounterStrike.Repositories
{
    class PlayerRepository : IRepository<IPlayer>
    {
        private List<IPlayer> models;
        public IReadOnlyCollection<IPlayer> Models { get { return models.AsReadOnly(); } }

        public PlayerRepository()
        {
            models = new List<IPlayer>();
        }

        public void Add(IPlayer model)
        {
            if (model is null)
            {
                throw new ArgumentException(ExceptionMessages.InvalidGunRepository);
            }
            models.Add(model);
        }

        public bool Remove(IPlayer model)
        {
            int count = models.Count;
            models.Remove(model);
            if (models.Count == count - 1)
            {
                return true;
            }
            return false;
        }

        public IPlayer FindByName(string name)
        {
            foreach (var item in models)
            {
                if (item.Username == name)
                {
                    return item;
                }
            }
            return null;
        }
    }
}
