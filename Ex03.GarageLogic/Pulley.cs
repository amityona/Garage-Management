using System;
using System.Collections.Generic;

namespace Ex03.GarageLogic
{
    public class Pulley
    {
        private readonly string r_Maker;
        private float m_CurrentAirPressure = 0;
        private float m_MaxAirPressure;

        public Pulley(string i_MakerType, float i_MaxAirPressure)
        {
            r_Maker = i_MakerType;
            m_MaxAirPressure = i_MaxAirPressure;
        }

        public string Makers
        {
            get
            {
                return r_Maker;
            }
        }

        public float CurrentAirPressure
        {
            get
            {
                return m_CurrentAirPressure;
            }

            set
            {
                m_CurrentAirPressure = value;
            }
        }

        public float MaxAirPressure
        {
            get
            {
                return m_MaxAirPressure;
            }

            set
            {
                m_MaxAirPressure = value;
            }
        }

        public void UpdateAmoutAirPressure(float i_AirPressureToAdd)
        {
            if (CurrentAirPressure + i_AirPressureToAdd > MaxAirPressure || CurrentAirPressure + i_AirPressureToAdd < 0)
            {
                throw new ValueOutOfRangeException(0, MaxAirPressure);
            }

            CurrentAirPressure += i_AirPressureToAdd;
        }

        public override string ToString()
        {
            string result;
            result = string.Format(
@"Air pressure: {0}
Maker: {1}",
m_CurrentAirPressure,
r_Maker);

         return result;
        }
    }
}
