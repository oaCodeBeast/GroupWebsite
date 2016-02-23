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
    public class MembersController : Controller
    {
        MembersRepository repo = new MembersRepository();

        // GET: Members
        public ActionResult Index()
        {
            return View(repo.GetAll());
        }

        // GET: Members/Details/5
        public ActionResult Details(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Member member = repo.FindByID(id);
            if (member == null)
            {
                return HttpNotFound();
            }
            return View(member);
        }

        // GET: Members/Create
        [Authorize(Roles = "Admin")]//Added to restrict use to Admin role only
        public ActionResult Create()
        {
            return View();
        }

        // POST: Members/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin")]//Added to restrict use to Admin role only
        public ActionResult Create([Bind(Include = "MemberID,Name,Title,Company,Photo,Bio,IsActive,Site")] Member member)
        {
            if (ModelState.IsValid)
            {
                member.MemberID = Guid.NewGuid();
                repo.Create(member);
                return RedirectToAction("Index");
            }

            return View(member);
        }

        // GET: Members/Edit/5
        [Authorize(Roles = "Admin")]//Added to restrict use to Admin role only
        public ActionResult Edit(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Member member = repo.FindByID(id);
            if (member == null)
            {
                return HttpNotFound();
            }
            return View(member);
        }

        // POST: Members/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin")]//Added to restrict use to Admin role only
        public ActionResult Edit([Bind(Include = "MemberID,Name,Title,Company,Photo,Bio,IsActive,Site")] Member member)
        {
            if (ModelState.IsValid)
            {
                repo.Update(member);
                return RedirectToAction("Index");
            }
            return View(member);
        }

        // GET: Members/Delete/5
        [Authorize(Roles = "Admin")]//Added to restrict use to Admin role only
        public ActionResult Delete(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Member member = repo.FindByID(id);
            if (member == null)
            {
                return HttpNotFound();
            }
            return View(member);
        }

        // POST: Members/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(Guid id)
        {
            Member member = repo.FindByID(id);
            repo.Delete(member);
            return RedirectToAction("Index");
        }

        
    }
}
