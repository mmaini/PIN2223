using Microsoft.AspNetCore.Mvc;
using MVCDemo.Data;
using MVCDemo.Models;
using System.Collections.Generic;

namespace MVCDemo.Controllers
{
    public class ExpenseTypeController : Controller
    {
        private readonly ApplicationDbContext _db;
        public ExpenseTypeController(ApplicationDbContext db)
        {
            _db = db;
        }

        public IActionResult Index()
        {
            IEnumerable<ExpenseType> objList = _db.ExpenseTypes;
            return View(objList);
        }

        //GET- Create -> ovo je za inicijalno otvaranje Create view-a
        public IActionResult Create()
        {
            return View();
        }

        //POST- Create -> ovo je kada se okine submit na formi
        [HttpPost]
        //Kakone bi bilo tko mogao pozivati
        [ValidateAntiForgeryToken]
        public IActionResult Create(ExpenseType obj)
        {
            if(ModelState.IsValid)
            {
                _db.ExpenseTypes.Add(obj);
                //kako bi se spremile promjene u bazu
                _db.SaveChanges();
                //preusmjeravano na drugi action unutar ovog controllera - prikaz svih tipova
                return RedirectToAction("Index");
            }
            return View(obj);
           
        }


        //GET- Delete -> za preusmjeravanje na view za brisanje
        public IActionResult Delete(int? id)
        {
            if(id == null || id==0)
            {
                return NotFound();
            }
            var obj = _db.ExpenseTypes.Find(id);
            if (obj == null)
            {
                return NotFound();
            }
            return View(obj);
        }


        //POST- Delete
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult DeletePost(int? id)
        {
            var obj = _db.ExpenseTypes.Find(id);

            if(obj == null)
            {
                return NotFound();
            }

            _db.ExpenseTypes.Remove(obj);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }

        //GET- Update -> za preusmjeravanje na view za update
        public IActionResult Update(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            var obj = _db.ExpenseTypes.Find(id);
            if (obj == null)
            {
                return NotFound();
            }
            return View(obj);
        }


        //POST- Update
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Update(ExpenseType obj)
        {
            if (ModelState.IsValid)
            {
                _db.ExpenseTypes.Update(obj);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(obj);
        }


    }
}
