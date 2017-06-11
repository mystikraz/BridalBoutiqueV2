using BridalBoutique.Models;
using System.Collections.Generic;

namespace BridalBoutique.ViewModels
{
    public class ShoppingCartViewModel
    {
        public List<Cart> CartItems { get; set; }
        public decimal CartTotal { get; set; }
        public List<Offer> OfferItems { get; set; }

    }
}