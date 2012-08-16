using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MyFirstWebsite.Models;

namespace MyFirstWebsite.Controllers
{ 
    public class WorkEventController : Controller
    {
        private WorkEventDBContext db = new WorkEventDBContext();

        //
        // GET: /WorkEvent/

        public ViewResult Index()
        {
            return View(db.WorkEvents.ToList());
        }

        //
        // GET: /WorkEvent/Details/5

        public ViewResult Details(int id)
        {
            WorkEvent workevent = db.WorkEvents.Find(id);
            return View(workevent);
        }

        //
        // GET: /WorkEvent/Create

        public ActionResult Create()
        {
            WorkEvent workevent = new WorkEvent();
            workevent.UserName = "";
            if (Request.IsAuthenticated)
            {
                
                //if (user != null)
                //{
                    //workevent.UserID = User.Identity.
                    workevent.UserName = User.Identity.Name;
                //}
            }
           
            workevent.StartTime = DateTime.Now;
            workevent.EndTime = DateTime.Now;
            //ViewData.Model = WorkEvent;
            return View(workevent);
        } 

        //
        // POST: /WorkEvent/Create

        [HttpPost]
        public ActionResult Create(WorkEvent workevent)
        {
            workevent.StartTime = DateTime.Now;
            workevent.EndTime = DateTime.Now;
            if (ModelState.IsValid)
            {
                db.WorkEvents.Add(workevent);
                db.SaveChanges();
                return RedirectToAction("Index");  
            }

            return View(workevent);
        }
        
        //
        // GET: /WorkEvent/Edit/5
 
        public ActionResult Edit(int id)
        {
            WorkEvent workevent = db.WorkEvents.Find(id);
            return View(workevent);
        }

        //
        // POST: /WorkEvent/Edit/5

        [HttpPost]
        public ActionResult Edit(WorkEvent workevent)
        {
            if (ModelState.IsValid)
            {
                db.Entry(workevent).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(workevent);
        }

        //
        // GET: /WorkEvent/Delete/5
 
        public ActionResult Delete(int id)
        {
            WorkEvent workevent = db.WorkEvents.Find(id);
            return View(workevent);
        }

        //
        // POST: /WorkEvent/Delete/5

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {            
            WorkEvent workevent = db.WorkEvents.Find(id);
            db.WorkEvents.Remove(workevent);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}