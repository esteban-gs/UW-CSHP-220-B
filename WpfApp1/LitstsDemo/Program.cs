using ConsoleTables;
using ListsDemo.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace LitstsDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            var users = new List<User>();

            users.Add(new User { Name = "Dave", Password = "hello" });
            users.Add(new User { Name = "Steve", Password = "steve" });
            users.Add(new User { Name = "Lisa", Password = "hello" });

            var matches = users.Where(x => x.Password.ToLower().Contains("hello")).ToList();


            // 1. Display to the console, all the passwords that are "hello". Hint: Where
            PrintUserModel(matches, "Passwords that are \"hello\":");


            // 2. Delete any passwords that are the lower-cased version of their Name.
            // Do not just look for "steve". It has to be data-driven. Hint: Remove or RemoveAll
            users.RemoveAll(u => u.Password == u.Name.ToLower());


            // 3. Delete the first User that has the password "hello".Hint: First or FirstOrDefault
            var userToBeRemoved = users.FirstOrDefault(u => u.Password == "hello");
            if (userToBeRemoved == null) Debug.WriteLine("No Users to remove");
            users.Remove(userToBeRemoved);


            // 4. Display to the console the remaining users with their Name and Password.
            PrintUserModel(users, "remaining users with their Name and Password");


            /// Instantiates new ConsoleTable object
            void PrintUserModel(List<User> users, string heading)
            {
                ConsoleTable table = new ConsoleTable("Name", "Password");
                foreach (var user in users)
                {
                    table.AddRow(user.Name, user.Password);
                }
                Console.WriteLine(heading);
                Console.WriteLine(table);
            }

            var autos = new List<Auto>();
            autos.Add(new Auto { Name = "SUV", MaxSpeed = 101, Price = 2000 });
            autos.Add(new Auto { Name = "Sedan", MaxSpeed = 120, Price = 1000 });
            autos.Add(new Auto { Name = "Coupe", MaxSpeed = 110, Price = 3000 });

            //// TBD: Fix the lowest price auto
            var maxPriceAuto = autos
                .OrderByDescending(a => a.Price)
                .FirstOrDefault();
            Console.WriteLine("Lowest Price: Name={0} Price={1}", maxPriceAuto.Name, maxPriceAuto.Price);

            var maxSpeedAuto = autos
                .OrderByDescending(a => a.MaxSpeed)
                .FirstOrDefault();
            //// TBD: Fix the fastest auto
            Console.WriteLine("Fastest Speed: Name={0} Speed={1}", maxSpeedAuto.Name, maxSpeedAuto.MaxSpeed);

            //Console.ReadLine();
        }



        class Auto
        {
            public string Name { get; set; }
            public int MaxSpeed { get; set; }
            public int Price;
        }
    }
}
