using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EngineSimulation.Abstract
{
    public abstract class TestCreator
    {
        protected double dt;
        protected Engine engine;
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
