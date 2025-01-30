using System;
using System.Net;
using System.Net.Sockets;
using System.Security.Cryptography.X509Certificates;
using System.Text;

TcpListener tcpListener = new TcpListener(IPAddress.Parse("127.0.0.1"), 5000);
tcpListener.Start();
TcpClient tcpClient = tcpListener.AcceptTcpClient(); NetworkStream nStream =
tcpClient.GetStream();
string message = ReadFromStream(nStream);
Console.WriteLine("Received: \"" + message + "\"");
string translatedMessage = Translate(message);
byte[] response = serialize(translatedMessage);
nStream.Write(response, 0, response.Length);
// TODO: Serialize the translated message and write it to the stream

Console.ReadKey(); // Wait for keypress before exit
static string Translate(string message)
{
    string translatedmessage = "";
    string[] words = message.Split(' ');
    const string vowels = "aeiouAEIOU";
    foreach (string word in words)
    {
        if (word.Length > 0)
        {
            char firstLetter = word[0];
            if (vowels.IndexOf(firstLetter) == -1)
            {
                int firstVowel = -1;
                for (int i = 1; i < word.Length; i++)
                {
                    if (vowels.Contains(word[i]))
                    {
                        firstVowel = i;
                        break;
                    }

                }

                if (firstVowel == -1)
                {
                    translatedmessage += word;
                }

                string beforeVowel = word.Substring(0, firstVowel);
                string afterVowel = word.Substring(firstVowel);
                string translatedWord = afterVowel + beforeVowel + "ay";
                translatedmessage += translatedWord;
            }
            else
            {
                string translatedWord = word;
                translatedWord += "way";
                translatedmessage += translatedWord;
            }
        }
        else
        {
            translatedmessage += word;
        }
    }
    return translatedmessage;
}
static string ReadFromStream(NetworkStream stream)
{
    int messageLength = stream.ReadByte();
    byte[] messageBytes = new byte[messageLength];
    stream.Read(messageBytes, 0, messageLength);
    return Encoding.ASCII.GetString(messageBytes);
}

byte[] serialize(string request)
{
    byte[] responseBytes = Encoding.ASCII.GetBytes(request);
    byte responseLength = (byte)responseBytes.Length;
    byte[] rawData = new byte[responseLength + 1];
    rawData[0] = responseLength;
    responseBytes.CopyTo(rawData, 1);
    return rawData;
}
