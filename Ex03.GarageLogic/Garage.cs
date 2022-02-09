using System;
using System.Collections.Generic;

namespace Ex03.GarageLogic
{
    public class Garage
    {
        private readonly Dictionary<string, TreatmentVehicle> r_ListOfTreatment = new Dictionary<string, TreatmentVehicle>();

        public Dictionary<string, TreatmentVehicle> TreatmentDictionaryList
        {
            get
            {
                return r_ListOfTreatment;
            }
        }

        public void IsVehicleExists(string i_Input)
        {
            if (!r_ListOfTreatment.ContainsKey(i_Input))
            {
                throw new ArgumentException(
                  string.Format("Vehicle {0} NOT FOUND in the garage",i_Input));
            }
        }
        public void ChangeStatusOfVehicleByPlateNumber(TreatmentVehicle.eCurrentStatusOfVehicle i_ChangeToStatus, string i_PlateLicenseNumber)
        {
            r_ListOfTreatment[i_PlateLicenseNumber].CurrentStatus = i_ChangeToStatus;
        }

        public void AddVehicleToTreatmentList( string i_NameOfOwner, string i_PhoneOwner, Vehicle i_AddNewVehicle)
        {
            TreatmentVehicle newTreatmentToAdd = new TreatmentVehicle(i_NameOfOwner, i_PhoneOwner, i_AddNewVehicle);

            r_ListOfTreatment.Add(i_AddNewVehicle.NumberOfLicensePlate, newTreatmentToAdd);
        }

    }
}
