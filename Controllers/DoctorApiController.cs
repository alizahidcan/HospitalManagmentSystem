using HospitalManagment.Data;
using HospitalManagment.Models;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace HospitalManagment.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DoctorApiController : ControllerBase
    {
        // GET: api/<DoctorApiController>
        private ApplicationDbContext _context;

        public DoctorApiController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/<DoctorApiController>
        [HttpGet]
        public List<doctors> GetAllDoctors()
        {
            return _context.Doctors.ToList();
        }

        // GET api/<DoctorApiController>/5
        [HttpGet("{id}")]
        public ActionResult<doctors> GetDoctorsDetails(int id)
        {
            if (id == 0) { return BadRequest(); }
            var doctorDetail = _context.Doctors.FirstOrDefault(x => x.id == id);

            if (doctorDetail == null) { return NotFound(); }
            return doctorDetail;
        }

        // POST api/<DoctorApiController>
        [HttpPost]
        public ActionResult<doctors> AddDoctor([FromBody] doctors doctor)
        {
            if (!ModelState.IsValid) { return BadRequest(ModelState); }

            _context.Doctors.Add(doctor);
            _context.SaveChanges();

            return Ok(doctor);
        }

        // PUT api/<UserApiController>/5
        [HttpPut("{id}")]
        public ActionResult<doctors> UpdateDoctor(int id, [FromBody] doctors doctor)
        {
            if (doctor == null) { return BadRequest(doctor); }

            var doctorDetail = _context.Doctors.FirstOrDefault(x => x.id == id);

            if (doctorDetail == null) { return NotFound(); }

            doctorDetail.name = doctor.name;
            doctorDetail.age = doctor.age;
            doctorDetail.departmentId = doctor.departmentId;
            doctorDetail.Description = doctor.Description;
            doctorDetail.Image=doctor.Image;
            doctorDetail.workingHours = doctor.workingHours;
            doctorDetail.holidayDay = doctor.holidayDay;
            _context.SaveChanges();

            return Ok(doctorDetail);
        }

        // DELETE api/<UserApiController>/5
        [HttpDelete("{id}")]
        public ActionResult<doctors> Delete(int id)
        {

            var doctorDetail = _context.Doctors.FirstOrDefault(x => x.id == id);
            if (doctorDetail == null)
            {
                return NotFound();
            }
            _context.Remove(doctorDetail);
            _context.SaveChanges();
            return NoContent();
        }
    }
}
