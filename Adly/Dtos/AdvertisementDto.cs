using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Adly.Dtos
{
    public class AdvertisementDto
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(255)]
        public string Name { get; set; }

        [Required]
        public string Description { get; set; }

        public string Image { get; set; }

        public DateTime Date { get; set; }

        [Required]
        public int CategoryId { get; set; }

        public int? Views { get; set; }
    }
}