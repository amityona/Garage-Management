using System;
using System.Collections.Generic;
using System.Text;

using Ex03.GarageLogic;

namespace Ex03.ConsoleUI
{
    public class GarageManagement
    {
        private UserInterface m_UserInterFace = new UserInterface();
        private readonly Garage m_Garage = new Garage();
        public UserInterface ObjOfInterFace
        {
            get
            {
                return m_UserInterFace;
            }

            set
            {
                m_UserInterFace = value;
            }
        }

        public Garage Garage
        {
            get
            {
                return m_Garage;
            }
        }
        public void Start()
        {
            UserInterface.eFirstWitchUserChoice userAnswer;
            bool statusOfRunApp = false;
            while (!statusOfRunApp)
            {
                ObjOfInterFace.GenericrPrint(Environment.NewLine);
                try
                {
                    userAnswer = ObjOfInterFace.DisplayOpstionAndSelect();
                    switch (userAnswer)
                    {
                        case UserInterface.eFirstWitchUserChoice.Exit:
                            statusOfRunApp = true;
                            break;

                        case UserInterface.eFirstWitchUserChoice.AddVehicleToGarage:
                            InsertVehicleToGarage();
                            break;

                        case UserInterface.eFirstWitchUserChoice.DisplayLicensePlatesByStatus:
                            ShowVehicleDetailsByStatus();
                            break;

                        case UserInterface.eFirstWitchUserChoice.DisplayAllLicensePlateVechivleDetails:
                            ShowAllVechiledDetails();
                            break;

                        case UserInterface.eFirstWitchUserChoice.DisplayAllDetailsVehicleByPlateNumber:
                            ShowFullVehicleDetails();
                            break;


                        case UserInterface.eFirstWitchUserChoice.ChangeVehicleStatus:
                            ChangeVehicleStatus();
                            break;

                        case UserInterface.eFirstWitchUserChoice.FillEnergySource:
                            EnergiSourceFil();
                            break;

                        case UserInterface.eFirstWitchUserChoice.PumpPulley:
                            MaxPumpPulley();
                            break;

                        default:
                            ObjOfInterFace.InvalidInputTryAgainMsg();
                            break;
                    }
                }
                catch (OverflowException)
                {
                    ObjOfInterFace.SomethingWentWrongMsg();
                }
                catch (ArgumentException ae)
                {
                    ObjOfInterFace.GenericrPrint(ae.Message);
                }
                catch (FormatException)
                {
                    ObjOfInterFace.InvalidInputTryAgainMsg();
                }
            }
        }

        private void ShowFullVehicleDetails()
        {
            string numberOfLicnseNumber;
            ObjOfInterFace.SelectNumberOfLicensePlate(out numberOfLicnseNumber,m_Garage);
            ObjOfInterFace.GenericrPrint(ObjOfInterFace.FixGenricOutput(m_Garage.TreatmentDictionaryList[numberOfLicnseNumber].ToString()));
        }

        private void EnergiSourceFil()
        {
            FuelEnergy.eFuelType TypeOfFuel;
            FuelEnergy.eFuelType OptionOfFuel = new FuelEnergy.eFuelType();
            string numberOfLicnseNumber;
            ObjOfInterFace.SelectNumberOfLicensePlate(out numberOfLicnseNumber, m_Garage);
            FuelEnergy statusOfGas = m_Garage.TreatmentDictionaryList[numberOfLicnseNumber].Vehicle.EnergySource as FuelEnergy;
            if (statusOfGas != null)
            {
                TypeOfFuel = (FuelEnergy.eFuelType)ObjOfInterFace.GetSpecificEnumInput(OptionOfFuel);
                statusOfGas.CheckFuelType(TypeOfFuel);
            }
            SelectAmountOfEnergyToAdd(m_Garage.TreatmentDictionaryList[numberOfLicnseNumber].Vehicle);
        }

        private void MaxPumpPulley()
        {
            string numberOfLicnseNumber;
            ObjOfInterFace.SelectNumberOfLicensePlate(out numberOfLicnseNumber, m_Garage);
            foreach (Pulley currentWheel in m_Garage.TreatmentDictionaryList[numberOfLicnseNumber].Vehicle.Pulleys)
            {
                currentWheel.UpdateAmoutAirPressure(currentWheel.MaxAirPressure - currentWheel.CurrentAirPressure);
            }
        }
        private void AddDetailsOfTheVehicle(Vehicle i_AddVehicle)
        {
            if (i_AddVehicle is Truck)
            {
                SelectCooldStatus((Truck)i_AddVehicle);
                InsertVolumeOfCargo((Truck)i_AddVehicle);
            }

            else if (i_AddVehicle is Motorcycle)
            {
                SelectLicenseType((Motorcycle)i_AddVehicle);
                SelectCapacityOfEngine((Motorcycle)i_AddVehicle);
            }
            else if (i_AddVehicle is Car)
            {
                SelectColor((Car)i_AddVehicle);
                SelectAmountOfDoors((Car)i_AddVehicle);
            }

            CurrrentPulleyAirPressure(i_AddVehicle);
            SelectAmountOfEnergyToAdd(i_AddVehicle);
        }

