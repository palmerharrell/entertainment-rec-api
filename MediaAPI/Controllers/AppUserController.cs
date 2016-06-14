using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Cors;
using MediaAPI.Models;

namespace MediaAPI.Controllers
{
  [Route("api/[controller]")]
  [Produces("application/json")]
  [EnableCors("AllowDevelopmentEnvironment")]
  public class AppUserController : Controller
  {
    private MediaDbContext _context;

    public AppUserController(MediaDbContext context)
    {
      _context = context;
    }

    // GET: api/appuser
    [HttpGet]
    public IActionResult Get()
    {
      if (!ModelState.IsValid)
      {
        return BadRequest(ModelState);
      }

      IQueryable<AppUser> appUsers = from au in _context.AppUser
                                     select au;

      return Ok(appUsers);
    }



    // POST api/values
    [HttpPost]
    public void Post([FromBody]string value)
    {
    }

    // PUT api/values/5
    [HttpPut("{id}")]
    public void Put(int id, [FromBody]string value)
    {
    }

    // DELETE api/values/5
    [HttpDelete("{id}")]
    public void Delete(int id)
    {
    }
  }
}
