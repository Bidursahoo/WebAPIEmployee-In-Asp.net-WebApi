using Newtonsoft.Json;
using System;
using System.Web.Http;
using WebAPIEmployee.Models;

namespace WebAPIEmployee.Controllers
{
    [RoutePrefix("api")]
    public class DepartmentController : ApiController
    {
        // GET: Department
        [HttpGet]
        [Route("departmentsValue")]
        public IHttpActionResult GetDepartments()
        {
            try
            {
                practiceDatabaseEntities pdb = new practiceDatabaseEntities();
                var results = pdb.SP_DEPARTMENT_OPERATION();

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