        private void ChangeVehicleStatus()
        {
            int userChoice;
            string numberOfLicensePlate;
            TreatmentVehicle.eCurrentStatusOfVehicle statusOptions = new TreatmentVehicle.eCurrentStatusOfVehicle();
            ObjOfInterFace.SelectNumberOfLicensePlate(out numberOfLicensePlate , m_Garage);
            userChoice = ObjOfInterFace.GetSpecificEnumInput(statusOptions);
            m_Garage.TreatmentDictionaryList[numberOfLicensePlate].CheckEqualStatus((TreatmentVehicle.eCurrentStatusOfVehicle)userChoice);
            m_Garage.TreatmentDictionaryList[numberOfLicensePlate].CurrentStatus = (TreatmentVehicle.eCurrentStatusOfVehicle)userChoice;
        }
        private void ShowVehicleDetailsByStatus()
        {
          TreatmentVehicle.eCurrentStatusOfVehicle statusDisplayTreatmentOptions = new TreatmentVehicle.eCurrentStatusOfVehicle();
            int answer = ObjOfInterFace.GetSpecificEnumInput(statusDisplayTreatmentOptions);
            ObjOfInterFace.PrintNumberOfLicensePlate(false, answer, m_Garage.TreatmentDictionaryList);
        }
        private void ShowAllVechiledDetails()
        {
            bool showAllDetails = true;
            ObjOfInterFace.PrintNumberOfLicensePlate(showAllDetails, 0, m_Garage.TreatmentDictionaryList);
        }
        private void InsertVehicleToGarage()
        {
            bool VehicleFoundInTheGarage = true;
            string numberOfLicunsePlate = null, modelName, pulleyMaker, ownerName, ownerPhone;
            Vehicle addVehicle;
            try
            {
                ObjOfInterFace.SelectNumberOfLicensePlate(out numberOfLicunsePlate, m_Garage);
            }
            catch (ArgumentException)
            {
                VehicleFoundInTheGarage = false;
            }

            if (VehicleFoundInTheGarage)
            {
                ObjOfInterFace.VehicleFoundInTheGarageAlert();
                m_Garage.ChangeStatusOfVehicleByPlateNumber(TreatmentVehicle.eCurrentStatusOfVehicle.InTreatment , numberOfLicunsePlate);
            }
            else
            {
                modelName = ObjOfInterFace.SelectModelOfVehicle();
                pulleyMaker = ObjOfInterFace.SelectPulleyMaker();
                addVehicle = AddNewVehicle(pulleyMaker, numberOfLicunsePlate, modelName, out ownerPhone , out ownerName);
                m_Garage.AddVehicleToTreatmentList(ownerName, ownerPhone, addVehicle);
            }
        }

        private Vehicle AddNewVehicle(string i_PulleyMaker,string i_NumberOfLicensePlate,string i_NameOfModel,out string o_PhoneOfOwner , out string o_NameOfOwner)
        {
            EnergySource.eEnergyTypeOfSource opstionOfEnergey = new EnergySource.eEnergyTypeOfSource();
            Vehicle addVehicle;
            Vehicle.eTypeOfTheVehicle vehicleOptions = new Vehicle.eTypeOfTheVehicle();
            Vehicle.eTypeOfTheVehicle typeOfVeichle = new Vehicle.eTypeOfTheVehicle();
            EnergySource.eEnergyTypeOfSource vehicleEnergySource;
            o_NameOfOwner = ObjOfInterFace.SelectNameOfTheOwner();
            o_PhoneOfOwner = ObjOfInterFace.SelectOwnerPhone();
            typeOfVeichle = (Vehicle.eTypeOfTheVehicle)ObjOfInterFace.GetSpecificEnumInput(vehicleOptions);
            if (typeOfVeichle != Vehicle.eTypeOfTheVehicle.Truck)
            {
                vehicleEnergySource = (EnergySource.eEnergyTypeOfSource)ObjOfInterFace.GetSpecificEnumInput(opstionOfEnergey);
            }
            else
            {
                vehicleEnergySource = EnergySource.eEnergyTypeOfSource.GasTank;
            }

            addVehicle = ManagmentVechile.CreateVehicle(typeOfVeichle, vehicleEnergySource, i_NumberOfLicensePlate, i_NameOfModel, i_PulleyMaker);
            AddDetailsOfTheVehicle(addVehicle);
            return addVehicle;
        }
        private void SelectColor(Car i_NewCar)
        {
            Car.eTypeColorOfCar carColorOptions = new Car.eTypeColorOfCar();
            int answer;
            answer = ObjOfInterFace.GetSpecificEnumInput(carColorOptions);
            i_NewCar.Color = (Car.eTypeColorOfCar)answer;
        }

