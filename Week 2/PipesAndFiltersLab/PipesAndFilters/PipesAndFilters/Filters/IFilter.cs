﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PipesAndFilters.Messages;

namespace PipesAndFilters.Filters
{
    internal interface IFilter
    {
    
    public IMessage Run(IMessage message);
    
    }
}
