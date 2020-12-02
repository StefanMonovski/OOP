using _02.FakeAxeAndDummy.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Tests
{
    public class FakeDummy : ITarget
    {
        public int Health => 0;

        public int GiveExperience() { return 20; }
        public bool IsDead() { return true; }
        public void TakeAttack(int attackPoints) { }
    }
}
