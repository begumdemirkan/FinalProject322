using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace FinalProject322.Models
{
    public class Userr: IdentityUser
    {
        [Required]
        [StringLength(100)]
        public string FirstName { get; set; }


        [Required]
        [StringLength(100)]
        public string LastName { get; set; }
    }
}
