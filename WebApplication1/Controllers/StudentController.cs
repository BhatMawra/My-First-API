using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebApplication1.Controllers
{
    
    [Route("api/[controller]")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        private static List<Student> students = new List<Student>();
        

        // GET: api/<UserController>
        [HttpGet]
        public IEnumerable<Student> Get()
        {
            return students;
        }

        // GET api/<UserController>/5
        [HttpGet("{id}")]
        public Student Get(int id)
        {
            var student = students.FirstOrDefault(x => x.Id == id);
            return student;
        }

        // POST api/<UserController>
        [HttpPost]
        public void Post([FromBody] Student request)
        {
            students.Add(request);
        }

        // PUT api/<UserController>/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] Student request)
        {
            var student = students.FirstOrDefault(x => x.Id == id);
            if (student == null)
            {
                return NotFound();           
            }
            else
            {
                student.Id = id;
                student.Name = request.Name;
                student.Address = request.Address;
                student.Email = request.Email;
                student.PhoneNumber = request.PhoneNumber;
                return Ok(student);
            }

        }

        // DELETE api/<UserController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            var student = students.FirstOrDefault(x => x.Id == id);
            students.Remove(student);
        }
    }
}
