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
            #region Параметры двигателя
            int Inertion =10;
            double MaxTemerture=110;
            double HeatingFromTorque=0.01;
            double HeatingFromRotation=0.0001;
            double CoolingRates=0.1;
            int[] M = new int[] { 20, 75, 100, 105, 75, 0 };
            int[] v = new int[] { 0, 75, 150, 200, 250, 300 };
            #endregion
            Console.WriteLine("Введите температуру окружающей среды");
            Entities.Environment.GetInstance(Double.Parse(Console.ReadLine()));
            Console.Clear();
            creator = new ICECreator(Inertion, MaxTemerture, HeatingFromTorque, HeatingFromRotation, CoolingRates, M, v);
            Engine engine = creator.CreateEngine();
            Stand stand = new(1, engine);

            Inertion = 5;
            MaxTemerture = 100;
            HeatingFromTorque = 0.1;
            HeatingFromRotation = 0.001;
            CoolingRates = 0.01;
            M = new int[] { 10, 50, 75, 100, 60, 0 };
            v = new int[] { 0, 50, 100, 150, 200, 250 };

            creator = new SECreator(Inertion,MaxTemerture,HeatingFromTorque,HeatingFromRotation,CoolingRates,M,v);
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
