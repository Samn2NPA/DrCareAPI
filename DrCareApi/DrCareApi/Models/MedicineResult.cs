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
}