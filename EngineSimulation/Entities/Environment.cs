namespace EngineSimulation.Entities
{
    public class Environment
    {
        private static Environment _instance;
        public double Temperature { get; set; }

        protected Environment(double ambientTemperature)
        {
            Temperature = ambientTemperature;
        }

        public static Environment GetInstance(double ambientTemperature)
        {
            if (_instance == null)
                _instance = new Environment(ambientTemperature);
            return _instance;
        }
    }
}
