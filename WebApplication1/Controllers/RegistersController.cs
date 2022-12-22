using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using WebApplication1.Models.EFModels;
using WebApplication1.Models.Repositories;
using WebApplication1.Models.Services;

namespace WebApplication1.Controllers
{
    public class RegistersController : Controller
    {
        private AppDbContext db = new AppDbContext();

        // GET: Registers
        public ActionResult Index()
        {
			var data = new RegisterRepository().GetAll();
			return View(data);
        }

        // GET: Registers/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
			try
			{
				Register register =new RegisterService().Find(id.Value);
				return View(register);
			}
			catch(Exception ex)
			{
				return HttpNotFound();
			}
            
            
        }

        // GET: Registers/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Registers/Create
        // 若要避免過量張貼攻擊，請啟用您要繫結的特定屬性。
        // 如需詳細資料，請參閱 https://go.microsoft.com/fwlink/?LinkId=317598。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,Name,Email,CreatedTime")] Register register)
        {
			try
			{
				new RegisterService().Create(register);
			}
			catch(Exception ex)
			{
				ModelState.AddModelError(string.Empty, ex.Message);
			}
			
			
            if (ModelState.IsValid)
            {
                
                return RedirectToAction("Index");
            }

            return View(register);
        }
    }
}