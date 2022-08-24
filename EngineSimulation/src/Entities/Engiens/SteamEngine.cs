using EngineSimulation.Abstract;

namespace EngineSimulation.Entities.Engiens
{
    internal class SteamEngine : Engine
    {
        public SteamEngine(int inertion, double maxTemerture, double heatingFromTorque, double heatingFromRotation, double coolingRates, int[] _M, int[] _v) 
            : base(inertion, maxTemerture, heatingFromTorque, heatingFromRotation, coolingRates, _M, _v){}

        public override string TemperatureReport()
        {
            return new string("Температура парового двигателя: " + EngineTemperature + " / " + MaxTemerture);
        }
    }
}
