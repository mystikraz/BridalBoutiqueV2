using BridalBoutique.DAL;
using BridalBoutique.Models;
using System.Data.Entity;
using System.Net;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace BridalBoutique.Controllers
{
    public class OrderedProductsController : Controller
    {
        private BridalBoutiqueContext db = new BridalBoutiqueContext();

        // GET: OrderedProducts
        public async Task<ActionResult> Index()
        {
            if (Session["User"] == null)
            {
                return RedirectToAction("Login", "Users");
            }
            var orderedproducts = db.Orderedproducts.Include(o => o.CustomerOrder).Include(o => o.Product);
            return View(await orderedproducts.ToListAsync());
        }

        // GET: OrderedProducts/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (Session["User"] == null)
            {
                return RedirectToAction("Login", "Users");
            }
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            OrderedProduct orderedProduct = await db.Orderedproducts.FindAsync(id);
            if (orderedProduct == null)
            {
                return HttpNotFound();
            }
            return View(orderedProduct);
        }

        // GET: OrderedProducts/Create
        public ActionResult Create()
        {
            ViewBag.CustomerOrderId = new SelectList(db.CustomerOrders, "Id", "FirstName");
            ViewBag.ProductId = new SelectList(db.Products, "Id", "Name");
            return View();
        }

        // POST: OrderedProducts/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "ProductId,CustomerOrderId,Quantity")] OrderedProduct orderedProduct)
        {
            if (ModelState.IsValid)
            {
                db.Orderedproducts.Add(orderedProduct);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            ViewBag.CustomerOrderId = new SelectList(db.CustomerOrders, "Id", "FirstName", orderedProduct.CustomerOrderId);
            ViewBag.ProductId = new SelectList(db.Products, "Id", "Name", orderedProduct.ProductId);
            return View(orderedProduct);
        }

        // GET: OrderedProducts/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            OrderedProduct orderedProduct = await db.Orderedproducts.FindAsync(id);
            if (orderedProduct == null)
            {
                return HttpNotFound();
            }
            ViewBag.CustomerOrderId = new SelectList(db.CustomerOrders, "Id", "FirstName", orderedProduct.CustomerOrderId);
            ViewBag.ProductId = new SelectList(db.Products, "Id", "Name", orderedProduct.ProductId);
            return View(orderedProduct);
        }

        // POST: OrderedProducts/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "ProductId,CustomerOrderId,Quantity")] OrderedProduct orderedProduct)
        {
            if (ModelState.IsValid)
            {
                db.Entry(orderedProduct).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewBag.CustomerOrderId = new SelectList(db.CustomerOrders, "Id", "FirstName", orderedProduct.CustomerOrderId);
            ViewBag.ProductId = new SelectList(db.Products, "Id", "Name", orderedProduct.ProductId);
            return View(orderedProduct);
        }

        // GET: OrderedProducts/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            OrderedProduct orderedProduct = await db.Orderedproducts.FindAsync(id);
            if (orderedProduct == null)
            {
                return HttpNotFound();
            }
            return View(orderedProduct);
        }

        // POST: OrderedProducts/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            OrderedProduct orderedProduct = await db.Orderedproducts.FindAsync(id);
            db.Orderedproducts.Remove(orderedProduct);
            await db.SaveChangesAsync();
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
