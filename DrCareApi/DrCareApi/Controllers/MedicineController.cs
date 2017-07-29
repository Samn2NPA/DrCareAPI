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
    [System.Web.Http.RoutePrefix("api/Medicine")]
    public class MedicineController : ApiController
    {
        DRCAREEntities DRCARE = new DRCAREEntities(); //f12 vào đây để coi kiểu trả về khi exec sproc

        [Route("GetAllMedicine")]
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
