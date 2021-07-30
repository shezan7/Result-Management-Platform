using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
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
    public class SignupController : ControllerBase
    {
        private readonly UserContext _context;

        public SignupController(UserContext context)
        {
            _context = context;
        }

        [HttpPost]
        public async Task<ActionResult<User>> SignupUser([FromBody] User user)
        {
            Console.WriteLine(" signup controller called  ");
            user.Result = 0.0;
            _context.Users.Add(user);
            await _context.SaveChangesAsync();
            //return CreatedAtAction("GetPaymentDetail", new { id = paymentDetail.Id }, paymentDetail);
            return user;
        } 
     




        /*
        // GET: api/<SignupController>
        
        
        
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<SignupController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<SignupController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<SignupController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<SignupController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }

        */
    }
}
