using EngineSimulation.Abstract;
using EngineSimulation.Entities.Engiens;

namespace EngineSimulation.Entities.Creators
{
    public class ICECreator : EngineCreator
    {
        public ICECreator(int inertion, double maxTemerture, double heatingFromTorque, double heatingFromRotation, double coolingRates, int[] _M, int[] _v)
            : base(inertion, maxTemerture, heatingFromTorque, heatingFromRotation, coolingRates, _M, _v) { }
        public override Engine CreateEngine()
        {
            return new InternalCombustionEngine(Inertion, MaxTemerture, HeatingFromTorque, HeatingFromRotation, CoolingRates, M, v);
        }
    }
}

