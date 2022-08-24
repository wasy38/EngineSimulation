using EngineSimulation.Abstract;
using System;
using System.Threading;

namespace EngineSimulation.Entities.Tests
{
    public class TemperatureTest : EngineTest
    {
        public TemperatureTest(double _dt, Engine _engine)
            : base(_dt, _engine){}

        /// <summary>
        /// Запускает тест на температуру
        /// </summary>
        public override void Start()
        {
            InWork = true;
            new Thread(() =>
            {
                while (engine.EngineTemperature <= engine.MaxTemerture)
                {
                    engine.Step(dt);
                    Time += dt;
                    Console.WriteLine(Time + "сек - " + engine.TemperatureReport());
                    Thread.Sleep(TimeSpan.FromMilliseconds(100));
                }
                InWork = false;
            }).Start();
        }
    }
}
