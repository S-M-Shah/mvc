using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication9.Models;
using WebApplication9.Data;


namespace WebApplication9.Controllers
{
    public class StudentsController : Controller
    {
        // CollegeContext db = new CollegeContext();
        private readonly CollegeContext db;

        public StudentsController(CollegeContext context)
        {
            db = context;
        }
        public async Task<IActionResult> Index()
        {
            return View(await db.Students.ToListAsync());
        }








        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,StudentName,ContactNumber")] Students suppose)
        {
            if (ModelState.IsValid)
            {
                db.Add(suppose);
                await db.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(suppose);
        }





        public async Task<IActionResult> Edit(int? Id)
        {
            if (Id == null)
            {
                return NotFound();
            }
            var dataa = await db.Students.FindAsync(Id);
            if (dataa == null)
            {
                return NotFound();
            }
            return View(dataa);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit([Bind("Id,StudentName,ContactNumber")] Students S)
        {
            if (S.Id == null)
            {
                return NotFound();
            }
            if (ModelState.IsValid)
            {
                try
                {
                    db.Update(S);
                    await db.SaveChangesAsync();
                }
                catch(DbUpdateConcurrencyException)
                {
                    if(db.Students.Any(e=>e.Id != S.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(S);
        }

      
        public async Task<IActionResult> Delete(int? Id)
        {
            if (Id == null)
            {
                return NotFound();
            }
            var dataa=await db.Students.FirstOrDefaultAsync(x => x.Id == Id);
            if (dataa == null)
            {

                return NotFound();
            }
            db.Students.Remove(dataa);
            await db.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }








    }
}
