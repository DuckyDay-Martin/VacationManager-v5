using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Net;
using VacationManager_v5.Data;
using VacationManager_v5.GlobalConstants;
using VacationManager_v5.Models;

namespace VacationManager_v5.Controllers
{
    public class RoleController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();


        [Authorize(Roles = GlobalConstants.RolesConstant.Roles.CEO)]
        public ActionResult Index()
        {
            var roles = db.Roles.Include(r => r.Users);
            return View(roles.ToList());
        }

        // GET: Roles/Create
        [Authorize(Roles = GlobalConstants.RolesConstant.Roles.CEO)]
        public ActionResult Create()
        {
            return View();
        }

        // POST: Roles/Create
        [HttpPost]
        [Authorize(Roles = GlobalConstants.RolesConstant.Roles.CEO)]
        public ActionResult Create([Bind(Include = "Name")] Role role)
        {
            if (ModelState.IsValid)
            {
                db.Roles.Add(role);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(role);
        }

        // GET: Roles/Edit/5
        //[Authorize(Roles = GlobalConstants.RolesConstant.Roles.CEO)]
        //public ActionResult Edit(int? id)
        //{
        //    if (id == null)
        //    {
        //        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        //    }
        //    Role role = db.Roles.Find(id);
        //    if (role == null)
        //    {
        //        return HttpNotFound();
        //    }
        //    return View(role);
        //}

        // POST: Roles/Edit/5
        [HttpPost]
        [Authorize(Roles = GlobalConstants.RolesConstant.Roles.CEO)]
        public ActionResult Edit([Bind(Include = "Id,Name")] Role role)
        {
            if (ModelState.IsValid)
            {
                db.Entry(role).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(role);
        }

        // GET: Roles/Delete/5
        //[Authorize(Roles = GlobalConstants.RolesConstant.Roles.CEO)]
        //public ActionResult Delete(int? id)
        //{
        //    if (id == null)
        //    {
        //        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        //    }
        //    Role role = db.Roles.Find(id);
        //    if (role == null)
        //    {
        //        return HttpNotFound();
        //    }
        //    return View(role);
        //}

        // POST: Roles/Delete/5
        [HttpPost, ActionName("Delete")]
        [Authorize(Roles = GlobalConstants.RolesConstant.Roles.CEO)]
        public ActionResult DeleteConfirmed(int id)
        {
            Role role = db.Roles.Find(id);
            db.Roles.Remove(role);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}



