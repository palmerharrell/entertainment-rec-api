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
  public class MediaItemController : Controller
  {
    private MediaDbContext _context;

    public MediaItemController(MediaDbContext context)
    {
      _context = context;
    }

    // GET: api/mediaitem?userid=2
    [HttpGet]
    public IActionResult Get([FromQuery]int? userId)
    {
      if (!ModelState.IsValid)
      {
        return BadRequest(ModelState);
      }

      if (userId == null)
      {
        return NotFound();
      }

      IQueryable<object> mediaItems = from mi in _context.MediaItem
                                      where mi.IdAppUser == userId
                                      select new
                                      {
                                        IdMediaItem = mi.IdMediaItem,
                                        IdMediaType = mi.IdMediaType,
                                        Name = mi.Name,
                                        Recommender = mi.Recommender,
                                        Notes = mi.Notes,
                                        Finished = mi.Finished,
                                        Favorite = mi.Favorite,
                                        Rating = mi.Rating,
                                        DateAdded = mi.DateAdded
                                      };

      if (mediaItems.Count() == 0)
      {
        return NotFound();
      }

      return Ok(mediaItems);
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
