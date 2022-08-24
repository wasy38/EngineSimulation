using EngineSimulation.Abstract;
using EngineSimulation.Entities;
using EngineSimulation.Entities.Creators;
using EngineSimulation.Entities.Tests;
using System;

namespace EngineSimulation
{
    internal class Program
    {
        static void Main(string[] args)
        {
            EngineCreator engineCreator;
            TestCreator testCreator;
            double dt = 1;
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
            engineCreator = new ICECreator(Inertion, MaxTemerture, HeatingFromTorque, HeatingFromRotation, CoolingRates, M, v);
            Engine engine = engineCreator.CreateEngine();
            testCreator = new TTCreator(dt,engine);
            EngineTest test1 = testCreator.CreateTest();
            //Входные параметры второго двигателя
            Inertion = 5;
            MaxTemerture = 100;
            HeatingFromTorque = 0.1;
            HeatingFromRotation = 0.001;
            CoolingRates = 0.01;
            M = new int[] { 10, 50, 75, 100, 60, 0 };
            v = new int[] { 0, 50, 100, 150, 200, 250 };
            //
            engineCreator = new SECreator(Inertion,MaxTemerture,HeatingFromTorque,HeatingFromRotation,CoolingRates,M,v);
            engine = engineCreator.CreateEngine();
            testCreator = new RTCreator(dt, engine);
            EngineTest test2 = testCreator.CreateTest();
            test1.Start();
            test2.Start();
            while ((test1.InWork) || (test2.InWork)) { }
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("\n\nДовигатель в 1 тесте перегревается за " + test1.Time + " секунды");
            Console.WriteLine("Довигатель на 2 тесте набирает максимальное количество оборотов за " + test2.Time + " секунды");
            Console.ResetColor();
        }
    }
}
