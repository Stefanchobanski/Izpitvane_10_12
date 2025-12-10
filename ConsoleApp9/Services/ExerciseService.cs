using ConsoleApp9.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp9.Services;

public class ExerciseService : IExerciseService
{
    public ExerciseService()
    {
        _list = new List<Exercise>();
    }

    public void AddExercise(string name, string calories)
    {
        int parsedCalories = int.Parse(calories);

        if (parsedCalories < 0)
        {
            throw new ArgumentException("Negative cal");
        }

        if (IsContain(name))
        {
            throw new ArgumentException("Invalid name");
        }

        Exercise model = new Exercise()
        {
            Name = name,
            CaloriesBurned = parsedCalories,
            Id = _list.Count
        };

        _list.Add(model);
    }

    public List<Exercise> GetAllExercises()
    {
        return _list;
    }

    public string GetStringList()
    {
        string result = "";

        foreach (Exercise exercise in _list)
        {
            result += $"Id: {exercise.Id} - Name: {exercise.Name} - Calories: {exercise.CaloriesBurned}\n";
        }

        return result;
    }

    public Exercise GetMaxCaloriesExercise()
    {
        if(_list.Count == 0)
        {
            return null;
        }

        Exercise max = _list[0];

        foreach (Exercise current in _list)
        {
            if (max.CaloriesBurned < current.CaloriesBurned)
            {
                max = current;
            }
        }

        return max;
    }

    public int GetTotalCalories()
    {
        if(_list.Count == 0)
        {
            return 0;
        }

        int sum = 0;

        foreach (Exercise current in _list)
        {
            sum += current.CaloriesBurned;
        }

        return sum;
    }

    private bool IsContain(string name)
    {
        foreach (Exercise exercise in _list)
        {
            if (exercise.Name == name)
            {
                return true;
            }
        }
        return false;
    }

    private List<Exercise> _list;
}
