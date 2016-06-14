using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MediaAPI.Models
{
  public class AppUser
  {
    [Key]
    public int IdAppUser { get; set; }
    public string Username { get; set; }
    public string Email { get; set; }

    // For Foreign Keys:
    public ICollection<MediaItem> MediaItems { get; set; }
  }
}
