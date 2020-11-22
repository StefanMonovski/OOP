﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ValidationAttributes.Attributes
{
    class MyRequiredAttribute : MyValidationAttribute
    {
        public override bool IsValid(object obj)
        {
            if (obj != null)
            {
                return true;
            }
            return false;
        }
    }
}