        private void SelectCapacityOfEngine(Motorcycle i_NewMotorcycle)
        {
            int engineCapacity;

            engineCapacity = ObjOfInterFace.SelectEngineCapacity();
            i_NewMotorcycle.FuelContent = engineCapacity;
        }
        private void SelectAmountOfEnergyToAdd(Vehicle i_AddVehicle)
        {
            string answer;
            float amountOfEnergyToEnter;
            bool isValidInput = true;
            ObjOfInterFace.GenericrPrint(i_AddVehicle.EnergySource.GetEnergyToAddMSG());
           do
            { 
                try
                {
                    answer = Console.ReadLine();
                    amountOfEnergyToEnter = float.Parse(answer);
                    i_AddVehicle.EnergySource.UpdateEnergy(amountOfEnergyToEnter);
                    isValidInput = true;
                }
                catch (ValueOutOfRangeException)
                {
                    ObjOfInterFace.GenericrPrint(string.Format(
@"{0} Error! enter the amount to add",
i_AddVehicle.EnergySource.CreateOutOfRangMsg()));
                    ObjOfInterFace.InvalidInputTryAgainMsg();
                    isValidInput = false;
                }
                catch (FormatException)
                {
                    ObjOfInterFace.InvalidInputTryAgainMsg();
                    isValidInput = false;
                }
            }
            while (!isValidInput) ;

                i_AddVehicle.ChangeEnergyAmout();
        }
        private void SelectCooldStatus(Truck i_AddTruck)
        {
            int userChoice;
            Console.WriteLine(@"0.Dont cold 
1.Cold Abailty");
            bool runSelect = true;
            while (runSelect)
            {
                string answer = Console.ReadLine();
                bool success = int.TryParse(answer, out userChoice);
                if (success)
                {
                    if (userChoice == 1)
                    {
                        i_AddTruck.AbailtyCool = true;
                        break;
                    }
                    else if (userChoice == 0)
                    {
                        i_AddTruck.AbailtyCool = false;
                        break;
                    }
                    else
                    {
                        Console.WriteLine("Errorr Input Try Again!");
                        continue;
                    }
                }
                else
                {
                    Console.WriteLine("Errorr Input Try Again!");
                    continue;
                }
            }
        }

        private void CurrrentPulleyAirPressure(Vehicle i_NewVehicle)
        {
            bool isValid = true;
            float airPressureToAdd;
            do
            { 
                airPressureToAdd = ObjOfInterFace.SelectPulleyAirPressure();
                try
                {
                    foreach (Pulley currentWheel in i_NewVehicle.Pulleys)
                    {
                        currentWheel.UpdateAmoutAirPressure(airPressureToAdd);
                    }

                    isValid = true;
                }
                catch (ValueOutOfRangeException)
                {
                    ObjOfInterFace.GenericrPrint(string.Format(
@"Bad Input Of Air, now the pressure is {0} and at most for this vehcile is {1}",
    i_NewVehicle.Pulleys[0].CurrentAirPressure,
    i_NewVehicle.Pulleys[0].MaxAirPressure));
                    isValid = false;
                }
            }
            while (!isValid);
        }

        private void InsertVolumeOfCargo(Truck i_AddTruck)
        {
            int AmountOfCargo;
            AmountOfCargo = ObjOfInterFace.SelectAmountOfCargo();
            i_AddTruck.LoadVolume = AmountOfCargo;
        }

        private void SelectAmountOfDoors(Car i_NewCar)
        {
            Car.eAmountOfDoorsToCar amountOfDoorsOptions = new Car.eAmountOfDoorsToCar();
            int answer;
            answer = ObjOfInterFace.GetSpecificEnumInput(amountOfDoorsOptions);
            i_NewCar.AmountOfDoors = (Car.eAmountOfDoorsToCar)answer;
        }


        private void SelectLicenseType(Motorcycle i_AddMotorcycle)
        {
            int codeLicense;
            Motorcycle.eLisenceType codeLicenseEnum = new Motorcycle.eLisenceType();
            codeLicense = ObjOfInterFace.GetSpecificEnumInput(codeLicenseEnum);
            i_AddMotorcycle.LicenseType = (Motorcycle.eLisenceType)codeLicense;
        }
    }
}
