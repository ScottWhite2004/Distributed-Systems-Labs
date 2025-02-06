using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PipesAndFilters.Messages;

namespace PipesAndFilters.Filters
{
    internal class TimestampFilter : IFilter
    {
        public IMessage Run(IMessage message)
        {
            string time = DateTime.Now.ToString();
            message.Headers.Add("Timestamp",time);
            return message;
        }
    }
}
