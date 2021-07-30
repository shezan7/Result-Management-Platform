using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ResultSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ResultSystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    //[EnableCors("CorsPolicy")]
    public class LoginController : ControllerBase
    {
        private readonly UserContext _context;


        public LoginController(UserContext context)
        {
            _context = context;
        }

        // GET api/<LoginController>/5
        [HttpGet("{roll}")]
        public async Task<ActionResult<User>> GetUser(int roll, [FromQuery] string password)
        {
            var user = await _context.Users.FirstOrDefaultAsync(x => x.Roll == roll);
            
            if (user == null || user.Password != password)
            {
                return NotFound();
            }
            
            Console.WriteLine(roll + " backend ");
            if( roll == 101010)
            {
                //redirect to admin page
            }

            else
            {
                //redirect to that user's dashboard
            }

            return user;

        }


        //_context.Users.FindAsync(id);
        //                _context.Users.Where(x => x.Roll == roll).SingleOrDefaultAsync();

        // GET: api/<LoginController>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // POST api/<LoginController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<LoginController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<LoginController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
