using System;

// Author: Noah Funderburgh
// Date: 11/12/2022
// Class: CST-250
// Teacher: Brandon Bass

namespace ConsoleApp2
{
    class Program
    {
        static void Main(string[] args)
        {
            /*Animal beast = new Animal();

            beast.Talk();
            beast.Greet();
            beast.Sing();
            */
            Dog bowser = new Dog();

            bowser.Talk();
            bowser.Greet();
            bowser.Sing();
            bowser.Fetch("stick");
            bowser.FeedMe();
            bowser.TouchMe();

            Robin red = new Robin();

            red.Talk();
            red.Greet();
            red.Sing();
            //red.Fetch("worm");
            //red.FeedMe();
            //red.TouchMe();

            Cow cow = new Cow();

            cow.Talk();
            cow.MilkMe();

            Bird bird = new Bird();

            bird.Talk();
            bird.Fly();

            Dolphin dolphin = new Dolphin();

            dolphin.Talk();
            dolphin.Splash();

            Console.ReadLine();
        }
    }
}