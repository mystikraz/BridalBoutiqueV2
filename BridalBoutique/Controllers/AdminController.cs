using System.Web.Mvc;

namespace BridalBoutique.Controllers
{
    public class AdminController : Controller
    {

        public ActionResult Index()
        {
            if (Session["User"] == null)
            {
                return RedirectToAction("Login","Users");
            }
            return View();
        }
        public ActionResult Users()
        {
            Session.Remove("User");
            return View();
        }
    }
}