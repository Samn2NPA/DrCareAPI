﻿//------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated from a template.
//
//    Manual changes to this file may cause unexpected behavior in your application.
//    Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace DrCareApi.Models
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    using System.Data.Objects;
    using System.Data.Objects.DataClasses;
    using System.Linq;
    
    public partial class DRCAREEntities : DbContext
    {
        public DRCAREEntities()
            : base("name=DRCAREEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
    
        public virtual ObjectResult<sp_DISEASE_getAllDisease_Result> sp_DISEASE_getAllDisease()
        {
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<sp_DISEASE_getAllDisease_Result>("sp_DISEASE_getAllDisease");
        }
    
        public virtual ObjectResult<sp_Get_Search_MedicalRecordDetails_Result> sp_Get_Search_MedicalRecordDetails(Nullable<int> mecRcID, Nullable<int> doctorID, string dayCreated)
        {
            var mecRcIDParameter = mecRcID.HasValue ?
                new ObjectParameter("MecRcID", mecRcID) :
                new ObjectParameter("MecRcID", typeof(int));
    
            var doctorIDParameter = doctorID.HasValue ?
                new ObjectParameter("DoctorID", doctorID) :
                new ObjectParameter("DoctorID", typeof(int));
    
            var dayCreatedParameter = dayCreated != null ?
                new ObjectParameter("DayCreated", dayCreated) :
                new ObjectParameter("DayCreated", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<sp_Get_Search_MedicalRecordDetails_Result>("sp_Get_Search_MedicalRecordDetails", mecRcIDParameter, doctorIDParameter, dayCreatedParameter);
        }
    
        public virtual ObjectResult<sp_getPrecriptionByMecRcDetailsID_Result> sp_getPrecriptionByMecRcDetailsID(Nullable<int> mecRcDtID)
        {
            var mecRcDtIDParameter = mecRcDtID.HasValue ?
                new ObjectParameter("MecRcDtID", mecRcDtID) :
                new ObjectParameter("MecRcDtID", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<sp_getPrecriptionByMecRcDetailsID_Result>("sp_getPrecriptionByMecRcDetailsID", mecRcDtIDParameter);
        }
    
        public virtual ObjectResult<sp_getRemindListByMecRcDetailsID_Result> sp_getRemindListByMecRcDetailsID(Nullable<int> mecRcDetailsID)
        {
            var mecRcDetailsIDParameter = mecRcDetailsID.HasValue ?
                new ObjectParameter("MecRcDetailsID", mecRcDetailsID) :
                new ObjectParameter("MecRcDetailsID", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<sp_getRemindListByMecRcDetailsID_Result>("sp_getRemindListByMecRcDetailsID", mecRcDetailsIDParameter);
        }
    
        public virtual ObjectResult<sp_MEDICAL_RECORD_DETAILS_AddNewMedicalRecord_Result> sp_MEDICAL_RECORD_DETAILS_AddNewMedicalRecord(Nullable<int> mecRcID, Nullable<int> diseaseID, Nullable<int> doctorID)
        {
            var mecRcIDParameter = mecRcID.HasValue ?
                new ObjectParameter("MecRcID", mecRcID) :
                new ObjectParameter("MecRcID", typeof(int));
    
            var diseaseIDParameter = diseaseID.HasValue ?
                new ObjectParameter("DiseaseID", diseaseID) :
                new ObjectParameter("DiseaseID", typeof(int));
    
            var doctorIDParameter = doctorID.HasValue ?
                new ObjectParameter("DoctorID", doctorID) :
                new ObjectParameter("DoctorID", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<sp_MEDICAL_RECORD_DETAILS_AddNewMedicalRecord_Result>("sp_MEDICAL_RECORD_DETAILS_AddNewMedicalRecord", mecRcIDParameter, diseaseIDParameter, doctorIDParameter);
        }
    
        public virtual ObjectResult<sp_MEDICINE_getAllMedicine_Result> sp_MEDICINE_getAllMedicine()
        {
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<sp_MEDICINE_getAllMedicine_Result>("sp_MEDICINE_getAllMedicine");
        }
    
        public virtual ObjectResult<sp_PRESCRIPTION_AddNewIncription_Result> sp_PRESCRIPTION_AddNewIncription(Nullable<int> mecRcDtID, Nullable<int> medID, Nullable<double> medQty, Nullable<short> timeTakeMedicine, Nullable<short> sumMedQty)
        {
            var mecRcDtIDParameter = mecRcDtID.HasValue ?
                new ObjectParameter("MecRcDtID", mecRcDtID) :
                new ObjectParameter("MecRcDtID", typeof(int));
    
            var medIDParameter = medID.HasValue ?
                new ObjectParameter("MedID", medID) :
                new ObjectParameter("MedID", typeof(int));
    
            var medQtyParameter = medQty.HasValue ?
                new ObjectParameter("MedQty", medQty) :
                new ObjectParameter("MedQty", typeof(double));
    
            var timeTakeMedicineParameter = timeTakeMedicine.HasValue ?
                new ObjectParameter("TimeTakeMedicine", timeTakeMedicine) :
                new ObjectParameter("TimeTakeMedicine", typeof(short));
    
            var sumMedQtyParameter = sumMedQty.HasValue ?
                new ObjectParameter("SumMedQty", sumMedQty) :
                new ObjectParameter("SumMedQty", typeof(short));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<sp_PRESCRIPTION_AddNewIncription_Result>("sp_PRESCRIPTION_AddNewIncription", mecRcDtIDParameter, medIDParameter, medQtyParameter, timeTakeMedicineParameter, sumMedQtyParameter);
        }
    
        public virtual int sp_REMIND_RemindDetails_AddNewRemind(Nullable<int> mecRcDtID, Nullable<int> remindID, Nullable<System.TimeSpan> timeRemind, Nullable<int> isRepeat, string sound, string label, Nullable<bool> isActivate)
        {
            var mecRcDtIDParameter = mecRcDtID.HasValue ?
                new ObjectParameter("MecRcDtID", mecRcDtID) :
                new ObjectParameter("MecRcDtID", typeof(int));
    
            var remindIDParameter = remindID.HasValue ?
                new ObjectParameter("remindID", remindID) :
                new ObjectParameter("remindID", typeof(int));
    
            var timeRemindParameter = timeRemind.HasValue ?
                new ObjectParameter("TimeRemind", timeRemind) :
                new ObjectParameter("TimeRemind", typeof(System.TimeSpan));
    
            var isRepeatParameter = isRepeat.HasValue ?
                new ObjectParameter("isRepeat", isRepeat) :
                new ObjectParameter("isRepeat", typeof(int));
    
            var soundParameter = sound != null ?
                new ObjectParameter("sound", sound) :
                new ObjectParameter("sound", typeof(string));
    
            var labelParameter = label != null ?
                new ObjectParameter("label", label) :
                new ObjectParameter("label", typeof(string));
    
            var isActivateParameter = isActivate.HasValue ?
                new ObjectParameter("isActivate", isActivate) :
                new ObjectParameter("isActivate", typeof(bool));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("sp_REMIND_RemindDetails_AddNewRemind", mecRcDtIDParameter, remindIDParameter, timeRemindParameter, isRepeatParameter, soundParameter, labelParameter, isActivateParameter);
        }
    }
}