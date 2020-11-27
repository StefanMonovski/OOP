using System;
using System.Collections.Generic;
using System.Text;

namespace _02.ExtendedDatabase
{
    public class Person
    {
        public Person(long id, string userName)
        {
            Id = id;
            UserName = userName;
        }

        public string UserName { get; private set; }

        public long Id { get; private set; }
    }
}
