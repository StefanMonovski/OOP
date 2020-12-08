using System;
using System.Collections.Generic;
using System.Text;

namespace CounterStrike.Models.Guns
{
    public class Pistol : Gun
    {
        public Pistol(string name, int bulletsCount)
            :base(name, bulletsCount)
        {
        }

        public override int Fire()
        {
            if (bulletsCount < 1)
            {
                return 0;
            }
            bulletsCount -= 1;
            return 1;
        }
    }
}
