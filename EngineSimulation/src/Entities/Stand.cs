using EngineSimulation.Abstract;
using System;
using System.Threading;

namespace EngineSimulation.Entities
{
    public class Stand
    {
        
        private readonly int _dt;
        private Engine _engine;
        public bool InWork;
        public double Time { get; private set; }

        public Stand(int dt, Engine engine)
        {
            _dt = dt;
            _engine = engine;
            InWork = false;
            Time = 0;
        }
        /// <summary>
        /// Размещает/изменяет двигатель на стене
        /// </summary>
        /// <param name="engine">Двигатель</param>
        public void SetEngine (Engine engine)
        { _engine = engine; }
        /// <summary>
        /// Запускает двигатель на стенде до его перегрева
        /// </summary>
        public void Start()
        {
            Time = 0;
            InWork = true;
            new Thread(() =>
            {
                while (_engine.EngineTemperature <= _engine.MaxTemerture)
                {
                    _engine.Step(_dt);
                    Time += _dt;
                    Console.WriteLine(Time + "сек - "+_engine.TemperatureReport());
                    Thread.Sleep(TimeSpan.FromMilliseconds(100));
                }
                InWork = false;
            }).Start();
        }
    }
}
