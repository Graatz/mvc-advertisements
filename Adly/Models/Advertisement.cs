using System;
using System.ComponentModel.DataAnnotations;

namespace Adly.Models
{
    public class Advertisement
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

        public Category Category { get; set; }

        public int? Views { get; set; }
    }
}