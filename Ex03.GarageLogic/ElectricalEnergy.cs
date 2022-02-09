using System;
using System.Collections.Generic;

namespace Ex03.GarageLogic
{
    public class ElectricalEnergy : EnergySource
    {
        public override string GetEnergyToAddMSG()
        {
            return "Enter amount of battery you want to add";
        }

        public override string CreateOutOfRangMsg()
        {

           string answer = string.Format(
@"Errorr not charged now - {0} max to {1} hour's.",CurrentAmountOfEnergy,MaxAmountOfEnergy);
            return answer;
        }

        public override string ToString()
        {
            return string.Format(
@"Battery left : {0} Max : {1}",CurrentAmountOfEnergy,MaxAmountOfEnergy);
        }
    }
}
