﻿using System;
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

      IQueryable<MediaType> mediaTypes = from mt in _context.MediaType
                                        select mt;

      return Ok(mediaTypes);
    }

    // GET api/values/5
    [HttpGet("{id}")]
    public string Get(int id)
    {
      return "value";
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
