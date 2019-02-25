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
        eTUITOREntities m = new eTUITOREntities();
        public ActionResult Register()
        {
            return View();
        }

        public ActionResult Login()
        {

            return View();
        }

        [HttpPost]
        public ActionResult Login(string email, string password)
        {
            var tutor = m.tutors.FirstOrDefault(x => x.email == email);
            var student = m.students.FirstOrDefault(x => x.username == email);
            var parent = m.parents.FirstOrDefault(x => x.email == email);
            if (tutor != null)
            {
                if (tutor.password.Equals(password))
                {
                    Session["FullName"] = tutor.fullname;
                    Session["UserID"] = tutor.tutor_id;

                    return RedirectToAction("Index", "Home");
                }
            }
            if (student != null)
            {
                if (student.password.Equals(password))
                {
                    Session["FullName"] = student.fullname;
                    Session["UserID"] = student.student_id;

                    return RedirectToAction("Index", "Home");
                }
            }
            if (parent != null)
            {
                if (parent.password.Equals(password))
                {
                    Session["FullName"] = parent.fullname;
                    Session["UserID"] = parent.parent_id;

                    return RedirectToAction("Index", "Home");
                }
            }
            else
            {
                ViewBag.mgs = "tài khoản không tồn tại";
            }
            return View();
        }

        public ActionResult Logout(int id)
        {
            var user = m.tutors.FirstOrDefault(x => x.tutor_id == id);
            if (user != null)
            {
                Session["FullName"] = null;
                Session["UserID"] = null;
            }
            return RedirectToAction("Login");
        }
    }
}