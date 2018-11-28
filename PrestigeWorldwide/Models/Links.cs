using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace PrestigeWorldwide.Models
{
    public class Links
    {
        [Key]
        public int LinkId { get; set; }
        public string LinkUrl { get; set; }
        public string Role { get; set; }

        public Links() { }
    }
}