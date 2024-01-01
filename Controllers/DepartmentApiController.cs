using HospitalManagment.Data;
using HospitalManagment.Models;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace HospitalManagment.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DepartmentApiController : ControllerBase
    {
        // GET: api/<DepartmentApiController>
        private ApplicationDbContext _context;

        public DepartmentApiController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/<UserApiController>
        [HttpGet]
        public List<department> GetAllDepartment()
        {
            return _context.Departments.ToList();
        }

        // GET api/<UserApiController>/5
        [HttpGet("{id}")]
        public ActionResult<department> GetDepartmentsDetails(int id)
        {
            if (id == 0) { return BadRequest(); }
            var departmentDetail = _context.Departments.FirstOrDefault(x => x.Id == id);

            if (departmentDetail == null) { return NotFound(); }
            return departmentDetail;
        }

        // POST api/<UserApiController>
        [HttpPost]
        public ActionResult<department> AddDepartment([FromBody] department depart)
        {
            if (!ModelState.IsValid) { return BadRequest(ModelState); }

            _context.Departments.Add(depart);
            _context.SaveChanges();

            return Ok(depart);
        }

        // PUT api/<UserApiController>/5
        [HttpPut("{id}")]
        public ActionResult<department> UpdateDepartment(int id, [FromBody] department depart)
        {
            if (depart == null) { return BadRequest(depart); }

            var departDetail = _context.Departments.FirstOrDefault(x => x.Id == id);

            if (departDetail == null) { return NotFound(); }

            departDetail.Name = depart.Name;
            departDetail.role = depart.role;
            departDetail.Description = depart.Description;
            departDetail.Image = depart.Image;
            _context.SaveChanges();

            return Ok(departDetail);
        }

        // DELETE api/<UserApiController>/5
        [HttpDelete("{id}")]
        public ActionResult<department> Delete(int id)
        {

            var departDetail = _context.Departments.FirstOrDefault(x => x.Id == id);
            if (departDetail == null)
            {
                return NotFound();
            }
            _context.Remove(departDetail);
            _context.SaveChanges();
            return NoContent();
        }
    }
}
