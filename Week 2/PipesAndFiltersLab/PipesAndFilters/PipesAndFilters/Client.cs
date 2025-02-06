using System;
using System.Collections.Generic;
using System.Text;
using PipesAndFilters.Messages;

namespace PipesAndFilters
{
    class Client
    {
        int userId = 1;
        public void RequestHello(string messageToSend)
        {
            IMessage message = new Message();

            // Add the user ID header
            message.Headers.Add("User", userId.ToString());

            // Convert the message to a byte array and then turn the byte array into a string of byte values delimited by dashes
            message.Headers.Add("RequestFormat", "Bytes");

            // Send the message and get the response back
            IMessage response = ServerEnvironment.SendRequest(message);

            // Get the timestamp from the response
            response.Headers.TryGetValue("Timestamp", out string timestamp);
            
            string responseBody = response.Body;
           
            // Output the response to the Console
            Console.WriteLine($"At {timestamp} Response was: {responseBody}");
        }
    }
}
