using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Cors;
using MediaAPI.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Http;

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

    // GET: api/appuser (all AppUsers)
    // GET: api/appuser?username=githubAlias (AppUser by username)
    [HttpGet]
    public IActionResult Get([FromQuery] string username)
    {
      if (!ModelState.IsValid)
      {
        return BadRequest(ModelState);
      }

      IQueryable<AppUser> appUsers = from au in _context.AppUser
                                     select au;

      if (username != null)
      {
        appUsers = appUsers.Where(au => au.Username == username);
      }

      if (appUsers == null)
      {
        return NotFound();
      }

      return Ok(appUsers);
    }

    // GET api/appuser/5 (specific appuser by id)
    [HttpGet("{id}", Name = "GetAppUser")]
    public IActionResult Get(int id)
    {
      if (!ModelState.IsValid)
      {
        return BadRequest(ModelState);
      }

      AppUser appUser = _context.AppUser.Single(au => au.IdAppUser == id);

      if (appUser == null)
      {
        return NotFound();
      }

      return Ok(appUser);
    }

    // POST api/appuser
    [HttpPost]
    public IActionResult Post([FromBody]AppUser newUser)
    {
      if (!ModelState.IsValid)
      {
        return BadRequest(ModelState);
      }

      var existingUser = from au in _context.AppUser
                         where au.Username == newUser.Username
                         select au;

      if (existingUser.Count<AppUser>() > 0)
      {
        return new StatusCodeResult(StatusCodes.Status409Conflict);
      }

      _context.AppUser.Add(newUser);
      try
      {
        _context.SaveChanges();
      }
      catch (DbUpdateException)
      {
        if (UserExists(newUser.IdAppUser))
        {
          return new StatusCodeResult(StatusCodes.Status409Conflict);
        }
        else
        {
          throw;
        }
      }
      return CreatedAtRoute("GetAppUser", new { id = newUser.IdAppUser }, newUser);

    }

    private bool UserExists(int id)
    {
      return _context.AppUser.Count(au => au.IdAppUser == id) > 0;
    }
  }
}
