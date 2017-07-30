using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DrCareApi.Models
{
    public class MedicineResult
    {
        public bool status { get; set; }
        public List<sp_MEDICINE_getAllMedicine_Result> response { get; set; }

        public string errorMessage { get; set; }
    }

    public class MedicalRecordDetails_DOCTOR
    {
        public bool status { get; set; }
        public List<sp_MedicalRecordDetails_DOCTOR_Get_Result> response { get; set; }

        public string errorMessage { get; set; }

    }

    public class MedicalRecordDetails_PATIENT_Details
    {
        public bool status { get; set; }

        public List<MedicalRecordDetails_PATIENT> response { get; set; }

        public string errorMessage { get; set; }
    }

    public class MedicalRecordDetails_PATIENT
    { 
        public int MecRcDetailsID { get; set; }
        public int PatientID { get; set; }
        public int DiseaseID { get; set; }
        public string DISEASEName { get; set; }
        public int DoctorID { get; set; }
        public string DoctorName { get; set; }
        public string Symptoms { get; set; }
        public string DayCreated { get; set; }
        public Nullable<bool> isTaken { get; set; }

        public List<sp_PRESCRIPTION_getByMecRcDetailsID_Result> prescription { get; set; }
    }
}