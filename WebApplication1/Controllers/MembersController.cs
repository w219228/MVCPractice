using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication1.Models.EFModels;
using WebApplication1.Models.Repositories;
using WebApplication1.Models.Services;
using WebApplication1.Models.VM;

namespace WebApplication1.Controllers
{
    public class MembersController : Controller
    {
        private IMemberRepository repository;
        public MembersController()
        {
            repository = new MemberRepository();
        }
        // GET: Members
        public ActionResult Index()
        {
            return View();
        }

        // GET: Members/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Members/Create
        [HttpPost]
        public ActionResult Create(MemberCreateVM model)
        {
            try
            {
                new MemberService(repository).Create(model.ToDto());
            }
            catch (Exception ex)
            {
                ModelState.AddModelError(string.Empty, ex.Message);
            }


            if (ModelState.IsValid)
            {

                return RedirectToAction("Index");
            }

            return View(model);
        }

        // GET: Members/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Members/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
