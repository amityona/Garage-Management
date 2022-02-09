using System;
using System.Collections.Generic;

namespace Ex03.GarageLogic
{
    public class Truck : Vehicle
    {
        private bool m_AbailtyCool;
        private const int k_AmountOfPulley = 16;
        private float m_LoadVolume;
        private const float k_MaxAirOfPulley = 25;
        private const float k_MaxAmountEnergy = 130;

        public Truck(EnergySource.eEnergyTypeOfSource i_EnergyType ,string i_NameOfModel, string i_NumberLicnsePlate, string i_PulleyManufacturer)
            : base(i_NumberLicnsePlate, i_NameOfModel, i_EnergyType)
        {
            for (int i = 0; i < k_AmountOfPulley; i++)
            {
                Pulleys.Add(new Pulley(i_PulleyManufacturer, k_MaxAirOfPulley));
            }

            ResetEnergey();
        }

        public override void ResetEnergey()
        {
            EnergySource.MaxAmountOfEnergy = k_MaxAmountEnergy;
            ((FuelEnergy)EnergySource).KindFuel = FuelEnergy.eFuelType.Soler;
        }


        public float LoadVolume
        {
            get
            {
                return m_LoadVolume;
            }

            set
            {
                m_LoadVolume = value;
            }
        }

        public bool AbailtyCool
        {
            get
            {
                return m_AbailtyCool;
            }

            set
            {
                m_AbailtyCool = value;
            }
        }

        public override string ToString()
        {
            string result;

            result = string.Format(
@"{0}
Is the truck  cooled: {1}
volume of load is: {2}",
AllVehicleDetailInformation(),
m_AbailtyCool,
m_LoadVolume);
            return result;
        }
    }
}
