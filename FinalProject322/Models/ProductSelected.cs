using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace FinalProject322.Models
{
    public class ProductSelected
    {
        public ProductSelected()
        {
            Count = 1;
        }
        public int UserId { get; set; }

        public int Id { get; set; }

        [NotMapped]
        [ForeignKey("UserId")]
        public virtual Userr Userr { get; set; }

        public int ProductId { get; set; }
        [NotMapped]
        [ForeignKey("ProductId")]
        public virtual Product Product { get; set; }


        [Range(1, int.MaxValue, ErrorMessage = "Lütfen 1'e eşit veya 1'den daha büyük bir değer girin")]
        public int Count { get; set; }
    }
}
