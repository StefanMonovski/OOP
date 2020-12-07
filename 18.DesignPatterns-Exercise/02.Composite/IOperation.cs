using System;
using System.Collections.Generic;
using System.Text;

namespace _02.Composite
{
    interface IOperation
    {
        void Add(GiftBase gift);
        void Remove(GiftBase gift);
    }
}
