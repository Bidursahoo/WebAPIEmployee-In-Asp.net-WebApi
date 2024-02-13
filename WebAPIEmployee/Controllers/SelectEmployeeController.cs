using Newtonsoft.Json;
using System;
using System.Web.Http;
using WebAPIEmployee.Models;

namespace WebAPIEmployee.Controllers
{
    [RoutePrefix("api")]
    public class SelectEmployeeController : ApiController
    {
        [HttpGet]
        [Route("selectEmployee")]
        public IHttpActionResult GetEmployeeRecords()
        {
            try
            {
                int deptId = 0;
                int empId = 0;
                string year = "0";

                string requestBody = Request.Content.ReadAsStringAsync().Result;

                if (!string.IsNullOrEmpty(requestBody))
                {
                    dynamic requestData = JsonConvert.DeserializeObject(requestBody);

                    deptId = requestData.deptId ?? 0;
                    empId = requestData.empId ?? 0;
                    year = requestData.year ?? "0";
                }

                practiceDatabaseEntities pdb = new practiceDatabaseEntities();
                var results = pdb.SP_SELECT_EMPLOYEE(deptId, year, empId, "");

                var response = new { Message = "Success", Results = results };

                return Json(response);
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
        }
    }
}
