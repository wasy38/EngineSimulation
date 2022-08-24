using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EngineSimulation.Abstract
{
    public abstract class EngineTest
    {
        public double Time { get; protected set; } = 0;
        public bool InWork = false;
        protected Engine _engine;
        protected double dt;
        protected EngineTest Test { get; set; }
        protected EngineTest(double _dt, Engine _engine)
        { 
            dt = _dt;
            this._engine = _engine;
        }
        public abstract void Start();
        /// <summary>
        /// Устанавливает новый тест
        /// </summary>
        /// <param name="test">Тест</param>
        public void SetTest(EngineTest test)
        { Test = test; }
    }
}
