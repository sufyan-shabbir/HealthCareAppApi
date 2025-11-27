namespace HealthCareAppApi.Enum
{
    public class KMH_Enum
    {

        public enum KMH_Roles
        {
            SuperAdminKmh = 1, 
        }

        public enum OPDBillStatus
        {
            Unpaid = 39,
            PartiallyPaid = 40,
            Paid = 41,
            Cancelled = 51
        }

        public enum FormNameEnum
        {
            Company = 1,
            ApplicationUser = 3,
            Menu = 4,
            Patient = 5,
            Service = 6,
            OPDBilling = 7,
            OPDRefund = 8,
            Employee = 9,
            Panel = 10,
            City = 11,

            Area = 12,
            Country = 13,
            State = 14,
            PaymentMode = 15,
            Welfare = 16,
            Zakat = 17,
            ApprovedZakat = 17,
            OpdPatient = 18,
            Dialysis= 19,
            DialysisPatientlist= 20,
            EmergencyPatientlist= 24,
            EmergencyPatientRegisterlist= 25,




        }
        public enum TableNameEnum
        {
            OPDBillMaster,
            Patient,
            Kmh_Service,
            Company,
            ApplicationUser,
            Menu,
            OPDRefund,

        }


        //public enum OPDBillFilterFields
        //{
        //    MrNo,
        //    StatusId,
        //}
        //public enum PatientFilterFields
        //{
        //    MrNo,
        //    DepartmentId,
        //    DateFrom,
        //    DateTo,
        //    SearchText
        //}
        //public enum ServiceFilterFields
        //{
        //    MrNo,
        //    DepartmentId,
        //    DateFrom,
        //    DateTo,
        //    SearchText
        //}
    }

}
