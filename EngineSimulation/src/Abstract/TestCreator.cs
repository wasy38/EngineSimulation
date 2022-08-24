namespace EngineSimulation.Abstract
{
    public abstract class TestCreator
    {
        protected double dt { get; set; }
        protected Engine engine { get; set; }
        protected TestCreator(double _dt, Engine _engine)
        { 
            dt = _dt;
            engine = _engine;
        }
        /// <summary>
        /// Создает экземпляр теста
        /// </summary>
        /// <returns>Тест</returns>
        public abstract EngineTest CreateTest();
    }
}
