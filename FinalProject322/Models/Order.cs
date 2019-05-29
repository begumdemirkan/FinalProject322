using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace FinalProject322.Models
{
    public class Order
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string UserId { get; set; }

        [ForeignKey("UserId")]
        public virtual Userr Userr {get; set;}

        [Required]
        public DateTime OrderDate { get; set; }

        [Required]
        public double total { get; set; }

        [Required]
        public double totaloriginal { get; set; }


        [Required]
        public DateTime pickuptime { get; set; }

        public DateTime pickuptimegün { get; set; }


        public string CouponCode { get; set; }

        public double CouponDiscoun { get; set; }

        public string PickUpName { get; set; }

        public string tel { get; set; }

        public string transactionId { get; set; }


    }
}
