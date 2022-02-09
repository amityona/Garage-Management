using System;
using System.Collections.Generic;

namespace Ex03.GarageLogic
{
    public abstract class EnergySource
    {
        public enum eEnergyTypeOfSource
        {
            Battery = 1,
            GasTank,
        }

        private float m_CurrentAmountOfEnergy;
        private float m_MaxAmountOfEnergy;
        public abstract string GetEnergyToAddMSG();   
        public abstract string CreateOutOfRangMsg();
        public abstract override string ToString();
        public float CurrentAmountOfEnergy
        {
            get
            {
                return m_CurrentAmountOfEnergy;
            }

            set
            {
                m_CurrentAmountOfEnergy = value;
            }
        }

        public float MaxAmountOfEnergy
        {
            get
            {
                return m_MaxAmountOfEnergy;
            }

            set
            {
                m_MaxAmountOfEnergy = value;
            }
        }

        public void UpdateEnergy(float i_EnergyToEnter)
        {
            if (m_CurrentAmountOfEnergy + i_EnergyToEnter > m_MaxAmountOfEnergy
                || m_CurrentAmountOfEnergy + i_EnergyToEnter < 0)
            {
                throw new ValueOutOfRangeException(0, m_MaxAmountOfEnergy);
            }

            m_CurrentAmountOfEnergy += i_EnergyToEnter;
        }
    }
}
