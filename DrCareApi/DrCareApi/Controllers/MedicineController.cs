using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using DrCareApi.Models;
using System.Data.Objects;
using System.Data.SqlClient;
namespace DrCareApi.Controllers
{
    [System.Web.Http.RoutePrefix("api")]
    public class MedicineController : ApiController
    {
        DRCAREEntities DRCARE = new DRCAREEntities(); //f12 vào đây để coi kiểu trả về khi exec sproc

        /*---------------------------cua anh------------------------------------*/
        [Route("DISEASE/GetAll")]
        public HttpResponseMessage GetAllDISEASE()
        {
            DiseaseResult result = new DiseaseResult(); //cái này là Model để trả về kết quả cuối cùng
            //mỗi storeproc sẽ trả về kq khác nhau

            // viết giống ví dụ trên! 
            StatusConnection stt = checkConnection.isServerConnected();

            //gắn trạng thái về kết quả
            result.errorMessage = stt.errorMessage;
            result.status = stt.status;

            //hàm gọi store proc --  đã được viết sẵn trong DBContext rồi
            // muốn lấy được kiểu trả về của sp thì vào class DRCAREEntities() coi. (F12 vào chỗ khỏi tạo DRCARE ở trên
            ObjectResult<sp_DISEASE_getAllDisease_Result> obj = DRCARE.sp_DISEASE_getAllDisease();
            result.response = obj.ToList();

            return Request.CreateResponse(HttpStatusCode.OK, result);
        }

        [Route("RemindList/ByMecRcDetailsID/{mecRcDetailsID?}")]
        [HttpGet]
        public HttpResponseMessage GetSearchMedicalRecordDetails_Doctor(int? mecRcDetailsID)//(int? mecRcID, int? doctorID, string dayCreated)
        {
            RemindList result = new RemindList(); //cái này là Model để trả về kết quả cuối cùng

            StatusConnection stt = checkConnection.isServerConnected();

            result.errorMessage = stt.errorMessage;
            result.status = stt.status;

            ObjectResult<sp_getRemindListByMecRcDetailsID_Result> obj = DRCARE.sp_getRemindListByMecRcDetailsID(mecRcDetailsID);

            result.response = obj.ToList();

            return Request.CreateResponse(HttpStatusCode.OK, result);
        }

        [Route("MedicalRecordDetails/AddNewMedicalRecord/{mecRcID?}/{diseaseID?}/{doctorID?}")]
        [HttpGet]
        public HttpResponseMessage AddNewMedicalRecord(int? mecRcID, int? diseaseID, int? doctorID)//(int? mecRcID, int? doctorID, string dayCreated)
        {
            AddNewMedicalRecord_Result result = new AddNewMedicalRecord_Result(); //cái này là Model để trả về kết quả cuối cùng

            StatusConnection stt = checkConnection.isServerConnected();

            result.errorMessage = stt.errorMessage;
            result.status = stt.status;

            ObjectResult<sp_MEDICAL_RECORD_DETAILS_AddNewMedicalRecord_Result> obj = DRCARE.sp_MEDICAL_RECORD_DETAILS_AddNewMedicalRecord(mecRcID, diseaseID, doctorID);

            result.response = obj.ToList();

            return Request.CreateResponse(HttpStatusCode.OK, result);
        }

        [Route("PRESCRIPTION/AddNewIncription/{mecRcID?}/{medID?}/{medQty?}/{timeTakeMedicine?}/{sumMedQty?}")]
        [HttpGet]
        public HttpResponseMessage AddNewIncription(int? mecRcDtID, int? medID, double? medQty, short? timeTakeMedicine, short? sumMedQty)//(int? mecRcID, int? doctorID, string dayCreated)
        {
            AddNewIncription_Result result = new AddNewIncription_Result(); //cái này là Model để trả về kết quả cuối cùng

            StatusConnection stt = checkConnection.isServerConnected();

            result.errorMessage = stt.errorMessage;
            result.status = stt.status;

            ObjectResult<sp_PRESCRIPTION_AddNewIncription_Result> obj = DRCARE.sp_PRESCRIPTION_AddNewIncription(mecRcDtID, medID, medQty, timeTakeMedicine, sumMedQty);

            result.response = obj.ToList();

            return Request.CreateResponse(HttpStatusCode.OK, result);
        }


        /*----------------------------------------------------------------------*/

        [Route("Medicine/GetAll")]
        public HttpResponseMessage GetAllMedicine()
        {
            MedicineResult result = new MedicineResult(); //cái này là Model để trả về kết quả cuối cùng
            //mỗi storeproc sẽ trả về kq khác nhau

            // viết giống ví dụ trên! 
            StatusConnection stt = checkConnection.isServerConnected();

            //gắn trạng thái về kết quả
            result.errorMessage = stt.errorMessage;
            result.status = stt.status;

            //hàm gọi store proc --  đã được viết sẵn trong DBContext rồi
            // muốn lấy được kiểu trả về của sp thì vào class DRCAREEntities() coi. (F12 vào chỗ khỏi tạo DRCARE ở trên
            ObjectResult<sp_MEDICINE_getAllMedicine_Result> obj = DRCARE.sp_MEDICINE_getAllMedicine();
            result.response = obj.ToList();

            return Request.CreateResponse(HttpStatusCode.OK, result);
         }

        // viết giống ví dụ trên! 

