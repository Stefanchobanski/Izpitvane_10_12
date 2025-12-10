using ConsoleApp9.Models;
using ConsoleApp9.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp9.Controllers;

public class Controller
{
    public Controller()
    {
        _service = new ExerciseService();
    }

    public void Add(string name, string cal)
    {
        try
        {
            _service.AddExercise(name, cal);
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
    }

    public string GetAllListString()
    {
        return _service.GetStringList();
    }

    public Exercise GetMaxCal()
    {
        return _service.GetMaxCaloriesExercise();
    }

    private ExerciseService _service;
}
