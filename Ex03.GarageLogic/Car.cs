using System;
using System.Collections.Generic;

namespace Ex03.GarageLogic
{
    public class Car : Vehicle
    {
        private const float k_MaxBatteryAbility = 2.3f;
        private const int k_AmountOfPulley = 4;
        private const float k_MaxAirPresuure = 29;
        private const float k_MaxAmountEnergy = 48;
        private eTypeColorOfCar m_Color;
        private eAmountOfDoorsToCar m_AmountOfDoors;
        public enum eTypeColorOfCar
        {
            Red = 1,
            White,
            Blue,
            Black
        }

        public enum eAmountOfDoorsToCar
        {
            Two = 1,
            Three,
            Four,
            Five
        }

        public Car(string i_LicensePlate, string i_ModelName, string i_PulleyMaker, EnergySource.eEnergyTypeOfSource i_Source)
            : base(i_LicensePlate, i_ModelName, i_Source)
        {
            for (int i = 0; i < k_AmountOfPulley; i++)
            {
                Pulleys.Add(new Pulley(i_PulleyMaker, k_MaxAirPresuure));
            }

            ResetEnergey();
        }
        public eAmountOfDoorsToCar AmountOfDoors
        {
            get
            {
                return m_AmountOfDoors;
            }

            set
            {
                m_AmountOfDoors = value;
            }
        }
        public eTypeColorOfCar Color
        {
            get
            {
                return m_Color;
            }

            set
            {
                m_Color = value;
            }
        }


        public override void ResetEnergey()
        {
            if (EnergySource is FuelEnergy)
            {
                ((FuelEnergy)EnergySource).KindFuel = FuelEnergy.eFuelType.Octan95;
                EnergySource.MaxAmountOfEnergy = k_MaxAmountEnergy;
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
Car Color: {1}
Car doors: {2}
",
AllVehicleDetailInformation(),
m_Color.ToString(),
m_AmountOfDoors.ToString());
            return result;
        }
    }
}
