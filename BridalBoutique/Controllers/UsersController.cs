using BridalBoutique.DAL;
using BridalBoutique.Models;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Mvc;

namespace BridalBoutique.Controllers
{
    public class UsersController : Controller
    {
        private BridalBoutiqueContext db = new BridalBoutiqueContext();

        // GET: Users
        public ActionResult Index()
        {
            if (Session["user"] != null)
            {
                RedirectToAction("Login","Users");
            }
            return View(db.Users.ToList());
        }

        // GET: Users/Details/5
        public ActionResult Details(int? id)
        {
            if (Session["user"] != null)
            {
                RedirectToAction("Login", "Users");
            }
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            User user = db.Users.Find(id);
            if (user == null)
            {
                return HttpNotFound();
            }
            return View(user);
        }

        // GET: Users/Create
        public ActionResult Create()
        {
            if (Session["user"] != null)
            {
                RedirectToAction("Login", "Users");
            }
            return View();
        }

        // POST: Users/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,UserName,Email,Password,ConfirmPassword")] User user)
        {
            if (Session["user"] != null)
            {
                RedirectToAction("Login", "Users");
            }
            // var pass= Security.HashSHA1(user.Password);
            if (ModelState.IsValid)
            {
                var chkUser = (from s in db.Users where s.UserName == user.UserName || s.Email == user.Email select s).FirstOrDefault();
                if (chkUser == null)
                {
                    Session["user"] = user.UserName;
                    db.Users.Add(user);
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }

                
            }
            ViewBag.ErrorMessage = "User Allredy Exixts!!!!!!!!!!";

            return View(user);
        }
        public ActionResult Login()
        {
            if (Session["user"] != null)
            {
                RedirectToAction("Login", "Users");
            }
            return View();
        }
        [HttpPost]
        public ActionResult Login(User user)
        {
            if (Session["user"] != null)
            {
                RedirectToAction("Login", "Users");
            }

            var chkUser = (from s in db.Users where s.UserName == user.UserName || s.Password == user.Password select s).FirstOrDefault();
            if (chkUser == null)
            {
                //return Redirect(returnUrl ?? Url.Action("Index", "Admin"));
                ViewBag.ErrorMessage = "Username or Password Incorrect";

                return RedirectToAction("Index");

            }
            else
            {
                Session["User"] = user.UserName;
                return Redirect(Url.Action("Index", "Admin"));
            }
        }
        public ActionResult Logout()
        {
            Session.Remove("User");
            return RedirectToAction("Index", "Admin");
        }

        // GET: Users/Edit/5
        public ActionResult Edit(int? id)
        {
            if (Session["user"] != null)
            {
                RedirectToAction("Login", "Users");
            }
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            User user = db.Users.Find(id);
            if (user == null)
            {
                return HttpNotFound();
            }
            return View(user);
        }

        // POST: Users/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,UserName,Email,Password,ConfirmPassword")] User user)
        {
            if (ModelState.IsValid)
            {
                db.Entry(user).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(user);
        }

        // GET: Users/Delete/5
        public ActionResult Delete(int? id)
        {
            if (Session["user"] != null)
            {
                RedirectToAction("Login", "Users");
            }
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            User user = db.Users.Find(id);
            if (user == null)
            {
                return HttpNotFound();
            }
            return View(user);
        }

        // POST: Users/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            if (Session["user"] != null)
            {
                RedirectToAction("Login", "Users");
            }
            User user = db.Users.Find(id);
            db.Users.Remove(user);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
