using EngineSimulation.Abstract;

namespace EngineSimulation.Entities.Engiens
{
    public class InternalCombustionEngine : Engine
    {
        public InternalCombustionEngine(int inertion, double maxTemerture, double heatingFromTorque, double heatingFromRotation, double coolingRates, int[] _M, int[] _v) 
            : base(inertion, maxTemerture, heatingFromTorque, heatingFromRotation, coolingRates, _M, _v) {}

        public override string TemperatureReport()
        {
            return new string("Температура двигателя внутреннего сгорания: " + EngineTemperature + " / " + MaxTemerture);
        }
    }
}
