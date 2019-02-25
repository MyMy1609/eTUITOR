using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using eTUTOR.Models;

namespace eTUTOR.Controllers
{
    public class UserController : Controller
    {
        eTUITOREntities model = new eTUITOREntities();
        [HttpGet]
        public ActionResult Register()
        {
            var user = new tutor();
            return View(user);
        }
        [HttpPost]
        public ActionResult RegisterTuTor(tutor tutor/*, string fullname, string username, string email, string password, string phone, string address, DateTime birthday, string specialized, string job, string experience, string certificate, int status*/)
        {
           
            model.tutors.Add(tutor);
            model.SaveChanges();
            //gan session
            return RedirectToAction("ConfirmEmail","User");
        }
        public ActionResult RegisterStudent(student student/*, string fullname, string username, string email, string password, string phone, string address, DateTime birthday, string specialized, string job, string experience, string certificate, int status*/)
        {
            
            model.students.Add(student);
            model.SaveChanges();
            return RedirectToAction("ConfirmEmail", "User");
        }
        public ActionResult RegisterParent(parent parent/*, string fullname, string username, string email, string password, string phone, string address, DateTime birthday, string specialized, string job, string experience, string certificate, int status*/)
        {

            model.parents.Add(parent);
            model.SaveChanges();
            return RedirectToAction("ConfirmEmail", "User");
        }
        public ActionResult Login()
        {
            return View();
        }
        public ActionResult ConfirmEmail()
        {
            
            return View();
        }
    }
}