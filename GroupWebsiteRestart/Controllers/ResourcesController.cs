using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using GroupWebsiteRestart;
using GroupWebsiteRestart.Repository;

namespace GroupWebsiteRestart.Controllers
{
    public class ResourcesController : Controller
    {
        ResourcesRepository repo = new ResourcesRepository();

        // GET: Resources
        public ActionResult Index()
        {
            return View(repo.GetAll());
        }

        // GET: Resources/Details/5
        public ActionResult Details(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Resource resource = repo.FindByID(id);
            if (resource == null)
            {
                return HttpNotFound();
            }
            return View(resource);
        }

        // GET: Resources/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Resources/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ResourcesID,Name,URL,IsActive")] Resource resource)
        {
            if (ModelState.IsValid)
            {
                resource.ResourcesID = Guid.NewGuid();
                repo.Create(resource);
                return RedirectToAction("Index");
            }

            return View(resource);
        }

        // GET: Resources/Edit/5
        public ActionResult Edit(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Resource resource = repo.FindByID(id);
            if (resource == null)
            {
                return HttpNotFound();
            }
            return View(resource);
        }

        // POST: Resources/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ResourcesID,Name,URL,IsActive")] Resource resource)
        {
            if (ModelState.IsValid)
            {
                repo.Update(resource);
                return RedirectToAction("Index");
            }
            return View(resource);
        }

        // GET: Resources/Delete/5
        public ActionResult Delete(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Resource resource = repo.FindByID(id);
            if (resource == null)
            {
                return HttpNotFound();
            }
            return View(resource);
        }

        // POST: Resources/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(Guid id)
        {
            Resource resource = repo.FindByID(id);
            repo.Delete(resource);
            return RedirectToAction("Index");
        }

    }
}
