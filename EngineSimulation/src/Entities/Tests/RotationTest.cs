using EngineSimulation.Abstract;
using System;
using System.Threading;

namespace EngineSimulation.Entities.Tests
{
    public class RotationTest : EngineTest
    {
        public double MaxRotation { get; protected set; } = double.MinValue;
        public RotationTest(double _dt, Engine _engine)
            : base(_dt, _engine){}

        /// <summary>
        /// Запускает тест на скорость оборотов
        /// </summary>
        public override void Start()
        {
            InWork = true;
            new Thread(() =>
            {
                while (Math.Round(engine.RotationSpeed, 3) != MaxRotation)
                {
                    MaxRotation = Math.Round(engine.RotationSpeed, 3);
                    engine.Step(dt);
                    Time += dt;
                    
                    Console.WriteLine(Time + "сек - текущая скорость "+ Math.Round(engine.RotationSpeed, 3));
                    Thread.Sleep(TimeSpan.FromMilliseconds(100));
                }
                InWork = false;
                Time--;
            }).Start();
        }
    }
}
