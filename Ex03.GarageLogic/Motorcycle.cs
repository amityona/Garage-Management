using System;
using System.Collections.Generic;

namespace Ex03.GarageLogic
{
    public class Motorcycle : Vehicle
    {
        private const int k_AmountOfPulley = 2;
        private const float k_MaxBatteryAbility = 2.3f;
        private const float k_MaxAirPresuure = 30;
        private eLisenceType m_LicenseType;
        private float m_FuelContent;


        public enum eLisenceType
        {
            A = 1,
            A1,
            B1,
            B2,
        }


        public Motorcycle(string i_LicensePlate, string i_ModelName, string i_PulleyMaker, EnergySource.eEnergyTypeOfSource i_Source)
            : base(i_LicensePlate, i_ModelName, i_Source)
        {
            for (int i = 0; i < k_AmountOfPulley; i++)
            {
                Pulleys.Add(new Pulley(i_PulleyMaker, k_MaxAirPresuure));
            }

            ResetEnergey();
        }

        public eLisenceType LicenseType
        {
            get
            {
                return m_LicenseType;
            }

            set
            {
                m_LicenseType = value;
            }
        }

        public float FuelContent
        {
            get
            {
                return m_FuelContent;
            }

            set
            {
                m_FuelContent = value;
            }
        }

        public override void ResetEnergey()
        {
            if (EnergySource is FuelEnergy)
            {
                ((FuelEnergy)EnergySource).KindFuel = FuelEnergy.eFuelType.Octan98;
                EnergySource.MaxAmountOfEnergy = 5.8f;
            }
            else
            {
                EnergySource.MaxAmountOfEnergy = k_MaxBatteryAbility;
            }
        }

        public override string ToString()
        {
            string result;

            result = string.Format(
@"{0}
Motorcycle's license : {1}
Motorcycle's Fuel cpacity: {2}",
AllVehicleDetailInformation(),
m_LicenseType.ToString(),
m_FuelContent);
            return result;
        }
    }
}
