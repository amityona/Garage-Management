using System;
using System.Collections.Generic;
using System.Text;
using Ex03.GarageLogic;

namespace Ex03.ConsoleUI
{
    public class UserInterface
    {
        private const int k_Index = 1;
        public enum eFirstWitchUserChoice
        {
            AddVehicleToGarage = 1,
            DisplayLicensePlatesByStatus,
            DisplayAllLicensePlateVechivleDetails,
            ChangeVehicleStatus,
            PumpPulley,
            FillEnergySource,
            DisplayAllDetailsVehicleByPlateNumber,
            Exit,
        }
        public void VehicleFoundInTheGarageAlert()
        {
            Console.WriteLine("vehicle found in garage - status changed to in treatment");
        }
        public void GenericrPrint(string i_DisplayString)
        {
            Console.WriteLine(i_DisplayString);
        }
        private void PrintFirstMsg()
        {
            Console.WriteLine("Select the number that you want");
        }
        public void PrintNumberOfLicensePlate(bool i_DisplayAll,int i_UserChoice, Dictionary<string, TreatmentVehicle> i_TreatmentList)
        {
            TreatmentVehicle.eCurrentStatusOfVehicle checkStatus = (TreatmentVehicle.eCurrentStatusOfVehicle)i_UserChoice;

            foreach (TreatmentVehicle current in i_TreatmentList.Values)
            {
                if (current.CurrentStatus == checkStatus || i_DisplayAll)
                {
                    Console.WriteLine(current.Vehicle.NumberOfLicensePlate);
                }
            }
        }
        public int SelectAmountOfCargo()
        {
            bool isValidInput = false;
            int loadOfCapacity = 0;
            string answer;
            GenericrPrint("Please insert volume of cargo");
            while (!isValidInput)
            {
                try
                {
                    answer = Console.ReadLine();
                    loadOfCapacity = int.Parse(answer);
                    isValidInput = true;
                }
                catch (FormatException)
                {
                    InvalidInputTryAgainMsg();
                    isValidInput = false;
                }
            }
            return loadOfCapacity;
        }
        public string SelectNameOfTheOwner()
        {
            string answer = null;
            while (string.IsNullOrEmpty(answer))
            {
                Console.WriteLine("Insert owner full name");
                answer = Console.ReadLine();
            }
            return answer;
        }
        public string SelectPulleyMaker()
        {
            string answer=null;
            while (string.IsNullOrEmpty(answer))
            {
                Console.WriteLine("Select pulley maker");
                answer = Console.ReadLine();
            }
            return answer;
        }

        public string SelectModelOfVehicle()
        {
            string answer=null;
            while (string.IsNullOrEmpty(answer))
            {
                Console.WriteLine("Select vehicle model");
                answer = Console.ReadLine();
            }
            return answer;
        }
        public void SelectNumberOfLicensePlate(out string i_NumberOfLicensePlate,Garage i_Garage)
        {
            i_NumberOfLicensePlate = null;
            while (string.IsNullOrEmpty(i_NumberOfLicensePlate))
            {
                Console.WriteLine("select number license plate");
                i_NumberOfLicensePlate = Console.ReadLine();
            }
            i_Garage.IsVehicleExists(i_NumberOfLicensePlate);
        }

        public float SelectPulleyAirPressure()
        {
            bool isValidInput = false;
            string answer;
            float userAnswer = 0;
            Console.WriteLine("select air pressure to add");
            do
            {
                try
                {
                    answer = Console.ReadLine();
                    userAnswer = float.Parse(answer);
                    isValidInput = true;
                }
                catch (FormatException)
                {
                    InvalidInputTryAgainMsg();
                    isValidInput = false;
                }

            }
            while (!isValidInput);

            return userAnswer;
        }

        internal void SomethingWentWrongMsg()
        {
            Console.WriteLine("Error input try again!");
        }

        private int GetInput<T>(string i_Message, T i_Enum)
        {
            bool isValidInput = true;
            string answer;
            int userAnswer = 0;
            do
            {
                PrintFirstMsg();
                Console.WriteLine(i_Message);

                if (!isValidInput)
                {
                    InvalidInputTryAgainMsg();
                }

                try
                {
                    answer = Console.ReadLine();
                    userAnswer = int.Parse(answer);
                    isValidInput = Enum.IsDefined(typeof(T), userAnswer);
                }
                catch (FormatException)
                {
                    isValidInput = false;
                }
            }
            while (!isValidInput);

            return userAnswer;
        }
        public static bool CheckIsValidPhone(string i_PhoneInputToCheck) 
        {
            long.Parse(i_PhoneInputToCheck);
            return true;
        }
        public string SelectOwnerPhone()
        {
            bool isValidInput = false;
            string answer = null;
            Console.WriteLine("Insert phone number");
            while (!isValidInput)
            {
                try
                {
                    answer = Console.ReadLine();
                    isValidInput = UserInterface.CheckIsValidPhone(answer);
                }
                catch (FormatException)
                {
                    InvalidInputTryAgainMsg();
                    isValidInput = false;
                }
                catch (ValueOutOfRangeException err)
                {
                    Console.WriteLine(err.Message);
                    isValidInput = false;
                }

            }

            return answer;
        }
        public eFirstWitchUserChoice DisplayOpstionAndSelect()
        {
            eFirstWitchUserChoice userChoiceOptions = new eFirstWitchUserChoice();
            int userChoice;
            userChoice = GetSpecificEnumInput(userChoiceOptions);
            Console.Clear();
            return (eFirstWitchUserChoice)userChoice;
        }
        private string BuildListOfTheEnum(string[] i_OpstionEnum)
        {
            StringBuilder result = new StringBuilder();
            int currentIndex = k_Index;

            foreach (string currentEnum in i_OpstionEnum)
            {
                result.Append(string.Format("{0}. {1} {2}", currentIndex++, currentEnum, Environment.NewLine));
            }

            return FixGenricOutput(result.ToString());
        }

        public string FixGenricOutput(string i_InputString)
        {
            StringBuilder answer = new StringBuilder();
            char prevChar = i_InputString[0];
            foreach (char currentChar in i_InputString)
            {
                if (prevChar >= 'a' && currentChar >= 'A' && (currentChar <= 'Z' && prevChar <= 'z'))
                {
                    answer.Append(' ');
                }

                answer.Append(currentChar);
                prevChar = currentChar;
            }
            return answer.ToString();
        }
        public int SelectEngineCapacity()
        {
            bool isValidInput = false;
            int userAnswer = 0;
            string answer;
            while (!isValidInput)
            {
                Console.WriteLine("insert amout of engine");
                try
                {
                    answer = Console.ReadLine();
                    userAnswer = int.Parse(answer);
                    isValidInput = true;
                }
                catch (FormatException)
                {
                    InvalidInputTryAgainMsg();
                    isValidInput = false;
                }
            }
            return userAnswer;
        }

        public int GetSpecificEnumInput<T>(T i_EnumInput)
        {
            string[] listOfAnswer = (string[])Enum.GetNames(typeof(T));
            int answer = GetInput(BuildListOfTheEnum(listOfAnswer), i_EnumInput);
            return answer;
        }

        public void InvalidInputTryAgainMsg()
        {
            Console.WriteLine("Errorr ! bad input , try again");
        }
    }
}
