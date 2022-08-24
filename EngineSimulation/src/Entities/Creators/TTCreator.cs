using EngineSimulation.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EngineSimulation.Entities.Creators
{
    public class TTCreator : TestCreator
    {
        public TTCreator(double _dt, Engine _engine) : base(_dt, _engine) { }
        public override EngineTest CreateTest()
        {
            return new Tests.TemperatureTest(dt, engine);
        }
    }
}
