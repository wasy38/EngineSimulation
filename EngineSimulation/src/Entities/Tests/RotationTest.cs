using EngineSimulation.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace EngineSimulation.Entities.Tests
{
    public class RotationTest : EngineTest
    {
        public double MaxRotation { get; protected set; } = double.MinValue;
        private double _oldRotation = double.MinValue;
        public RotationTest(double _dt, Engine _engine)
            : base(_dt, _engine){}

        public override void Start()
        {
            InWork = true;
            new Thread(() =>
            {
                while (Math.Round(_engine.RotationSpeed, 3) != MaxRotation)
                {
                    MaxRotation = Math.Round(_engine.RotationSpeed, 3);
                    _engine.Step(dt);
                    Time += dt;
                    
                    Console.WriteLine(Time + "сек - текущая скорость "+ Math.Round(_engine.RotationSpeed, 3));
                    Thread.Sleep(TimeSpan.FromMilliseconds(100));
                }
                InWork = false;
            }).Start();
        }
    }
}
