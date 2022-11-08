using Microsoft.AspNetCore.Mvc;
using MVCDemo.Data;
using MVCDemo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MVCDemo.Controllers
{
    public class ItemController : Controller
    {
        private readonly ApplicationDbContext _db;
        public ItemController(ApplicationDbContext db)
        {
            _db = db;
        }

        public IActionResult Index()
        {
            IEnumerable<Item> objList = _db.Items;
            return View(objList);
        }

        //GET- Create -> ovo je za inicijalno otvaranje Create view-a
        public IActionResult Create()
        {         
            return View();
        }

        //POST- Create -> ovo je kada se okine submit na formi
        [HttpPost]
        //Kako se ne bi bilo tko mogao pozivati
        [ValidateAntiForgeryToken]
        public IActionResult Create(Item obj)
        {
            _db.Items.Add(obj);
            //kako bi se spremile promjene u bazu
            _db.SaveChanges();
            //preusmjeravano na drugi action unutar ovog controllera - prikaz svih itema
            return RedirectToAction("Index");
        }
    }
}
