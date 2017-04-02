using BridalBoutique.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BridalBoutique.ViewModels
{
    public class ShoppingCartViewModel
    {
        public List<Cart> CartItems { get; set; }
        public decimal CartTotal { get; set; }
    }
}