using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Cors;
using MediaAPI.Models;

namespace MediaAPI.Controllers
{
  [Route("api/[controller]")]
  [Produces("application/json")]
  [EnableCors("AllowDevelopmentEnvironment")]
  public class MediaTypeController : Controller
  {
    private MediaDbContext _context;

    public MediaTypeController(MediaDbContext context)
    {
      _context = context;
    }

    // GET: api/mediatype
    [HttpGet]
    public IActionResult Get()
    {
      if (!ModelState.IsValid)
      {
        return BadRequest(ModelState);
      }

      IQueryable<object> mediaTypes = from mt in _context.MediaType
                                         select new
                                         {
                                           Name = mt.Name,
                                           ColorName = mt.ColorName,
                                           ColorLight = mt.ColorLight,
                                           ColorDark = mt.ColorDark
                                         };

      return Ok(mediaTypes);
    }
  }
}
