﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo
{
    public interface IConfigurationSettings<T> where T : class
    {
        T Get();
    }
}
