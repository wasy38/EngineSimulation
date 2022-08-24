namespace EngineSimulation.Abstract
{
    public abstract class EngineCreator
    {
        protected int Inertion { get; set; }
        protected double MaxTemerture { get; set; }
        protected double HeatingFromTorque { get; set; }
        protected double HeatingFromRotation { get; set; }
        protected double CoolingRates { get; set; }
        protected int[] M { get; set; }
        protected int[] v { get; set; }

        protected EngineCreator(int inertion, double maxTemerture, double heatingFromTorque, double heatingFromRotation, double coolingRates, int[] _M, int[] _v)
        {
            Inertion = inertion;
            MaxTemerture = maxTemerture;
            HeatingFromTorque = heatingFromTorque;
            HeatingFromRotation = heatingFromRotation;
            CoolingRates = coolingRates;
            M = _M;
            v = _v;
        }
        /// <summary>
        /// Создает экземпляр двигателя
        /// </summary>
        /// <returns>Двигатель</returns>
        public abstract Engine CreateEngine();
    }
}
