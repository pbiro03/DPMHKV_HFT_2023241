using ConsoleTools;
using DPMHKV_HFT_2023241.Logic.Classes;
using DPMHKV_HFT_2023241.Models;
using DPMHKV_HFT_2023241.Repository;
using System;
using System.Linq;

namespace DPMHKV_HFT_2023241.Client
{
    internal class Program
    {
        //static RestService rest;
        
        static void Create(string entitiy)
        {
            Console.WriteLine(entitiy+" create");
            Console.ReadLine();
        }
        static void Update(string entity)
        {
            Console.WriteLine(entity+ " update");
            Console.ReadLine();
        }
        static void Delete(string entitiy) 
        {
            Console.WriteLine(entitiy+" delete");
            Console.ReadLine();
        }
        static void List(string entitiy) 
        {
            
        }
        static void Main(string[] args)
        {
            //rest = new RestService("http://localhost:20630/","guitar");
            

            var guitarSubMenu = new ConsoleMenu(args, level: 1)
                .Add("List", () => List("Guitar"))
                .Add("Create", () => Create("Guitar"))
                .Add("Delete", () => Delete("Guitar"))
                .Add("Update", () => Update("Guitar"))
                .Add("Exit", ConsoleMenu.Close);

            var brandSubMenu = new ConsoleMenu(args, level: 1)
                .Add("List", () => List("Brand"))
                .Add("Create", () => Create("Brand"))
                .Add("Delete", () => Delete("Brand"))
                .Add("Update", () => Update("Brand"))
                .Add("Exit", ConsoleMenu.Close);

            var musicianSubMenu = new ConsoleMenu(args, level: 1)
                .Add("List", () => List("Musician"))
                .Add("Create", () => Create("Musician"))
                .Add("Delete", () => Delete("Musician"))
                .Add("Update", () => Update("Musician"))
                .Add("Exit", ConsoleMenu.Close);

            var menu = new ConsoleMenu(args, level: 0)
                .Add("Guitars", () => guitarSubMenu.Show())
                .Add("Musicians", () => musicianSubMenu.Show())
                .Add("Brands", () => brandSubMenu.Show())
                .Add("Exit", ConsoleMenu.Close);

            menu.Show();
        }
    }
}
