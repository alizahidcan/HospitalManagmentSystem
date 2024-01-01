using HospitalManagment.Data;
using HospitalManagment.Models;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace HospitalManagment.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AppointmentApiController : ControllerBase
    {
        // GET: api/<AppointmentApiController>
        private ApplicationDbContext _context;

        public AppointmentApiController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/<UserApiController>
        [HttpGet]
        public List<appointment> GetAllAppointment()
        {
            return _context.Appointments.ToList();
        }

        // GET api/<UserApiController>/5
        [HttpGet("{id}")]
        public ActionResult<appointment> GetAppointmentDetails(int id)
        {
            if (id == 0) { return BadRequest(); }
            var appoDetail = _context.Appointments.FirstOrDefault(x => x.id == id);

            if (appoDetail == null) { return NotFound(); }
            return appoDetail;
        }
      
        // PUT api/<UserApiController>/5
        [HttpPut("{id}")]
        public ActionResult<appointment> UpdateAppointment(int id, [FromBody] appointment appo)
        {
            if (appo == null) { return BadRequest(appo); }

            var appoDetail = _context.Appointments.FirstOrDefault(x => x.id == id);

            if (appoDetail == null) { return NotFound(); }

            appoDetail.userName = appo.userName;
            appoDetail.doctorId = appo.doctorId;
            appoDetail.departmentId = appo.departmentId;
            appoDetail.justDate = appo.justDate;
            appoDetail.time = appo.time;
            _context.SaveChanges();

            return Ok(appoDetail);
        }

        // DELETE api/<UserApiController>/5
        [HttpDelete("{id}")]
        public ActionResult<appointment> Delete(int id)
        {

            var appoDetail = _context.Appointments.FirstOrDefault(x => x.id == id);
            if (appoDetail == null)
            {
                return NotFound();
            }
            _context.Remove(appoDetail);
            _context.SaveChanges();
            return NoContent();
        }
    }
}
