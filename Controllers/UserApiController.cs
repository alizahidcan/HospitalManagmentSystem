using HospitalManagment.Data;
using HospitalManagment.Models;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace HospitalManagment.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserApiController : ControllerBase
    {
        private ApplicationDbContext _context;

        public UserApiController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/<UserApiController>
        [HttpGet]
        public List<users> GetAllUsers()
        {
            return _context.Users.ToList();
        }

        // GET api/<UserApiController>/5
        [HttpGet("{id}")]
        public ActionResult<users> GetUsersDetails(int id)
        {
            if(id == 0) { return BadRequest(); }
            var userDetail=_context.Users.FirstOrDefault(x=>x.Id==id);

            if(userDetail==null) { return NotFound(); }
            return userDetail;
        }

        // POST api/<UserApiController>
        [HttpPost]
        public ActionResult<users> AddUser([FromBody] users user)
        {
            if(!ModelState.IsValid) { return BadRequest(ModelState); }

            _context.Users.Add(user);
            _context.SaveChanges();

            return Ok(user);
        }

        // PUT api/<UserApiController>/5
        [HttpPut("{id}")]
        public ActionResult<users> UpdateUser(int id, [FromBody] users user)
        {
            if (user==null) { return BadRequest(user); }

            var userDetail=_context.Users.FirstOrDefault( x=>x.Id==id);

            if(userDetail==null) { return NotFound(); }

            userDetail.Name = user.Name;
            userDetail.age = user.age;
            userDetail.phone = user.phone;
            userDetail.role = user.role;
            _context.SaveChanges();

            return Ok(userDetail);
        }

        // DELETE api/<UserApiController>/5
        [HttpDelete("{id}")]
        public ActionResult<users> Delete(int id)
        {

            var userDetail=_context.Users.FirstOrDefault(x=>x.Id==id);
            if(userDetail==null)
            {
                return NotFound();
            }
            _context.Remove(userDetail);
            _context.SaveChanges();
            return NoContent();
        }
    }
}
