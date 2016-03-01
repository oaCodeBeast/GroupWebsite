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
    public class BlogPostsController : Controller
    {
        private BlogPostRepository repo = new BlogPostRepository();

        // GET: BlogPosts
        public ActionResult Index()
        {
            return View(repo.GetAll());
        }

        // GET: BlogPosts/Details/5
        public ActionResult Details(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BlogPost blogPost = repo.FindByID(id);
            if (blogPost == null)
            {
                return HttpNotFound();
            }
            return View(blogPost);
        }

        // GET: BlogPosts/Create
        [Authorize(Roles = "Admin")]//Added to restrict use to Admin role only
        public ActionResult Create()
        {
            return View();
        }

        // POST: BlogPosts/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin")]//Added to restrict use to Admin role only
        public ActionResult Create([Bind(Include = "BlogID,Title,Body,Picture,HasPicture,Date")] BlogPost blogPost)
        {
            if (ModelState.IsValid)
            {
                blogPost.BlogID = Guid.NewGuid();
                repo.Create(blogPost);
               
                return RedirectToAction("Index");
            }

            return View(blogPost);
        }

        // GET: BlogPosts/Edit/5
        [Authorize(Roles = "Admin")]//Added to restrict use to Admin role only
        public ActionResult Edit(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BlogPost blogPost = repo.FindByID(id);
            if (blogPost == null)
            {
                return HttpNotFound();
            }
            return View(blogPost);
        }

        // POST: BlogPosts/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin")]//Added to restrict use to Admin role only
        public ActionResult Edit([Bind(Include = "BlogID,Title,Body,Picture,HasPicture,Date")] BlogPost blogPost)
        {
            if (ModelState.IsValid)
            {
                repo.Update(blogPost);
                return RedirectToAction("Index");
            }
            return View(blogPost);
        }

        // GET: BlogPosts/Delete/5
        [Authorize(Roles = "Admin")]//Added to restrict use to Admin role only
        public ActionResult Delete(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BlogPost blogPost = repo.FindByID(id);
            if (blogPost == null)
            {
                return HttpNotFound();
            }
            return View(blogPost);
        }

        // POST: BlogPosts/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(Guid id)
        {
            BlogPost blogPost = repo.FindByID(id);
            repo.Delete(blogPost);
          
            return RedirectToAction("Index");
        }

   
    }
}
