using DPMHKV_HFT_2023241.Models;
using System;
using System.Linq;

namespace DPMHKV_HFT_2023241.Client
{
    internal class Program
    {
        static RestService rest;
        static void Main(string[] args)
        {
            rest = new RestService("http://localhost:20630/","guitar");

        }
    }
}
