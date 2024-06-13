using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using WebApi.Models;
namespace webapitask.Controllers
{
    public class patientController : ApiController
    {
        List<patient> patients = new List<patient>() { new patient() { Id = 3, name = "Rana Abdelbaqy" }, new patient() { Id = 4, name = "Alaa Ashraf" } };

        [HttpGet]
        public IHttpActionResult GetAllPatient()
        {
            return Ok(patients);
        }

        public IHttpActionResult GetPatient(int id)
        {
            var patient = patients.FirstOrDefault(x => x.Id == id);

            if (patient == null)
            {
                return BadRequest("Patient not found");
            }
            else
            {
                return Ok(patient);
            }
        }

        [HttpPost]
        public IHttpActionResult PostPatient([FromBody] patient patient)
        {
            if (ModelState.IsValid)
            {
                if (patients.Any(x => x.Id == patient.Id))
                {
                    return Conflict();
                }
                else
                {
                    patients.Add(patient);
                    return Ok(patient);
                }
            }
            else
            {
                return BadRequest();
            }
        }
    }
}
