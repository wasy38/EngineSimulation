namespace EngineSimulation.Abstract
{
    public abstract class EngineTest
    {
        public double Time { get; protected set; } = 0;
        public bool InWork { get; protected set; } = false;
        protected Engine engine { get; set; }
        protected double dt { get; set; }
        protected EngineTest Test { get; set; }
        protected EngineTest(double _dt, Engine _engine)
        { 
            dt = _dt;
            engine = _engine;
        }
        public abstract void Start();
        /// <summary>
        /// Устанавливает новый тест
        /// </summary>
        /// <param name="test">Тест</param>
        public void SetTest(EngineTest test)
        { Test = test; }
        /// <summary>
        /// Устанавливает двигатель для теста
        /// </summary>
        /// <param name="_engine">Двигатель</param>
        public void SetEngine(Engine _engine)
        { engine = _engine; }
    }
}
