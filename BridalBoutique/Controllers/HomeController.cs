using BridalBoutique.DAL;
using System.Data.Entity;
using System.Web.Mvc;

namespace BridalBoutique.Controllers
{
    public class HomeController : Controller
    {
        private BridalBoutiqueContext db = new BridalBoutiqueContext();

        public ActionResult Index()
        {


            //OfferProductViewModel offer = new OfferProductViewModel();
            //offer.Offers = db.Offers.ToList();
            //offer.Products = db.Products.ToList();
           var offers = db.Offers.Include(o => o.Products);

            //var offer = db.Offers.SqlQuery("select Offers.name, Offers.NewPrice, OfferMonth, Products.name, Products.price, Products.ImagePath from Offers join Products on Offers.ProductId=Products.Id").ToList();

            return View(offers);
        }


        public ActionResult About()
        {
            ViewBag.Message = "Your about page.";
            //test
            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}