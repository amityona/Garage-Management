using System;
using System.Collections.Generic;
using System.Text;

namespace Ex03.GarageLogic
{
    public class TreatmentVehicle
    {

        private string m_NameOwnerVehicle;
        private string m_PhoneOwnerVehicle;
        private eCurrentStatusOfVehicle m_CurrentStatus;
        private Vehicle m_Vehicle;


        public enum eCurrentStatusOfVehicle
        {
            Fixed = 1,
            Paid,
            InTreatment,
        }
        public TreatmentVehicle(string i_NameOwnerVehicle, string i_PhoneOwnerVichle , Vehicle i_AddNewVehcile)
        {
            m_CurrentStatus = eCurrentStatusOfVehicle.InTreatment;
            m_Vehicle = i_AddNewVehcile;
            m_NameOwnerVehicle = i_NameOwnerVehicle;
            m_PhoneOwnerVehicle = i_PhoneOwnerVichle;

        }
        public void CheckEqualStatus(eCurrentStatusOfVehicle userChoice)
        {
            if ((TreatmentVehicle.eCurrentStatusOfVehicle)userChoice == m_CurrentStatus)
            {
                throw new ArgumentException(
                    string.Format("The vehicle status is : {0} ", m_CurrentStatus));
            }
        }

        public string NameOwnerVehicle
        {
            get
            {
                return m_NameOwnerVehicle;
            }

            set
            {
                m_NameOwnerVehicle = value;
            }
        }

        public string PhoneOwnerVhicle
        {
            get
            {
                return m_PhoneOwnerVehicle;
            }

            set
            {
                m_PhoneOwnerVehicle = value;
            }
        }

        public eCurrentStatusOfVehicle CurrentStatus
        {
            get
            {
                return m_CurrentStatus;
            }

            set
            {
                m_CurrentStatus = value;
            }
        }

        public Vehicle Vehicle
        {
            get
            {
                return m_Vehicle;
            }

            set
            {
                m_Vehicle = value;
            }
        }

        public override string ToString()
        {
            StringBuilder answerString = new StringBuilder();
            string TreatmentVehicleDetails;

            TreatmentVehicleDetails = string.Format(
@"Owner name: {0} Owner phone: {1} Vehicle status: {2}" , m_NameOwnerVehicle, m_PhoneOwnerVehicle, m_CurrentStatus.ToString());
            answerString.Append(TreatmentVehicleDetails);
            answerString.Append(m_Vehicle.ToString());
            return answerString.ToString();
        }

    }
}
