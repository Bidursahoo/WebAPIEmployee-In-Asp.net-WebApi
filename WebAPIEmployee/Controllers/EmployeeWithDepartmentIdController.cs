using Newtonsoft.Json;
using System;
using System.Web.Http;
using WebAPIEmployee.Models;

namespace WebAPIEmployee.Controllers
{
    [RoutePrefix("api")]
    public class EmployeeWithDepartmentIdController : ApiController
    {
        // GET: Department
        [HttpGet]
        [Route("fetchUsingDepartmentId")]
        public IHttpActionResult GetEmployeeWithDepartmentId()
        {
            try
            {
                int deptId = 0;

                string requestBody = Request.Content.ReadAsStringAsync().Result;

                if (!string.IsNullOrEmpty(requestBody))
                {
                    dynamic requestData = JsonConvert.DeserializeObject(requestBody);

                    deptId = requestData.deptId ?? 0;
                }

                practiceDatabaseEntities pdb = new practiceDatabaseEntities();
                var results = pdb.SP_SELECT_EMPLOYEE_WITH_DEPARTMENT(deptId);

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

