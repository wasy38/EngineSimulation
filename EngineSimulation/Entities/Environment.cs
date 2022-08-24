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
        /// <summary>
        /// Гарантирует что будет единственый экземпляр класса
        /// </summary>
        /// <param name="ambientTemperature">Температура окружающей среды</param>
        /// <returns>Экземпляр класса</returns>
        public static Environment GetInstance(double ambientTemperature)
        {
            if (_instance == null)
                _instance = new Environment(ambientTemperature);
            return _instance;
        }
    }
}
