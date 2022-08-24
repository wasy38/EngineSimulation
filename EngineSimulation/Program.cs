using EngineSimulation.Abstract;
using EngineSimulation.Entities;
using EngineSimulation.Entities.Creators;
using System;

namespace EngineSimulation
{
    internal class Program
    {
        static void Main(string[] args)
        {
            EngineCreator creator;

            Console.WriteLine("Введите температуру окружающей среды");
            Entities.Environment.GetInstance(Double.Parse(Console.ReadLine()));
            Console.Clear();
            creator = new ICECreator(10, 110, 0.01, 0.0001, 0.1, new int[] { 20, 75, 100, 105, 75, 0 }, new int[] { 0, 75, 150, 200, 250, 300 });
            Engine engine = creator.CreateEngine();
            Stand stand = new(1, engine);
            creator = new SECreator(5, 100, 0.1, 0.001, 0.01, new int[] { 10, 50, 75, 100, 60, 0 }, new int[] { 0, 50, 100, 150, 200, 250 });
            engine = creator.CreateEngine();
            Stand stand1 = new(1, engine);
            stand.Start();
            stand1.Start();
            while ((stand.InWork) || (stand1.InWork)) { }
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("\n\nДовигатель на 1 стенде перегревается за " + stand.Time + " секунды");
            Console.WriteLine("Довигатель на 2 стенде перегревается за " + stand1.Time + " секунды");
            Console.ResetColor();
        }
    }
}
