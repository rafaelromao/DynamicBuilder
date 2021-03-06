﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DynamicBuilder
{
    public interface IBuilder<T> where T : new()
    {
        T Value { get; }
    }
}
