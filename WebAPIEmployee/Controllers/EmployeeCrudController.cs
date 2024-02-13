using Newtonsoft.Json;
using System;
using System.Data.Entity.Core.Objects;
using System.Web.Http;
using WebAPIEmployee.Models;

namespace WebAPIEmployee.Controllers
{
    [RoutePrefix("api")]
    public class EmployeeCrudController : ApiController
    {
        // POST: Create Employee
        [HttpPost]
        [Route("createEmployee")]
        public IHttpActionResult PostEmployeeData()
        {
            try
            {
                string requestBody = Request.Content.ReadAsStringAsync().Result;

                if (!string.IsNullOrEmpty(requestBody))
                {
                    dynamic requestData = JsonConvert.DeserializeObject(requestBody);

                    string firstName = requestData.firstName ?? "";
                    string lastName = requestData.lastName ?? "";
                    string email = requestData.email ?? "";
                    string phone = requestData.phone ?? "";
                    string empId = requestData.empId ?? "";
                    string gender = requestData.gender ?? "";
                    string address = requestData.address ?? "";
                    System.DateTime dateOfBirth = requestData.dateOfBirth ?? DateTime.MinValue;
                    System.DateTime dateOfJoining = requestData.dateOfJoining ?? DateTime.MinValue;
                    string photo = requestData.photo ?? "";
                    int deptId = requestData.deptId ?? 0;
                    ObjectParameter returnValue = new ObjectParameter("RETURN_VALUE", -1);
                    practiceDatabaseEntities pdb = new practiceDatabaseEntities();
                    var results = pdb.SP_EMPLOYEECRUD("INSERT", 0, firstName, lastName, empId, gender, address, phone, email, dateOfBirth, deptId, dateOfJoining, photo  , returnValue);
                    string message;
                    if (Convert.ToInt32(returnValue.Value) == 1)
                        message = "Employee already exists";
                    else if (Convert.ToInt32(returnValue.Value) == 2)
                        message = "Employee inserted successfully";
                    else if (Convert.ToInt32(returnValue.Value) == 4)
                        message = "Employee updated successfully";
                    else if (Convert.ToInt32(returnValue.Value) == 6)
                        message = "Employee deleted successfully";
                    else
                        message = "Unknown return value";

                    var response = new { Message = message, Results = results };

                    return Json(response);
                }
                else
                {
                    var response = new { Message = "To perform this task, you need to send appropriate parameters" };
                    return Json(response);
                }
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
        }

        // PUT: Update Employee
        [HttpPut]
        [Route("updateEmployee")]
        public IHttpActionResult PutEmployeeData()
        {
            try
            {
                string requestBody = Request.Content.ReadAsStringAsync().Result;

                if (!string.IsNullOrEmpty(requestBody))
                {
                    dynamic requestData = JsonConvert.DeserializeObject(requestBody);
                    int id = requestData.id ?? 0;
                    string firstName = requestData.firstName ?? "";
                    string lastName = requestData.lastName ?? "";
                    string email = requestData.email ?? "";
                    string phone = requestData.phone ?? "";
                    string empId = requestData.empId ?? "";
                    string gender = requestData.gender ?? "";
                    string address = requestData.address ?? "";
                    System.DateTime dateOfBirth = requestData.dateOfBirth ?? DateTime.MinValue;
                    System.DateTime dateOfJoining = requestData.dateOfJoining ?? DateTime.MinValue;
                    string photo = requestData.photo ?? "";
                    int deptId = requestData.deptId ?? 0;
                    ObjectParameter returnValue = new ObjectParameter("RETURN_VALUE", -1);
                    practiceDatabaseEntities pdb = new practiceDatabaseEntities();
                    var results = pdb.SP_EMPLOYEECRUD("UPDATE", id, firstName, lastName, empId, gender, address, phone, email, dateOfBirth, deptId, dateOfJoining, photo, returnValue);
                    string message;
                    if (Convert.ToInt32(returnValue.Value) == 1)
                        message = "Employee already exists";
                    else if (Convert.ToInt32(returnValue.Value) == 2)
                        message = "Employee inserted successfully";
                    else if (Convert.ToInt32(returnValue.Value) == 4)
                        message = "Employee updated successfully";
                    else if (Convert.ToInt32(returnValue.Value) == 6)
                        message = "Employee deleted successfully";
                    else
                        message = "Unknown return value";

                    var response = new { Message = message, Results = results };

                    return Json(response);
                }
                else
                {
                    var response = new { Message = "To perform this task, you need to send appropriate parameters" };
                    return Json(response);
                }
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
        }

        // DELETE: Delete Employee
        [HttpDelete]
        [Route("deleteEmployee")]
        public IHttpActionResult DeleteEmployeeData()
        {
            try
            {
                string requestBody = Request.Content.ReadAsStringAsync().Result;

                if (!string.IsNullOrEmpty(requestBody))
                {
                    dynamic requestData = JsonConvert.DeserializeObject(requestBody);
                    int id = requestData.id ?? 0;
                    string firstName = requestData.firstName ?? "";
                    string lastName = requestData.lastName ?? "";
                    string email = requestData.email ?? "";
                    string phone = requestData.phone ?? "";
                    string empId = requestData.empId ?? "";
                    string gender = requestData.gender ?? "";
                    string address = requestData.address ?? "";
                    System.DateTime dateOfBirth = requestData.dateOfBirth ?? DateTime.MinValue;
                    System.DateTime dateOfJoining = requestData.dateOfJoining ?? DateTime.MinValue;
                    string photo = requestData.photo ?? "";
                    int deptId = requestData.deptId ?? 0;
                    ObjectParameter returnValue = new ObjectParameter("RETURN_VALUE", -1);
                    practiceDatabaseEntities pdb = new practiceDatabaseEntities();
                    var results = pdb.SP_EMPLOYEECRUD("DELETE", id, firstName, lastName, empId, gender, address, phone, email, dateOfBirth, deptId, dateOfJoining, photo, returnValue);
                    
                    string message;
                    if (Convert.ToInt32(returnValue.Value) == 1 )
                        message = "Employee already exists";
                    else if (Convert.ToInt32(returnValue.Value) == 2)
                        message = "Employee inserted successfully";
                    else if (Convert.ToInt32(returnValue.Value) == 4)
                        message = "Employee updated successfully";
                    else if (Convert.ToInt32(returnValue.Value) == 6 )
                        message = "Employee deleted successfully";
                    else
                        message = "Unknown return value";

                    var response = new { Message = message, Results = returnValue };

                    return Json(response);
                }
                else
                {
                    var response = new { Message = "To perform this task, you need to send appropriate parameters" };
                    return Json(response);
                }
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
        }
    }
}
