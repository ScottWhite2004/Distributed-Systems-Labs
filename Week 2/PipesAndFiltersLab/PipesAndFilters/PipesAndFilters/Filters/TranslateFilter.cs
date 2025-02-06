using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PipesAndFilters.Messages;

namespace PipesAndFilters.Filters
{
    internal class TranslateFilter : IFilter
    {
        public IMessage Run(IMessage message)
        {
            foreach(string header in message.Headers.Keys)
            {
                if(header == "RequestFormat")
                {
                    byte[] bytes = Encoding.ASCII.GetBytes(message.Body);
                    string requestBody = "";
                    for(int i = 0; i < bytes.Length; i++)
                    {
                        requestBody += bytes[i].ToString();
                        if(i + 1 < bytes.Length)
                        {
                            requestBody += "-";
                        }
                    }
                    message.Body = requestBody;
                    return message;
                }
                else if(header == "ResponseFormat")
                {
                    string responseBody = "";
                    string[] byteString = message.Body.Split("-");
                    byte[] bytes = new byte[byteString.Length];
                    for(int i = 0;i < byteString.Length;i++)
                    {
                        bytes[i] = byte.Parse(byteString[i]);
                    }
                    responseBody = Encoding.ASCII.GetString(bytes);
                    message.Body = responseBody;
                    return message;
                }
            }
            return message;
        }
    }
}
