using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebApplication2.Models;
using WebApplication2.Repository;
using System.Web.Mvc;
using WebApplication2.Models.Sessions;

namespace WebApplication2.Controllers
{
    public class DoctorsController : Controller
    {
        #region Declarations
        public LogOnSession objLogOnSession = new LogOnSession();
        DoctorRepository repository = new DoctorRepository();
        DoctorViewModel model = new DoctorViewModel();
        Users users = new Users();
        #endregion

        // GET: Doctors
        public ActionResult Index()
        {
            ModelState.Clear();
            return View(repository.GetAllDoctorList());
        }

        #region inserting doctors
        [HttpGet]
        public ActionResult Create()
        {
            //Check LogOn session is null or not. If null then do sign out
            if (this.Session[LogOnSession.UserLogOnSession] == null)
            {
                return RedirectToAction("SignOut", "Main");
            }
            this.objLogOnSession = (LogOnSession)this.Session[LogOnSession.UserLogOnSession];

            this.ViewBag.UserName = string.Concat("Welcome ", this.objLogOnSession.FirstName, " ", this.objLogOnSession.LastName);
            this.model.UserId = this.objLogOnSession.UserId = model.UserId;

            return View();
        }

        [HttpPost]
        public ActionResult Create(DoctorViewModel model)
        {
            try
            {
                //Check LogOn session is null or not. If null then do sign out
                if (this.Session[LogOnSession.UserLogOnSession] == null)
                {
                    return RedirectToAction("SignOut", "Main");
                }
                this.objLogOnSession = (LogOnSession)this.Session[LogOnSession.UserLogOnSession];
                this.ViewBag.UserName = string.Concat("Welcome ", this.objLogOnSession.FirstName, " ", this.objLogOnSession.LastName);

                if (ModelState.IsValid)
                {
                    if (repository.SetDoctor(model))
                    {
                        ViewBag.Message = "Doctor Added Successfully";
                        ModelState.Clear();
                    }
                }
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion

        #region Updating Doctors
        [HttpGet]
        public ActionResult Edit(int id)
        {
            return View(repository.GetAllDoctorList().Find(model => model.DoctorID == id));
        }


        [HttpPost]
        public ActionResult Edit(DoctorViewModel model)
        {
            try
            {
                repository.UpdateDoctor(model);
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion

        #region Delete Doctors
        // GET: Student/Delete/5
        public ActionResult Delete(int id)
        {
            try
            {
                if (repository.DeleteDoctor(id))
                {
                    ViewBag.AlertMsg = "Doctor Deleted Successfully";
                }
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
        #endregion
    }
}