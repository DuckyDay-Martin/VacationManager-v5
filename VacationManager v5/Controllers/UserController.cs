using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System.Net;

using VacationManager_v5.Data;
using VacationManager_v5.GlobalConstants;
using VacationManager_v5.Models;

namespace VacationManager_v5.Controllers
{
    public class UserController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();


        //GET:User
        public IActionResult Index(string searchString)
        {
            var users = from u in db.Users
                        select u;
            if (!String.IsNullOrEmpty(searchString))
            {
                users = users.Where(u => u.UserName.Contains(searchString)
                                                            || u.UserName.Contains(searchString)
                                                            || u.FirstName.Contains(searchString)
                                                            || u.LastName.Contains(searchString)
                                                            || u.Role.Contains(searchString)
                                                            || u.Team.Contains(searchString));
            }
            return View(users.ToList());
        }

        // GET: User/Create/

        [Authorize(Roles = GlobalConstants.RolesConstant.Roles.CEO)]
        public async Task<IActionResult> CreateUser()
        {

            ViewBag.TeamId = new SelectList(db.Teams, "Id", "Name");
            return View();
        }

        // POST: User/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = GlobalConstants.RolesConstant.Roles.CEO)]
        public ActionResult Create([Bind(Include = "UserName,Password,FirstName,LastName,Role,TeamId")] Users user)
        {
            if (ModelState.IsValid)
            {
                db.Users.Add(user);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.TeamId = new SelectList(db.Team, "UserID", "Name", user.TeamId);
            return View(user);
        }

        [Authorize(Roles = GlobalConstants.RolesConstant.Roles.CEO)]
        public ActionResult Edit(int? id)
        {
            Users user = db.Users.Find(id);

            ViewBag.TeamId = new SelectList(db.Team, "UserID", "Name", user.TeamId);

            return View(user);
        }

        // POST: User/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = GlobalConstants.RolesConstant.Roles.CEO)]
        public ActionResult Edit([Bind(Include = "UserID,UserName,Password,FirstName,LastName,Role,TeamId")] Users user)
        {
            if (ModelState.IsValid)
            {
                db.Entry(user).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.TeamId = new SelectList(db.Teams, "Id", "Name", user.TeamId);
            return View(user);
        }

        // GET: User/Delete/5
        [Authorize(Roles = GlobalConstants.RolesConstant.Roles.CEO)]
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Users user = db.Users.Find(id);
            
           
        }

        public ActionResult DeleteConfirmed(int id)
        {
            Users user = db.Users.Find(id);
            db.Users.Remove(user);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

    }
}
