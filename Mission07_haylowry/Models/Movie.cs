using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Mission07_haylowry.Models
{
    public class Movie
    {
        [Key]
        [Required]
        public int MovieId { get; set; }
        public string Title { get; set; }
        public int Year { get; set; }
        public string Director { get; set; }
        public string Rating { get; set; }

        public int CategoryID { get; set; }
        public Category Category { get; set; }

    }
}
