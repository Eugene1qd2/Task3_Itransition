using BetterConsoleTables;
using DZen.Security.Cryptography;
using RPS.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace RPS
{
    internal class Program
    {
        static void Main(string[] args)
        {
            if (args.Length  <=1 || args.Length%2==0) {
                Console.WriteLine("Wrong params amount");
                return;
            }
            foreach (string arg in args)
            {
                if (args.Count(x=>x==arg)>1)
                {
                    Console.WriteLine("Params cant be repeated");
                    return;
                }
            }

            GameManager gameManager = new GameManager(args);
            gameManager.ShowHMAC();
            gameManager.ShowMenu();
            Console.Write("Enter your move: ");
            string move = Console.ReadLine();
            while (!gameManager.SelectMenu(move))
            {
                move = Console.ReadLine();
            }
            Console.ReadLine();
        }
    }
}
