﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MediaAPI.Models
{
  public class MediaType
  {
    [Key]
    public int IdMediaType { get; set; }
    public string Name { get; set; }
    public string ColorName { get; set; }
    public string ColorLight { get; set; }
    public string ColorDark { get; set; }

    // For Foreign Keys:
    public ICollection<MediaItem> MediaItems { get; set; }
  }
}
