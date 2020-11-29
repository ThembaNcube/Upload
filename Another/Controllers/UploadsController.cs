using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Another.Models;
using Another.Services;

namespace Another.Controllers
{
    public class UploadsController : Controller
    {
        private readonly UploadsServices _upSvc;

        public UploadsController(UploadsServices uploadsServices)
        {
            _upSvc = uploadsServices;
        }
        // GET: UploadsController
        public ActionResult<IList<Uploads>> Index() => View(_upSvc.Read());
        //public ActionResult<Uploads> Index()
        //{
        //    return View( _upSvc.Read());/*.EmployeeDetails.ToListAsync());*/
        //}


        // GET: UploadsController/Create
        [HttpGet]
        public ActionResult Create() /*=> View();*/
        {
            return View();
        }

        // POST: UploadsController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult<Uploads> Create(Uploads uploads, IFormFile file)
        {

            if (ModelState.IsValid)
            {
                //if (file == null || file.Length == 0)
                //    return Content("File not selected");
                //var path = path.Combine(Directory.getCurrentDirectory(),"wwwroot" file.getFilename())
                _upSvc.Create(uploads);
            }
            return RedirectToAction("Index");
        }

        // GET: UploadsController/Edit/5
        [HttpGet]
        public ActionResult<Uploads> Edit(string id) /*=> View(_upSvc.Find(id));*/
        {
            return View(_upSvc.Find(id));
        }

        // POST: UploadsController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Uploads uploads)
        {
            if(ModelState.IsValid)
            {
                return RedirectToAction(nameof(Index));
            }
            
            return View(uploads);
            
        }

        // GET: UploadsController/Delete/5
        [HttpGet]
        public ActionResult Delete(string id)
        {
            _upSvc.Delete(id);
            return RedirectToAction("Index");
        }
        
        // POST: UploadsController/Delete/5
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult Delete(int id, IFormCollection collection)
        //{
        //    try
        //    {
        //        return RedirectToAction(nameof(Index));
        //    }
        //    catch
        //    {
        //        return View();
        //    }
        //}
    }
}
