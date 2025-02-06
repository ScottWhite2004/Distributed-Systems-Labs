using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using PipesAndFilters.Filters;
using PipesAndFilters.Messages;

namespace PipesAndFilters.Pipes
{
    internal interface IPipe
    {

        public void RegisterFilter(IFilter filter);

        public IMessage ProcessMessage(IMessage message);


    
    
    }
}
