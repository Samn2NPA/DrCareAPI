//------------------------------------------------------------------------------
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
    
    public partial class sp_getPrecriptionByMecRcDetailsID_Result
    {
        public int mã_phiếu_khám_bệnh { get; set; }
        public string Tên_thuốc { get; set; }
        public Nullable<double> SL_thuốc_lần { get; set; }
        public Nullable<bool> Sáng { get; set; }
        public Nullable<bool> Trưa { get; set; }
        public Nullable<bool> Chiều { get; set; }
        public Nullable<short> Số_ngày { get; set; }
        public string Bác_sĩ { get; set; }
        public string Ngày_chẩn_đoán { get; set; }
        public string Chẩn_đoán { get; set; }
    }
}
