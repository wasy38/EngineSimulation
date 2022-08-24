using System;

namespace EngineSimulation.Abstract
{
    public abstract class Engine
    {
        protected int Inertion { get; set; }
        public double MaxTemerture { get; protected set; }
        protected double HeatingFromTorque { get; set; }
        protected double HeatingFromRotation { get; set; }
        protected double CoolingRates { get; set; }
        public double EngineTemperature { get; protected set; }
        public double RotationSpeed { get; protected set; }
        protected int[] M { get; set; }
        protected int[] v { get; set; }

        readonly Entities.Environment environment;

        public Engine(int inertion, double maxTemerture, double heatingFromTorque, double heatingFromRotation, double coolingRates, int[] _M, int[] _v)
        {
            environment = Entities.Environment.GetInstance(0);
            Inertion = inertion;
            MaxTemerture = maxTemerture;
            HeatingFromTorque = heatingFromTorque;
            HeatingFromRotation = heatingFromRotation;
            CoolingRates = coolingRates;
            EngineTemperature = environment.Temperature;
            RotationSpeed = 0;
            M = _M;
            v = _v;
        }
        /// <summary>
        /// Рассчет текущего момента силы двигателя
        /// </summary>
        /// <param name="vNow">Текущая скорость</param>
        /// <returns>Момент силы в H*m</returns>
        public double TorqueNow(double vNow)
        {
            double MNow;
            double M0 = M[0], M1 = M[1];
            double v0 = v[0], v1 = v[1];
            if (vNow <= v[0])
            {
                return M[0];
            }
            else if (vNow <= v[1])
            {
                M0 = M[0];
                M1 = M[1];
                v0 = v[0];
                v1 = v[1];
            }
            else if (vNow <= v[2])
            {
                M0 = M[1];
                M1 = M[2];
                v0 = v[1];
                v1 = v[2];
            }
            else if (vNow <= v[3])
            {
                M0 = M[2];
                M1 = M[3];
                v0 = v[2];
                v1 = v[3];
            }
            else if (vNow <= v[4])
            {
                M0 = M[3];
                M1 = M[4];
                v0 = v[3];
                v1 = v[4];
            }
            else if (vNow <= v[5])
            {
                M0 = M[4];
                M1 = M[5];
                v0 = v[4];
                v1 = v[5];
            }
            else if (vNow > v[5]) return M[5];
            MNow = (vNow - v0) * (M1 - M0) / (v1 - v0) + 20;
            return MNow;
        }
        /// <summary>
        /// Изменение состояния двигателя за определнный промежуток времени
        /// </summary>
        /// <param name="dt">Разница во времени между измерениями</param>
        public void Step(double dt)
        {
            double torque = TorqueNow(RotationSpeed);
            double a = torque / Inertion;
            RotationSpeed += a * dt;
            double Vn = torque * HeatingFromTorque + Math.Pow(RotationSpeed, 2) * HeatingFromRotation;
            double Vc = CoolingRates * (environment.Temperature - EngineTemperature);
            EngineTemperature += Vn * dt + Vc * dt;
        }
        /// <summary>
        /// Отчет текущей температуры / максимально возможную для конкретного двигателя
        /// </summary>
        /// <returns>Строка с отчетом</returns>
        public abstract string TemperatureReport();
    }
}
