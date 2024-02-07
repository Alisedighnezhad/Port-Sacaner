using System.Net.Sockets;

namespace Port_scaner
{
    internal class PortScanner
    {
        static async Task Main(string[] args)
        {
            Console.Write("Enter the target IP address: ");
            string target;
            while (true)
            {
                target = Console.ReadLine();
                if (target != string.Empty)
                {
                    break;
                }
                else
                {
                    Console.WriteLine("ip addr cannot be null \n try again ");
                }
            }
            Console.WriteLine("ok now time for chose mode \n type tcp or udp");
            while (true)
            {
                string protocol = Console.ReadLine();
                if (protocol == "tcp")
                {
                    Console.WriteLine("ok lets start on tcp...");
                    await start(target, "tcp");
                    Console.ForegroundColor = ConsoleColor.Blue;
                    Console.WriteLine("Enjoy it \n thanks for choosing me for helping you \n I hope you are always as reliable as TCP :)");
                    break;
                }
                else if (protocol == "udp")
                {
                    Console.WriteLine("ok lets start on udp...");
                    await start(target, "udp");
                    Console.ForegroundColor = ConsoleColor.Blue;
                    Console.WriteLine("Enjoy it \n thanks for choosing me for helping you \nI hope you are always as fast as UDP :)");
                    break;
                }
                else
                {
                    Console.WriteLine("pls type tcp or udp");
                }
            }
        }

        static async Task start(string ip, string mode)
        {
            Console.WriteLine($"scaning For {ip} ports is start");
            if (mode == "tcp")
            {
                for (int port = 0; port <= 65535; port++)
                    await tcp(ip, port);
            }
            else
            {
                for (int port = 0; port <= 65535; port++)
                    await udp(ip, port);
            }
        }

        static async Task tcp(string ip, int port)
        {
            using (TcpClient tcp = new TcpClient())
            {
                try
                {
                    await tcp.ConnectAsync(ip, port);
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine($"{port} is open on TCP");
                }
                catch
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine($"{port} is close on TCP");
                }
            }
        }
        static async Task udp(string ip, int port)
        {
            using (UdpClient udp = new UdpClient())
            {
                try
                {
                    await udp.SendAsync(new byte[2], 1, ip, port);
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine($"{port} is open on UDP");
                }
                catch
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine($"{port} is close on UDP");
                }
            }
        }
    }
}

