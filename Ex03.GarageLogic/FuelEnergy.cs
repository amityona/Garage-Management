using System;
using System.Collections.Generic;

namespace Ex03.GarageLogic
{
    public class FuelEnergy : EnergySource
    {
        private eFuelType m_TypeOfFuel;
        public enum eFuelType
        {
            Octan95 = 1,
            Soler,
            Octan98,
            Octan96,
        }
        public eFuelType KindFuel
        {
            get
            {
                return m_TypeOfFuel;
            }

            set
            {
                m_TypeOfFuel = value;
            }
        }

        public override string GetEnergyToAddMSG()
        {
            return "enter amount fuel  to add";
        }

        public override string CreateOutOfRangMsg()
        {
            string answer = string.Format(
 @"Amount of fuel out of range
current you have: {0}. max is: {1}.", CurrentAmountOfEnergy, MaxAmountOfEnergy);
            return answer;
        }

        public override string ToString()
        {
            return string.Format(
@"Current amount of fuel : {0}
Max amount of fuel : {1}
Fuel Type: {2}",
CurrentAmountOfEnergy,
MaxAmountOfEnergy,
m_TypeOfFuel);
        }

        public void CheckFuelType(eFuelType i_FuelType)
        {
            if (i_FuelType != m_TypeOfFuel)
            {
                throw new ArgumentException(
                    string.Format(
                    "Bad Input {0} but need {1}",
                    i_FuelType,
                    m_TypeOfFuel));
            }
        }

    }
}