        [Route("MedicalRecordDetails/DoctorGet/{doctorID?}/{dayCreated}")]
        [HttpGet]
        public HttpResponseMessage GetSearchMedicalRecordDetails_Doctor(int? doctorID, string dayCreated)//(int? mecRcID, int? doctorID, string dayCreated)
        {
            MedicalRecordDetails_DOCTOR result = new MedicalRecordDetails_DOCTOR(); //cái này là Model để trả về kết quả cuối cùng
            
            StatusConnection stt = checkConnection.isServerConnected();
            
            result.errorMessage = stt.errorMessage;
            result.status = stt.status;

            //convert lại string dayCreated theo format dd/MM/yyyy
            //string text = dayCreated.Trim('"');
            //text = text.Trim('-');
            DateTime dt = DateTime.ParseExact(dayCreated, "ddMMyyyy", System.Globalization.CultureInfo.InvariantCulture);
            dayCreated = dt.ToString("dd/MM/yyyy", System.Globalization.CultureInfo.InvariantCulture);

            ObjectResult<sp_MedicalRecordDetails_DOCTOR_Get_Result> obj = DRCARE.sp_MedicalRecordDetails_DOCTOR_Get(doctorID, dayCreated);
            
            result.response = obj.ToList();

            return Request.CreateResponse(HttpStatusCode.OK, result);
        }

        //[Route("MedicalRecodeDetails/PatientGet/{mecRcID?}/{doctorID?}/{dayCreated}")]
        [Route("MedicalRecordDetails/PatientGet/{mecRcID?}/{doctorID?}/{dayCreated}")]
        [HttpGet]
        public HttpResponseMessage GetSearchMedicalRecordDetails_Patient(int? mecRcID, int? doctorID, string dayCreated)
        {
            MedicalRecordDetails_PATIENT_Details result = new MedicalRecordDetails_PATIENT_Details(); //cái này là Model để trả về kết quả cuối cùng

            StatusConnection stt = checkConnection.isServerConnected();

            result.errorMessage = stt.errorMessage;
            result.status = stt.status;
            
            if (dayCreated == "null")
                dayCreated = null;
            else
            {
                //convert lại string dayCreated từ ddMMyyyy theo format dd/MM/yyyy
                //string text = dayCreated.Trim('"');
                //text = text.Trim('-');
                DateTime dt = DateTime.ParseExact(dayCreated, "ddMMyyyy", System.Globalization.CultureInfo.InvariantCulture);
                dayCreated = dt.ToString("dd/MM/yyyy", System.Globalization.CultureInfo.InvariantCulture);
            }

            ObjectResult<sp_MedicalRecordDetails_PATIENT_Get_Result> obj = DRCARE.sp_MedicalRecordDetails_PATIENT_Get(mecRcID, doctorID, dayCreated);

            List<MedicalRecordDetails_PATIENT> havePres = new List<MedicalRecordDetails_PATIENT>();

            foreach(sp_MedicalRecordDetails_PATIENT_Get_Result item in obj)
            {
                havePres.Add(bindData(item));
            }

            result.response = havePres;

            return Request.CreateResponse(HttpStatusCode.OK, result);
        }

        /* mục đích: bind kết quả trả về của Đơn thuốc về vào response khi search Patient luôn 
         * nên mới tạo 1 class <MedicalRecordDetails_PATIENT> để chứa thông tin của Phiếu khám bệnh và List đơn thuốc của phiếu đó 
         * hàm này để bind data từ Thông tin phiếu khám bệnh <sp_MedicalRecordDetails_PATIENT_Get_Result>
         * và List Đơn thuốc <sp_getPrecriptionByMecRcDetailsID_Result> của mỗi phiếu 
         * vào 1 object <MedicalRecordDetails_PATIENT_Details>
         *  */
        private MedicalRecordDetails_PATIENT bindData(sp_MedicalRecordDetails_PATIENT_Get_Result item)
        {
            ObjectResult<sp_PRESCRIPTION_getByMecRcDetailsID_Result> pres =
                                                  DRCARE.sp_PRESCRIPTION_getByMecRcDetailsID(item.MecRcDetailsID);
            MedicalRecordDetails_PATIENT inside = new MedicalRecordDetails_PATIENT();
            inside.MecRcDetailsID = item.MecRcDetailsID;
            inside.PatientID = item.PatientID;
            inside.DiseaseID = item.DiseaseID;
            inside.DISEASEName = item.DISEASEName;
            inside.DoctorID = item.DoctorID;
            inside.DoctorName = item.DoctorName;
            inside.Symptoms = item.Symptoms;
            inside.DayCreated = item.DayCreated;
            inside.isTaken = item.isTaken;
            inside.prescription = pres.ToList();

            return inside;
        }
    }

    public class checkConnection
    {
        public static StatusConnection isServerConnected()
        {
            StatusConnection resp = new StatusConnection();
            string connectionString = "data source=baotond.ddns.net;initial catalog=DRCARE;persist security info=True;user id=sa;password=b@ot0n123;MultipleActiveResultSets=True;App=EntityFramework";
            using (SqlConnection sqlConnection = new SqlConnection(connectionString))
            {
                try
                {
                    sqlConnection.Open();
                    resp.status = true;
                    return resp;
                }
                catch (SqlException ex)
                {
                    resp.status = false;
                    resp.errorMessage = ex.Errors.ToString();
                    return resp;
                }
                finally
                {
                    try
                    {
                        sqlConnection.Close();
                    }
                    catch (Exception ex) { }
                }
            }
        }
    }
}
