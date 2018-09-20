using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MyFirstMVC.Models;

namespace MyFirstMVC.Controllers
{
    public class PhoneController : Controller
    {
        private readonly ApplicationDbContext context;
        private readonly IHostingEnvironment environment;
        public PhoneController(ApplicationDbContext context, IHostingEnvironment environment)
        {
            this.context = context;
            this.environment = environment;
        }
        // GET: Phone
        public ActionResult Index()
        {
            IEnumerable<Phone> phones = context.Phones.OrderBy(p => p.Name);
            return View(phones);
        }

        // GET: Phone/Details/5
        public ActionResult Details(int id)
        {
            Phone phone = context.Phones.FirstOrDefault(p =>p.Id == id);
            if (phone== null)
            {
                return NotFound($"Нет телефона с таким ID {id}");
            }
            return View(phone);
        }
        public IActionResult Download(int id)
        {
            try
            {
       
                Phone phone = context.Phones.FirstOrDefault(p =>p.Id == id);
                if (phone== null)
                {
                    throw new NullReferenceException($"Нет телефона с таким ID {id}");
                }
                string filePath = Path.Combine(environment.ContentRootPath, $"Files/{phone.Name}.txt");
                string fileType = "application/txt";
                string fileName = $"{phone.Name}.txt";
               
                if (!System.IO.File.Exists(filePath))
                {
                    
                    using (StreamWriter str = new StreamWriter($"Files/{phone.Name}.txt"))
                    {
                       
                        str.Write($"Название: {phone.Name} \n".ToCharArray());
                        str.Write($"Производитель: {phone.Company}".ToCharArray());
                    }

                }

                return PhysicalFile(filePath, fileType, fileName);
            }
            catch (Exception e)
            {
                ViewData["Message"] = e.Message;
                return View("404");
            }
        }

        // GET: Phone/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Phone/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Phone phone)
        {
            try
            {
                context.Phones.Add(phone);
                context.SaveChanges();

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        public IActionResult Link(string name)
        {
            string sitePath = $"https://www.{name}.com";
            return RedirectPermanent(sitePath);
        }

        // GET: Phone/Delete/5
        public ActionResult Delete(int id)
        {
            Phone phone = context.Phones.Find(id);
            return View(phone);
        }

        // POST: Phone/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult DeletePhone(int Id)
        {
            Phone phone = context.Phones.Find(Id);
            try
            { 
                context.Phones.Remove(phone);
                context.SaveChanges();

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View("Delete", phone);
            }
        }
    }
}