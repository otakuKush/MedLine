using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication2.Models;
using WebApplication2.Repository;

namespace WebApplication2.Controllers
{
    public class PatientController : Controller
    {
        PatientRepository repository = new PatientRepository();
        // GET: Patient

        [HttpGet]
        public ActionResult Index()
        {
            ModelState.Clear();
            return View(repository.GetAllPatient());
        }


        #region Creating Patient

        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(PatientViewModel model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    if (repository.AddPatient(model))
                    {
                        ViewBag.Message = "Patient Added Successfully";
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

        #region Updating Patient
        [HttpGet]
        public ActionResult Edit(int id)
        {
            return View(repository.GetAllPatient().Find(model => model.PatientID == id));
        }


        [HttpPost]
        public ActionResult Edit(PatientViewModel model)
        {
            try
            {
                repository.UpdatePatient(model);
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion

    }
}