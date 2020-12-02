using _02.FakeAxeAndDummy.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Tests
{
    public class FakeAxe : IWeapon
    {
        public int AttackPoints => 10;
        public int DurabilityPoints => 10;

        public void Attack(ITarget target) { }
    }
}
