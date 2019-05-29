using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace FinalProject322.Models
{
    public class Userr : IdentityUser
    {
        [Required]
        [StringLength(100)]
        public string Ad { get; set; }


        [Required]
        [StringLength(100)]
        public string Soyad { get; set; }

        public string Adres { get; set; }

        public string Telefon { get; set; }

        public int? CategoryId { get; set; }
        public virtual Category Category { get; set; }
    }
}
