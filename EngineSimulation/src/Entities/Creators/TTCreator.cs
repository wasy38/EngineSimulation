using EngineSimulation.Abstract;

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
