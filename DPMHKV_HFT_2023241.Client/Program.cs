using ConsoleTools;
using DPMHKV_HFT_2023241.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DPMHKV_HFT_2023241.Client
{
    internal class Program
    {
        static RestService rest;
        
        static void Create(string entitiy)
        {
            if (entitiy == "Guitar")
            {
                Console.WriteLine("Enter guitar shape: ");
                string shape = Console.ReadLine();
                Console.WriteLine("Enter guitar color: ");
                string color = Console.ReadLine();
                Console.WriteLine("Enter guitar price: ");
                int price = int.Parse(Console.ReadLine());
                rest.Post(new Guitar() { Shape = shape, Color = color, Price = price }, "guitar");
            }
            else if (entitiy == "Musician")
            {
                Console.WriteLine("Enter Name: ");
                string name = Console.ReadLine();
                Console.WriteLine("Enter Band Name: ");
                string bandname = Console.ReadLine();
                rest.Post(new Musician() { Name = name,BandName=bandname }, "api/musician");
            }
            else if (entitiy == "Brand")
            {
                Console.WriteLine("Enter Name: ");
                string name = Console.ReadLine();
                Console.WriteLine("Enter year of foundation: ");
                int foundation = int.Parse(Console.ReadLine());
                Console.WriteLine("Enter Net Worth: ");
                int networth= int.Parse(Console.ReadLine());
                rest.Post(new Brand() { BrandName = name, NetWorth=networth,YearOfFoundation =foundation }, "api/brand");
            }
        }
        static void Update(string entity)
        {
            if (entity=="Guitar")
            {
                Console.Write("Enter guitars serialnumberID to update: ");
                int id = int.Parse(Console.ReadLine());
                Guitar one = rest.Get<Guitar>(id, "guitar");
                Console.Write($"New Price [old: {one.Price}]: ");
                int price = int.Parse(Console.ReadLine());
                one.Price = price;
                rest.Put(one, "guitar");
            }
            else if (entity == "Brand")
            {
                Console.Write("Enter brand ID to update: ");
                int id = int.Parse(Console.ReadLine());
                Brand one = rest.Get<Brand>(id, "guitar");
                Console.Write($"New Networth [old: {one.NetWorth}]: ");
                int price = int.Parse(Console.ReadLine());
                one.NetWorth = price;
                rest.Put(one, "guitar");
            }
        }
        static void Delete(string entitiy) 
        {
            if(entitiy=="Guitar")
            {
                Console.Write("Enter Guitar's id to delete: ");
                int id = int.Parse(Console.ReadLine());
                rest.Delete(id, "guitar");
            }
            else if (entitiy == "Brand")
            {
                Console.Write("Enter Brand's id to delete: ");
                int id = int.Parse(Console.ReadLine());
                rest.Delete(id, "api/brand");
            }
            else if(entitiy == "Musician")
            {
                Console.Write("Enter Musician's id to delete: ");
                int id = int.Parse(Console.ReadLine());
                rest.Delete(id, "api/musician");
            }
        }
        static void List(string entitiy) 
        {
            
            if(entitiy=="Guitar")
            {
                List<Guitar> guitars = rest.Get<Guitar>("guitar");
                foreach (var item in guitars)
                {
                    Console.WriteLine(item.SerialNumberID+" "+item.Color+" "+item.Shape);
                }
            }
            else if (entitiy == "Brand")
            {
                List<Brand> brands = rest.Get<Brand>("api/brand");
                foreach (var item in brands)
                {
                    Console.WriteLine(item.BrandName);
                }
            }
            else if (entitiy == "Musician")
            {
                List<Musician> musicians = rest.Get<Musician>("api/musician");
                foreach (var item in musicians)
                {
                    Console.WriteLine(item.Name);
                }
            }
            Console.ReadLine();
        }
        static void Main(string[] args)
        {
            rest = new RestService("http://localhost:20630/");//,"guitar");

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
