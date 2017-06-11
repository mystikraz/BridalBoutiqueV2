using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BridalBoutique.Models
{
    public class Offer
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Offer name is required")]
        public string Name { get; set; }
        public int ProductId { get; set; }
        public virtual Product Products { get; set; }

        public Decimal NewPrice { get; set; }
        [Column(TypeName = "datetime2")]
        public DateTime OfferMonth { get; set; }




    }
}