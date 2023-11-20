using System;
using System.Collections.Generic;
using System.IO;
using System.Net.Sockets;
using System.Text;
using System.Timers;
using Insectopia.Network.Api;
using InsektopiaMonoForms.Config;
using Newtonsoft.Json;

namespace InsektopiaMonoForms.Network;

public class ClientTcpListener
{
    private static TcpClient tcpClient;
    private static bool readyToRecieveMessages;
    private static System.Timers.Timer recieveTimer;

    public static void Init()
    {
        try
        {
            // Create a TcpClient.
            // Note, for this client to work you need to have a TcpServer
            // connected to the same address as specified by the server, port
            // combination.
            Int32 port = 13000;

            // Prefer using declaration to ensure the instance is Disposed later.
            tcpClient = new TcpClient("127.0.0.1", port);

            recieveTimer = new System.Timers.Timer(500);
            recieveTimer.Elapsed += RecieveClientMessages;
            recieveTimer.Start();

            string msg = MessageEncoder.WrapMessage("identify", string.Empty, string.Empty);

            // Translate the passed message into ASCII and store it as a Byte array.
            Byte[] data = System.Text.Encoding.ASCII.GetBytes(msg);

            // Get a client stream for reading and writing.
            NetworkStream stream = tcpClient.GetStream();

            // Send the message to the connected TcpServer.
            stream.Write(data, 0, data.Length);
        }
        catch (ArgumentNullException e)
        {
            Console.WriteLine("ArgumentNullException: {0}", e);
        }
        catch (SocketException e)
        {
            Console.WriteLine("SocketException: {0}", e);
        }

        Console.WriteLine("\n Press Enter to continue...");
        Console.Read();
    }

    public static void SendMessage(string purpose, string content)
    {
        string message = MessageEncoder.WrapMessage(purpose, PlayerConfig.Identity, content);
        NetworkStream stream = tcpClient.GetStream();
        byte[] msg = Encoding.ASCII.GetBytes(message);

        stream.Write(msg, 0, msg.Length);
        Console.WriteLine("Sent: {0}", message);
    }

    private static void RecieveClientMessages(object sender, ElapsedEventArgs e)
    {
        string str = string.Empty;
        byte[] data = new byte[1024];

        NetworkStream clientStream = tcpClient.GetStream();

        if (clientStream.DataAvailable)
        {
            using (MemoryStream memoryStream = new MemoryStream())
            {
                do
                {
                    int numBytesRead = clientStream.Read(data, 0, data.Length);
                    memoryStream.Write(data, 0, numBytesRead);
                } while (clientStream.DataAvailable);

                str += Encoding.ASCII.GetString(memoryStream.ToArray(), 0, (int)memoryStream.Length);
            }


            List<(string purpose, string content, string identification)> unwrapdMessages =
                MessageDecoder.UnwrapMessage(str);


            unwrapdMessages.ForEach(unwrapedMessage =>
            {
                if (unwrapedMessage.purpose == MessagePurpose.identify.ToString())
                {
                    PlayerConfig.Identity = unwrapedMessage.content;
                }

                if (unwrapedMessage.purpose == MessagePurpose.startGame.ToString())
                {
                    PlayerConfig.CurrentGameState =
                        JsonConvert.DeserializeObject<GameState>(
                            Encoding.UTF8.GetString(Convert.FromBase64String(unwrapedMessage.content)));
                }

                if (unwrapedMessage.purpose == MessagePurpose.play.ToString())
                {
                    PlayerConfig.CurrentGameState =
                        JsonConvert.DeserializeObject<GameState>(
                            Encoding.UTF8.GetString(Convert.FromBase64String(unwrapedMessage.content)));
                }
            });
        }
    }
}