using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EngineSimulation.Abstract;

namespace EngineSimulation.Entities.Creators
{
    public class RTCreator : TestCreator
    {
        public RTCreator(double _dt, Engine _engine) 
            : base(_dt, _engine){}

        public override EngineTest CreateTest()
        {
            return new Tests.RotationTest(dt, engine);
        }
    }
}
