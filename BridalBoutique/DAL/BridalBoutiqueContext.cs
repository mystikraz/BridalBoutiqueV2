using BridalBoutique.Models;
using System.Data.Entity;

namespace BridalBoutique.DAL
{
    public class BridalBoutiqueContext : DbContext

    {
        public BridalBoutiqueContext() : base("BridalBoutique")
        {

        }

        public DbSet<Category> Categories { get; set; }

        public DbSet<Customer> Customers { get; set; }

        public DbSet<Product> Products { get; set; }

        public DbSet<CustomerOrder> CustomerOrders { get; set; }

        public DbSet<OrderedProduct> Orderedproducts { get; set; }

        public DbSet<Cart> Carts { get; set; }
        public DbSet<Offer> Offers { get; set; }
        public DbSet<User> Users { get; set; }

    }
}