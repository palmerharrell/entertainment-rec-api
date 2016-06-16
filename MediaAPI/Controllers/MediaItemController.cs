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
        return NotFound(new { message = "No userId submitted" });
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
                                        DateAdded = mi.DateAdded,
                                        Type = (from mt in _context.MediaType
                                                where mt.IdMediaType == mi.IdMediaType
                                                select mt.Name).Single()
                                      };

      if (mediaItems.Count() == 0)
      {
        return NotFound(new { message = "User has not created any items or user does not exist" });
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

    // DELETE api/mediaitem?itemid=6&userid=1
    [HttpDelete]
    public IActionResult Delete([FromQuery]int? userId, [FromQuery]int? itemId)
    {
      if (!ModelState.IsValid)
      {
        return BadRequest(ModelState);
      }

      if (userId == null)
      {
        return NotFound();
      }

      MediaItem mediaItem = _context.MediaItem.FirstOrDefault(mi => mi.IdMediaItem == itemId);

      if (mediaItem == null)
      {
        return NotFound();
      }

      if (mediaItem.IdAppUser != userId)
      {
        return NotFound(new { message = "User does not have permission to delete this item" });
      }

      _context.MediaItem.Remove(mediaItem);
      _context.SaveChanges();

      return Ok(mediaItem);
    }
  }
}
