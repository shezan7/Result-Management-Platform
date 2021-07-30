using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;
using ResultSystem.Models;
using Microsoft.AspNetCore.Cors;


// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ResultSystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    //[EnableCors("CorsPolicy")]
    public class UserController : ControllerBase
    {

        private readonly UserContext _context;
        public UserController(UserContext context)
        {
            _context = context;
        }


        // GET: api/<UserController>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Result>>> GetResults()
        {
            //var x = await _context.Result.ToListAsync();

            //foreach (var property in x)
            //{
            // do something to modify 'item'
            // based on the value of 'property'
            // save to variable 'modifiedItem'

            //modifiedItems.Add(modifiedItem)
            //  property.

            //}
            return await _context.Result.ToListAsync();
        }


        // GET api/<UserController>/5
        [HttpGet("{roll}")]
        public async Task<ActionResult<User>> GetUser(int roll, [FromQuery] string password)
        {
            var user = await _context.Users.Where(x => x.Roll == roll).SingleOrDefaultAsync();
            //_context.Users.FindAsync(id);
            //                _context.Users.Where(x => x.Roll == roll).SingleOrDefaultAsync();

            if (user == null || user.Password != password)
            {
                return NotFound();
            }
            /*
            if (user.Password == password)
            {
                return user;
            }
            */
            Console.WriteLine(roll + " backend ");

            user.Result = CalculateResult(roll);

            _context.Entry(user).State = EntityState.Modified;
            await _context.SaveChangesAsync();

            return user;

        }



        // POST api/<UserController>
        [HttpPost]
        public async Task<ActionResult<Result>> AddUser(Result res)
        {
            res.CourseResult = CalculateCourseResult(res);
            _context.Result.Add(res);

            var user = await _context.Users.Where(x => x.Roll == res.Roll).SingleOrDefaultAsync();
            user.Result = CalculateResult(res.Roll);
            _context.Entry(user).State = EntityState.Modified;


            await _context.SaveChangesAsync();
            //return CreatedAtAction("GetPaymentDetail", new { id = paymentDetail.Id }, paymentDetail);
            return res;
        }





        // PUT api/<UserController>/5
        [HttpPut("{id}/{courseCode}")]
        public async Task<ActionResult<Result>> Update(int id, int courseCode, Result result)
        {
            Console.WriteLine(id + "iiiii" + result.Roll);
            //if (id != result.Roll)
            //{
            //  return BadRequest();

            //}

            result.CourseResult = CalculateCourseResult(result);
            var mod = await _context.Result.Where(x => x.Roll == result.Roll &&
            x.CourseCode == result.CourseCode).SingleOrDefaultAsync();

            _context.Result.Remove(mod);
            await _context.SaveChangesAsync();

            _context.Result.Add(result);

            //_context.Entry(result).State = EntityState.Modified;

            var user = await _context.Users.Where(x => x.Roll == result.Roll).SingleOrDefaultAsync();
            user.Result = CalculateResult(result.Roll);
            _context.Entry(user).State = EntityState.Modified;


            try
            {
                Console.WriteLine(id + "try" + result.Roll);
                await _context.SaveChangesAsync();
            }

            catch (DbUpdateConcurrencyException)
            {
                if (!UserExists(id))
                {
                    Console.WriteLine(id + "iiiiifff" + result.Roll);
                    return NotFound();
                }

                else
                {
                    Console.WriteLine(id + "iiiiielse" + result.Roll);
                    throw;
                }
            }
            Console.WriteLine(id + "iiiiiret" + result.Roll);
            return NoContent();
        }

        private bool UserExists(int id)
        {
            return _context.Result.Any(e => e.Id == id);
        }


        private static double CalculateCourseResult(Result res)
        {
            double total = res.Mid + res.Quiz + res.Lab + res.Final;

            if (total >= 80) return 4.0;
            else if (total >= 75) return 3.7;
            else if (total >= 70) return 3.5;
            else if (total >= 65) return 3.2;
            else if (total >= 60) return 3.0;
            else if (total >= 55) return 2.7;
            else if (total >= 50) return 2.5;
            else if (total >= 45) return 2.2;
            else if (total >= 40) return 2.0;

            return 0.0;
        }

        public double CalculateResult(int roll)
        {
            //return 3.4;


            var results = _context.Result.Where(x => x.Roll == roll);

            if (results == null) return 0.0; //reach kore na

            double[] a = { 0.0, 0.0, 0.0 }; //sem 3 ta couse 3ta
            int[] c = { 0, 0, 0 }; //0-3
            int counter = 0; //0-9 3*3 =9

            foreach (Result result in results)
            {
                a[result.Semester - 1] += result.CourseResult;
                c[result.Semester - 1] += 1;
                counter += 1;
            }
            if (counter == 0) return 0.0;

            int div = counter / 3; //0
            if (div * 3 != counter) div += 1;

            Console.WriteLine(div);
            Console.WriteLine(counter);

            double tempTotal = 0.0;
            if (c[0] != 0) tempTotal += a[0] / c[0];
            if (c[1] != 0) tempTotal += a[1] / c[1];
            if (c[2] != 0) tempTotal += a[2] / c[2];

            double reslt = tempTotal / div; //Nan

            Console.WriteLine(reslt);
            //(float)System.Math.Round(value, 2);
            return (double)System.Math.Round(reslt, 2);

        }


        //DELETE: api/User/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Result>> DeleteResult(int id)
        {
            var result = await _context.Result.FindAsync(id);
            if (result == null)
            {
                return NotFound();
            }

            _context.Result.Remove(result);
            await _context.SaveChangesAsync();

            return result;
        }


    }
}