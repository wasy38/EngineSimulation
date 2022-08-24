using EngineSimulation.Abstract;
using EngineSimulation.Entities.Engiens;

namespace EngineSimulation.Entities.Creators
{
    internal class SECreator : EngineCreator
    {
        public SECreator(int inertion, double maxTemerture, double heatingFromTorque, double heatingFromRotation, double coolingRates, int[] _M, int[] _v)
            : base(inertion, maxTemerture, heatingFromTorque, heatingFromRotation, coolingRates, _M, _v) { }
        public override Engine CreateEngine()
        {
            return new SteamEngine(Inertion, MaxTemerture, HeatingFromTorque, HeatingFromRotation, CoolingRates, M, v);
        }
    }
}
