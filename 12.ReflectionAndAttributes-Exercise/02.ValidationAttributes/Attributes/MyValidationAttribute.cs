﻿using System;
using System.Collections.Generic;
using System.Text;

namespace ValidationAttributes.Attributes
{
    abstract class MyValidationAttribute : Attribute
    {
        public abstract bool IsValid(object obj);
    }
}
