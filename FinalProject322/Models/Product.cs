using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace FinalProject322.Models
{
    public class Product
    {
        public int Id { get; set; }

        [Required]
        [Display(Name = "Oyuncak Adı")]
        public string Name { get; set; }

        
        [Display(Name = "Açıklama")]
        public string Description { get; set; }

        [Required]
        [Display(Name= "Adet")]
        public int Quantity { get; set; }

        [Display(Name = "Ürün Resmi")]
        public string Image { get; set; }

        [Display(Name = "Kategori")]
        public int CategoryId { get; set; }

        [ForeignKey("CategoryId")]
        public virtual Category Category { get; set; }

        [Range(1,int.MaxValue,ErrorMessage ="Fiyat 1tl'den az olamaz")]
        [Display(Name = "Fiyat")]
        public double Price { get; set; }

    }
}
