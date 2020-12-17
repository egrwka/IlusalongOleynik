using OleynikProject.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OleynikProject.Controllers
{
    public class HomeController : Controller
    {
        private Context _db = new Context();
        public ActionResult Index()
        {
            foreach (var item in _db.Service.ToList().ToArray()) // Удаление спустя 24 часа
            {
                if (DateTime.Now > item.StartTime.AddHours(24))
                {
                    _db.Service.Remove(item);
                    _db.SaveChanges();
                }
            }
            ViewBag.Service = _db.Service.Include("Services").ToList();
            return View();
        }
        public ActionResult Services()
        {
            ViewBag.Services = _db.Services.ToList();
            return View();
        }
        public ActionResult AddEvent()
        {
            ViewBag.Services = _db.Services.ToList();
            ViewBag.listblock = _db.Service.ToArray();
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult AddEvent(Service objService)
        {
            Services services = _db.Services.Where(a => a.Id == objService.Services.Id).FirstOrDefault();
            var service = new Service
            {
                Name = objService.Name,
                Email = objService.Email,
                Services = services,
                StartTime = Convert.ToDateTime(objService.StartTime2)
            };
            _db.Service.Add(service);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult EditEvent(int id)
        {
            ViewBag.Service = _db.Service.Include("Services").Where(a => a.Id == id).FirstOrDefault();
            ViewBag.Services = _db.Services.ToList();
            ViewBag.listblock = _db.Service.ToArray();
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult EditEvent(Service objService)
        {
            Services services = _db.Services.Where(a => a.Id == objService.Services.Id).FirstOrDefault();
            Service service = _db.Service.Where(a => a.Id == objService.Id).FirstOrDefault();
            if (service != null)
            {
                service.Name = objService.Name;
                service.Email = objService.Email;
                service.Services = services;
                service.StartTime = objService.StartTime;
            }
            _db.Entry(service).State = EntityState.Modified;
            _db.SaveChanges();
            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult DeleteEvent(int? id)
        {
            Service task = _db.Service.Where(a => a.Id == id).FirstOrDefault();
            if (task != null)
            {
                _db.Service.Remove(task);
                _db.SaveChanges();
            }
            return Redirect(Request.UrlReferrer.ToString());
        }
        public ActionResult AddServices()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult AddServices(Services objService)
        {
            var service = new Services
            {
                Title = objService.Title,
                Description = objService.Description,
                Cost = objService.Cost
            };
            _db.Services.Add(service);
            _db.SaveChanges();
            return RedirectToAction("Services");
        }
        [HttpGet]
        public ActionResult EditServices(int id)
        {
            ViewBag.Services = _db.Services.Where(a => a.Id == id).FirstOrDefault();
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult EditServices(Services objService)
        {
            Services services = _db.Services.Where(a => a.Id == objService.Id).FirstOrDefault();
            if (services != null)
            {
                services.Title = objService.Title;
                services.Description = objService.Description;
                services.Cost = objService.Cost;
            }
            _db.Entry(services).State = EntityState.Modified;
            _db.SaveChanges();
            return RedirectToAction("Services");
        }
        [HttpGet]
        public ActionResult DeleteServices(int? id)
        {
            Services task = _db.Services.Where(a => a.Id == id).FirstOrDefault();
            if (task != null)
            {
                try
                {
                    _db.Services.Remove(task);
                    _db.SaveChanges();
                }
                catch (Exception)
                {
                    return Redirect(Request.UrlReferrer.ToString());
                }
            }
            return Redirect(Request.UrlReferrer.ToString());
        }
    }
}