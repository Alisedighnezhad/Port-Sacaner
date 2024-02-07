using System;
using System.Net;
using System.Net.Sockets;
using System.Threading.Tasks;

namespace Port_scaner
{
    internal class PortScanner
    {
        static async Task Main(string[] args)
        {
            Console.Write("Enter the target IP address: ");
            string target = Console.ReadLine();
            Console.WriteLine("ok now time for chose mode \n type tcp or udp");
            if (Console.ReadLine() == "tcp")
            {
                Console.WriteLine("ok lets start on tcp...");
                await start(target, "tcp");
                Console.WriteLine("Enjoy it \n thanks for choosing me for helping you \n I hope you are always as reliable as TCP :)");
            }
            else if (Console.ReadLine() == "udp")
            {
                Console.WriteLine("ok lets start on udp...");
                await start(target, "udp");
                Console.WriteLine("Enjoy it \n thanks for choosing me for helping you \nI hope you are always as fast as UDP :)");
            }
            else 
            {
                Console.WriteLine("");
            }
        }

        static async Task start(string ip , string mode )
        {
            Console.WriteLine($"scaning For {ip} ports is start");
            if (mode == "tcp")
            {
                for (int port = 0; port <= 65535; port++)
                    await tcp(ip ,port);
            }
            else
            {
                for (int port = 0; port <= 65535; port++)
                    await udp(ip, port);
            }
        }

        static async Task tcp(string ip , int port)
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

