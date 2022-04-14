using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using my.netCore2pm.db;
using my.netCore2pm.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace my.netCore2pm.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            coreakshayContext dbobj = new coreakshayContext();
            var res = dbobj.Coretables.ToList();
            List<A_Model> mobj = new List<A_Model>();

            foreach (var item in res)
            {
                mobj.Add(new A_Model
                {
                    Id = item.Id,
                    Name = item.Name,
                    Email = item.Email,
                    City = item.City,
                    College = item.College
                });
            }
            return View(mobj);
        }

        public IActionResult Privacy()
        {
            return View();
        }




        public IActionResult edit(int id)
        {
            A_Model mobj = new A_Model();
            coreakshayContext dbobj = new coreakshayContext();
            var edititem = dbobj.Coretables.Where(x => x.Id == id).First();

            mobj.Id = edititem.Id;
            mobj.Name = edititem.Name;

            mobj.Email = edititem.Email;

            mobj.City = edititem.City;
            mobj.College = edititem.College;

            return View("addfrom", mobj);
        }


        [HttpGet]
        public IActionResult addfrom()
        {
            return View();
        }
        [HttpPost]
        public IActionResult addfrom(A_Model Aobj)
        {
            coreakshayContext dbobj = new coreakshayContext();
            Coretable obj1 = new Coretable();

            obj1.Id = Aobj.Id;
            obj1.Name = Aobj.Name;
            obj1.Email = Aobj.Email;
            obj1.City = Aobj.City;
            obj1.College = Aobj.College;
            //dbobj.Coretables.Add(obj1);
           
            if(Aobj.Id==0)
            {
                dbobj.Coretables.Add(obj1);
                dbobj.SaveChanges();
            }
            else
            {
                dbobj.Entry(obj1).State =EntityState.Modified;
                dbobj.SaveChanges();
            }
  
            return RedirectToAction("Index");
        }


/*
             if (objnew.id == 0)
            {
                obj.newtables.Add(obj1);
                obj.SaveChanges();
            }
            else
            {
                obj.Entry(obj1).State = System.Data.Entity.EntityState.Modified;
                obj.SaveChanges();
            }


return RedirectToAction("mytable1");
*/







public IActionResult Delete(int Id)
        {

            coreakshayContext dbobj = new coreakshayContext();
            var deleteitam = dbobj.Coretables.Where(x => x.Id == Id).First();
            dbobj.Coretables.Remove(deleteitam);
            dbobj.SaveChanges();

            return RedirectToAction("Index");
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
