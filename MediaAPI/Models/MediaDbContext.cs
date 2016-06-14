using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MediaAPI.Models
{
  public class MediaDbContext : DbContext
  {
    public MediaDbContext(DbContextOptions<MediaDbContext> options)
      : base(options)
    { }

    public DbSet<MediaItem> MediaItem { get; set; }
    public DbSet<MediaType> MediaType { get; set; }
    public DbSet<AppUser> AppUser { get; set; }
  }
}
