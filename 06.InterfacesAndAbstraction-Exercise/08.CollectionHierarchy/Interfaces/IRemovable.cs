﻿using System;
using System.Collections.Generic;
using System.Text;

namespace _08.CollectionHierarchy.Interfaces
{
    interface IRemovable : IAddable
    {
        string Remove();
    }
}
