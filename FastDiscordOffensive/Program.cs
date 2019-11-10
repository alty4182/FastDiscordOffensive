using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using Discord;
using Discord.Gateway;
using Discord.Webhook;

namespace FastDiscordOffensive
{
    class Program
    {
        static List<DiscordClient> client_list = new List<DiscordClient>();
        
        static void Main(string[] args)
        {
            try
            {
                Console.Title = "FastDiscordOffensive Made by alty4182";
                Console.ForegroundColor = ConsoleColor.Green;
                Console.BackgroundColor = ConsoleColor.Black;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            Console.Write("Input token file here >");
            try
            {
                string[] tokens = File.ReadAllLines(Console.ReadLine());
                try
                {
                    IEnumerable<int> ranges = Enumerable.Range(0, tokens.Length);
                    try
                    {
                        Console.WriteLine("Loading tokens...");
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine(e.Message);
                    }
                    Parallel.ForEach(ranges, i =>
                    {
                        client_list.Add(LoggingIn(tokens[i]));
                    });
                    Console.Clear();
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        attack:
            Console.Clear();
            Console.WriteLine("[1]Fast Spamming");
            Console.WriteLine("[2]Fast Joiner");
            Console.WriteLine("[3]Fast Leaver");
            Console.WriteLine("[4]Fast Friend Request Sender");
            string command = Console.ReadLine();
            if (command == "1")
            {
                Console.Write("Enter channel id here >");
                try
                {
                    ulong channel_id = Convert.ToUInt64(Console.ReadLine());
                    try
                    {
                        Console.Write("Enter message here >");
                        try
                        {
                            string message = Console.ReadLine();
                            Console.Write("Enter send count here >");
                            try
                            {
                                string send_str_count = Console.ReadLine();
                                int send_count = int.Parse(send_str_count); 
                                for (int i = 0; i < send_count; i++)
                                {
                                    IEnumerable<int> ranges = Enumerable.Range(0, client_list.Count);
                                    Parallel.ForEach(ranges, j =>
                                    {
                                        client_list[j].SendMessage(channel_id, message);
                                    });
                                }
                            }
                            catch (Exception e)
                            {
                                Console.WriteLine(e.Message);
                            }
                        }
                        catch (Exception e)
                        {
                            Console.WriteLine(e.Message);
                        }
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine(e.Message);
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
                goto attack;
            }
            if (command == "2")
            {
                Console.Write("Enter invite link here >");
                try
                {
                    string invite_link = Console.ReadLine();
                    try
                    {
                        IEnumerable<int> ranges = Enumerable.Range(0, client_list.Count);
                        Parallel.ForEach(ranges, i =>
                        {
                            client_list[i].JoinGuild(invite_link.Split(new char[] { '/' }).Last());
                        });
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine(e.Message);
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
                goto attack;
            }
            if (command == "3")
            {
                Console.Write("Enter server id here >");
                try
                {
                    string server_id = Console.ReadLine();
                    IEnumerable<int> ranges = Enumerable.Range(0, client_list.Count);
                    Parallel.ForEach(ranges, i =>
                    {
                        client_list[i].LeaveGuild(Convert.ToUInt64(server_id));
                    });
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
                goto attack;
            }
            if (command == "4")
            {
                Console.Write("Enter username here >");
                try
                {
                    string username = Console.ReadLine();
                    Console.Write("Enter discriminator here >");
                    try
                    {
                        string discriminator = Console.ReadLine();
                        IEnumerable<int> ranges = Enumerable.Range(0, client_list.Count);
                        Parallel.ForEach(ranges, i =>
                        {
                            client_list[i].SendFriendRequest(username, uint.Parse(discriminator));
                        });
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine(e.Message);
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
                goto attack;
            }
        }

        static DiscordClient LoggingIn(string token)
        {
            DiscordClient client = new DiscordClient();
            try
            {
                client.Token = token;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            return client;
        }
    }
}
