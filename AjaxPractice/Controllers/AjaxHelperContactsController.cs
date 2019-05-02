using AjaxPractice.Models;
using AjaxPractice.Models.Entity;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Mvc;

namespace AjaxPractice.Controllers
{

    public class AjaxHelperContactsController : Controller
    {
        private AjaxDbContext db = new AjaxDbContext();

        // GET: AjaxHelperContacts
        public ActionResult Index()
        {
            var data = db.Contacts.ToList();
            if (Request.IsAjaxRequest())
                return PartialView("~/Views/AjaxHelperContacts/Partial/_ContactPartial.cshtml", data);
            return View(data);
        }

        // GET: AjaxHelperContacts/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Contact contact = db.Contacts.Find(id);
            if (contact == null)
            {
                return HttpNotFound();
            }
            return View(contact);
        }

        // GET: AjaxHelperContacts/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: AjaxHelperContacts/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,FirstName,LastName,Organisation,Phone,Email")] Contact contact)
        {
            if (ModelState.IsValid)
            {
                db.Contacts.Add(contact);
                db.SaveChanges();

                return RedirectToAction("Index");
            }

            if (Request.IsAjaxRequest())
                return Json(new
                {
                    errors = true,
                    errorList = ModelState.GetErrors()
                }, JsonRequestBehavior.AllowGet);

            return View(contact);
        }

        // GET: AjaxHelperContacts/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Contact contact = db.Contacts.Find(id);
            if (contact == null)
            {
                return HttpNotFound();
            }
            return View(contact);
        }

        // POST: AjaxHelperContacts/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,FirstName,LastName,Organisation,Phone,Email")] Contact contact)
        {
            if (ModelState.IsValid)
            {
                db.Entry(contact).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(contact);
        }

        // GET: AjaxHelperContacts/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Contact contact = db.Contacts.Find(id);
            if (contact == null)
            {
                return HttpNotFound();
            }
            return View(contact);
        }

        // POST: AjaxHelperContacts/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Contact contact = db.Contacts.Find(id);
            db.Contacts.Remove(contact);
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
