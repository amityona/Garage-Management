using System;
using System.Collections.Generic;
using System.Text;

namespace Ex03.GarageLogic
{
    public class ManagmentVechile
    {
        public static Vehicle CreateVehicle(
            Vehicle.eTypeOfTheVehicle i_TypeOfVehicle,
            EnergySource.eEnergyTypeOfSource i_SourceOfEnergy,
            string i_NumberLicensePlate,
            string i_Model,
            string i_PulleyMaker)
       
        {
            Vehicle anser = null;

            switch (i_TypeOfVehicle)
            {
                case Vehicle.eTypeOfTheVehicle.Motorcycle:
                    anser = new Motorcycle(i_NumberLicensePlate, i_Model, i_PulleyMaker, i_SourceOfEnergy);
                    break;

                case Vehicle.eTypeOfTheVehicle.Car:
                    anser = new Car(i_NumberLicensePlate, i_Model, i_PulleyMaker, i_SourceOfEnergy);
                    break;

                case Vehicle.eTypeOfTheVehicle.Truck:
                    anser = new Truck(i_SourceOfEnergy,i_Model, i_NumberLicensePlate, i_PulleyMaker);
                    break;
            }

            return anser;
        }
    }
}
