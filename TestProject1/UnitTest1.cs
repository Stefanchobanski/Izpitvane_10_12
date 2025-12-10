using ConsoleApp9.Models;
using ConsoleApp9.Services;
using NUnit.Framework.Internal;

namespace TestProject1
{
    public class Tests
    {
        ExerciseService service;

        [SetUp]
        public void Setup()
        {
            service = new ExerciseService();
        }

        [Test]
        public void AddExercise_ValidData_AddsExerciseToList()
        {
            service.AddExercise("Push-Ups", "120");

            Assert.That(service.GetAllExercises().Count, Is.EqualTo(1));
        }

        [Test]
        public void Test_AddExercise_DuplicateName_ThrowsArgumentException()
        {
            service.AddExercise("Push-Ups", "120");

            Assert.Throws<ArgumentException>(() => service.AddExercise("Push-Ups", "5"));
        }

        [Test]
        public void Test_GetMaxCaloriesExercise_EmptyCollection_ReturnsNull()
        {
            Assert.That(service.GetMaxCaloriesExercise(), Is.EqualTo(null));
        }

        [Test]
        public void Test_GetMaxCaloriesExercise_ReturnsCorrectExercise()
        {
            service.AddExercise("Push-Ups", "120");
            service.AddExercise("Burpees", "230");
            service.AddExercise("Jumping Jacks", "90");

            Exercise best = service.GetMaxCaloriesExercise();

            Assert.That(best.Name, Is.EqualTo("Burpees"));
        }

        [Test]
        public void Test_GetTotalCalories_NoExercises_ReturnsZer()
        {
            Assert.That(service.GetTotalCalories(), Is.EqualTo(0));
        }

        [Test]
        public void Test_GetTotalCalories_ReturnsCorrectSum()
        {
            service.AddExercise("Running", "300");
            service.AddExercise("Cycling", "250");

            Assert.That(service.GetTotalCalories(), Is.EqualTo(550));
        }
    }
}
