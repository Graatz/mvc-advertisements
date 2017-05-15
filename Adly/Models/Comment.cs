using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Adly.Models
{
    public class Comment
    {
        public int Id { get; set; }
        
        [Required]
        [MaxLength(255)]
        [MinLength(1)]
        public string Content { get; set; }

        [Required]
        public DateTime Date { get; set; }

        [Required]
        public int AdvertisementId { get; set; }

        public Advertisement Advertisement { get; set; }
    }
}