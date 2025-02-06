using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PipesAndFilters.Messages;

namespace PipesAndFilters.Filters
{
    internal class AuthenticateFilter : IFilter
    {
        public IMessage Run(IMessage message)
        {
            foreach(string header in message.Headers.Keys)
            {
                if(header == "User")
                {
                    int value = int.Parse(message.Headers[header]);
                    ServerEnvironment.SetCurrentUser(value);
                    return message;
                }
            }
            return message;
        }
    }
}
