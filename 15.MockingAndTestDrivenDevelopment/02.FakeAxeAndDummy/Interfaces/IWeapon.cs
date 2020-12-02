using System;
using System.Collections.Generic;
using System.Text;

namespace _02.FakeAxeAndDummy.Interfaces
{
    public interface IWeapon
    {
        int AttackPoints { get; }
        int DurabilityPoints { get; }

        void Attack(ITarget target);
    }
}
