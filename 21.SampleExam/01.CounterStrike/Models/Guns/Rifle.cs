using System;
using System.Collections.Generic;
using System.Text;

namespace CounterStrike.Models.Guns
{
    class Rifle : Gun
    {
        public Rifle(string name, int bulletsCount)
            : base(name, bulletsCount)
        {
        }

        public override int Fire()
        {
            if (bulletsCount < 10)
            {
                return 0;
            }
            bulletsCount -= 10;
            return 10;
        }
    }
}
