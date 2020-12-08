using CounterStrike.Core.Contracts;
using CounterStrike.Models.Guns;
using CounterStrike.Models.Guns.Contracts;
using CounterStrike.Models.Maps;
using CounterStrike.Models.Maps.Contracts;
using CounterStrike.Models.Players;
using CounterStrike.Models.Players.Contracts;
using CounterStrike.Repositories;
using CounterStrike.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CounterStrike.Core
{
    class Controller : IController
    {
        private List<IPlayer> playersModels;
        private GunRepository guns;
        private PlayerRepository players;
        private IMap map;

        public Controller()
        {
            guns = new GunRepository();
            players = new PlayerRepository();
            map = new Map();
            playersModels = new List<IPlayer>();
        }

        public string AddGun(string type, string name, int bulletsCount)
        {
            IGun gun = null;
            if (type != "Pistol" && type != "Rifle")
            {
                throw new ArgumentException(ExceptionMessages.InvalidGunType);
            }
            else if (type == "Pistol")
            {
                gun = new Pistol(name, bulletsCount);
            }
            else if (type == "Rifle")
            {
                gun = new Rifle(name, bulletsCount);
            }
            guns.Add(gun);
            return string.Format(OutputMessages.SuccessfullyAddedGun, name);
        }

        public string AddPlayer(string type, string username, int health, int armor, string gunName)
        {
            IGun gun = guns.FindByName(gunName);
            if (gun is null)
            {
                throw new ArgumentException(ExceptionMessages.GunCannotBeFound);
            }

            IPlayer player = null;
            if (type != "Terrorist" && type != "CounterTerrorist")
            {
                throw new ArgumentException(ExceptionMessages.InvalidPlayerType);
            }
            else if (type == "Terrorist")
            {
                player = new Terrorist(username, health, armor, gun);
            }
            else if (type == "CounterTerrorist")
            {
                player = new CounterTerrorist(username, health, armor, gun);
            }
            players.Add(player);
            playersModels.Add(player);
            return string.Format(OutputMessages.SuccessfullyAddedPlayer, username);
        }

        public string StartGame()
        {           
            return map.Start(playersModels);
        }

        public string Report()
        {
            StringBuilder sb = new StringBuilder();
            foreach (IPlayer item in playersModels.OrderBy(x => x.GetType().Name).ThenByDescending(x => x.Health).ThenBy(x => x.Username))
            {               
                sb.AppendLine($"{item.GetType().Name}: {item.Username}");
                sb.AppendLine($"--Health: {item.Health}");
                sb.AppendLine($"--Armor: {item.Armor}");
                sb.AppendLine($"--Gun: {item.Gun.Name}");
            }
            return sb.ToString().Trim();
        }
    }
}
