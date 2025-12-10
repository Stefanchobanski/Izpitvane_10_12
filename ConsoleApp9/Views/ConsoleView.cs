using ConsoleApp9.Controllers;
using ConsoleApp9.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp9.Views;

public class ConsoleView
{
    public ConsoleView()
    {
        _controller = new Controller();
    }

    public void Run()
    {
        Console.WriteLine("Fitness app");
        while (true)
        {
            Console.WriteLine("1 add");
            Console.WriteLine("2 list");
            Console.WriteLine("3 max");
            Console.WriteLine("4 exit");

            var input = Console.ReadLine();

            if (input == "1")
            {
                Console.WriteLine("Exercise name");
                string nameExercise = Console.ReadLine();

                Console.WriteLine("Calories:");
                string calories = Console.ReadLine();

                _controller.Add(nameExercise, calories);

            }
            else if (input == "2")
            {
                Console.WriteLine(_controller.GetAllListString());
            }
            else if (input == "3")
            {
                Exercise result = _controller.GetMaxCal();

                Console.WriteLine($"Id: {result.Id} - Name: {result.Name} - Calories: {result.CaloriesBurned}");
            }
            else if (input == "4")
            {
                return;
            }
        }

    }

    private Controller _controller;
}
