using System;
using System.Collections.Generic;
using System.Threading;

namespace ProblematicProblem
{
    public class Program
    {
        public Random rng;
        public static bool cont = true;
        public static List<string> activities = new List<string>() { "Movies", "Paintball", "Bowling", "Lazer Tag", "LAN Party", "Hiking", "Axe Throwing", "Wine Tasting" };

        static void Main(string[] args)
        {
            Console.Write("Hello, welcome to the random activity generator! \nWould you like to generate a random activity? yes/no: ");
            //cont = bool.Parse(Console.ReadLine());
            var conResponse = Console.ReadLine().ToLower();
            if (conResponse == "yes")
            {
                cont = true;
            }
            else
            {
                cont = false;
                Environment.Exit(0);
            }

            Console.WriteLine();

            Console.Write("We are going to need your information first! What is your name? ");
            string userName = Console.ReadLine();
            Console.WriteLine();

            Console.Write("What is your age? ");
            int userAge = int.Parse(Console.ReadLine());
            Console.WriteLine();

            Console.Write("Would you like to see the current list of activities? Sure/No thanks: ");
            //bool seeList = bool.Parse(Console.ReadLine());

            conResponse = Console.ReadLine().ToLower();

            bool seeList = (conResponse == "sure") ? true : false;

            if (seeList)
            {
                foreach (string activity in activities)
                {
                    Console.Write($"{activity} ");
                    Thread.Sleep(250);
                }
                Console.WriteLine();

                Console.Write("Would you like to add any activities before we generate one? yes/no: ");
                //bool addToList = bool.Parse(Console.ReadLine());
                conResponse = Console.ReadLine().ToLower();
                bool addToList = (conResponse == "yes");

                Console.WriteLine();

                while (addToList)
                {
                    Console.Write("What would you like to add? ");
                    string userAddition = Console.ReadLine();
                    activities.Add(userAddition);
                    foreach (string activity in activities)
                    {
                        Console.Write($"{activity} ");
                        Thread.Sleep(250);
                    }
                    Console.WriteLine();
                    Console.WriteLine("Would you like to add more? yes/no: ");
                    //addToList = bool.Parse(Console.ReadLine());
                    conResponse = Console.ReadLine().ToLower();
                    addToList = (conResponse == "yes");
                }
            }

            while (cont)
                {
                    Console.Write("Connecting to the database");

                for (int i = 0; i < 10; i++)
                {
                    Console.Write(". ");
                    Thread.Sleep(500);
                }
                Console.WriteLine();
                Console.Write("Choosing your random activity");

                for (int i = 0; i < 9; i++)
                {
                    Console.Write(". ");
                    Thread.Sleep(500);
                }
                Console.WriteLine();

                var rng = new Random();
                int randomNumber = rng.Next(activities.Count);
                string randomActivity = activities[randomNumber];

                if (userAge < 21 && randomActivity == "Wine Tasting") 
                {
                    Console.WriteLine($"Oh no! Looks like you are too young to do {randomActivity}");
                    Console.WriteLine("Pick something else!");
                    randomNumber = rng.Next(activities.Count);
                    randomActivity = activities[randomNumber];
                    activities.Remove(randomActivity);
                }
                else
                Console.Write($"Ah got it! {userName}, your random activity is: {randomActivity}! Is this ok or do you want to grab another activity? Keep/redo: ");
                
                Console.WriteLine();
                //bool.Parse(Console.ReadLine());
                cont = (Console.ReadLine().ToLower() == "redo") ? true : false;
            }
        }
    }
}