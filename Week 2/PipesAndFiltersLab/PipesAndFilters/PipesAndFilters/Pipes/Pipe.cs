using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PipesAndFilters.Filters;
using PipesAndFilters.Messages;

namespace PipesAndFilters.Pipes
{
    internal class Pipe : IPipe
    {
        
        private List<IFilter> Filters { get; set; }
        public IMessage ProcessMessage(IMessage message)
        {
            IMessage returnMessage = message;
            foreach (IFilter filter in Filters)
            {
                filter.Run(returnMessage);
            }
            return returnMessage;
        }

        public void RegisterFilter(IFilter filter)
        {
            Filters.Add(filter);
        }
    }
}
