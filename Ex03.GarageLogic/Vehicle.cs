using System;
using System.Collections.Generic;
using System.Text;

namespace Ex03.GarageLogic
{
    public abstract class Vehicle
    {
        public enum eTypeOfTheVehicle
        {
            Truck = 1,
            Motorcycle,
            Car,
        }

        private readonly string r_ModelName;
        private readonly string r_NumberOfLicensePlate;
        private readonly EnergySource r_EnergySource;
        private float m_AmountOfEnergy;
        private List<Pulley> m_Pulley;

        public Vehicle(string i_LicensePlate, string i_ModelName, EnergySource.eEnergyTypeOfSource i_Source)
        {
            r_ModelName = i_ModelName;
            r_NumberOfLicensePlate = i_LicensePlate;
            m_Pulley = new List<Pulley>();

            if (i_Source == EnergySource.eEnergyTypeOfSource.Battery)
            {
                r_EnergySource = new ElectricalEnergy();
            }
            else
            {
                r_EnergySource = new FuelEnergy();
            }
        }

        public string NumberOfLicensePlate
        {
            get
            {
                return r_NumberOfLicensePlate;
            }
        }

        public float AmountOfEnergy
        {
            get
            {
                return m_AmountOfEnergy;
            }

            set
            {
                m_AmountOfEnergy = value;
            }
        }

        public string ModelName
        {
            get
            {
                return r_ModelName;
            }
        }

        public List<Pulley> Pulleys
        {
            get
            {
                return m_Pulley;
            }

            set
            {
                m_Pulley = value;
            }
        }

        public EnergySource EnergySource
        {
            get
            {
                return r_EnergySource;
            }
        }

        public void ChangeEnergyAmout()
        {
            AmountOfEnergy = ( EnergySource.CurrentAmountOfEnergy / EnergySource.MaxAmountOfEnergy) * 100 ;
        }

        public string AllVehicleDetailInformation() 
        {
            string answer = string.Format( 
@"Vehicel license plate: {0} Vehicel model name: {1}
Pulley: {2}
Energy: {3}%
{4}",
r_NumberOfLicensePlate,
r_ModelName,
m_Pulley[0].ToString(),
m_AmountOfEnergy,
r_EnergySource.ToString());
            return answer;
        }

        public abstract void ResetEnergey(); 
        public abstract override string ToString();

    }
}
