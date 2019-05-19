using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace FinalProject322.Models
{
    public class Kupon
    {   [Key]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public double Indirim { get; set; }

        [Required]
        public double Minmiktar { get; set; }

        public bool IsActive { get; set; }



    }
}
