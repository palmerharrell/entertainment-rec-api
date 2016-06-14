using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MediaAPI.Models
{
  public class MediaItem
  {
    [Key]
    public int IdMediaItem { get; set; }
    public int IdMediaType { get; set; }
    public int IdAppUser { get; set; }
    public string Name { get; set; }
    public string Recommender { get; set; }
    public string Notes { get; set; }
    public bool Finished { get; set; }
    public bool Favorite { get; set; }
    public int Rating { get; set; }
    public DateTime DateAdded { get; set; }

    // For Foreign Keys:
    public MediaType MediaType { get; set; }
    public AppUser AppUser { get; set; }
  }
}
