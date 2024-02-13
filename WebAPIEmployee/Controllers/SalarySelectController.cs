using Newtonsoft.Json;
using System;
using System.Web.Http;
using WebAPIEmployee.Models;

namespace WebAPIEmployee.Controllers
{
    [RoutePrefix("api")]
    public class SalarySelectController : ApiController
    {
        // GET: Department
        [HttpGet]
        [Route("selectFromSalary")]
        public IHttpActionResult GetEmployeeWithDepartmentId()
        {
            try
            {
                int deptId = 0;
                int year = 0;
                int month = 0;
                int empId = 0;
                int id = 0;

                string requestBody = Request.Content.ReadAsStringAsync().Result;

                if (!string.IsNullOrEmpty(requestBody))
                {
                    dynamic requestData = JsonConvert.DeserializeObject(requestBody);

                    deptId = requestData.deptId ?? 0;
                    year = requestData.year ?? 0;
                    year = requestData.year ?? 0;
                    month = requestData.month ?? 0;
                    month = requestData.month ?? 0;
                    empId = requestData.empId ?? 0;
                    empId = requestData.empId ?? 0;
                    id = requestData.id ?? 0;
                }

                practiceDatabaseEntities pdb = new practiceDatabaseEntities();
                var results = pdb.SP_SELECT_SALARY(deptId , year , month , empId , id);

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

