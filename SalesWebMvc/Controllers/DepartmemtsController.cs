using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using SalesWebMvc.Data;
using SalesWebMvc.Models;

namespace SalesWebMvc.Controllers
{
    public class DepartmemtsController : Controller
    {
        private readonly SalesWebMvcContext _context;

        public DepartmemtsController(SalesWebMvcContext context)
        {
            _context = context;
        }

        // GET: Departmemts
        public async Task<IActionResult> Index()
        {
            return View(await _context.Departmemt.ToListAsync());
        }

        // GET: Departmemts/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var departmemt = await _context.Departmemt
                .FirstOrDefaultAsync(m => m.Id == id);
            if (departmemt == null)
            {
                return NotFound();
            }

            return View(departmemt);
        }

        // GET: Departmemts/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Departmemts/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name")] Departmemt departmemt)
        {
            if (ModelState.IsValid)
            {
                _context.Add(departmemt);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(departmemt);
        }

        // GET: Departmemts/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var departmemt = await _context.Departmemt.FindAsync(id);
            if (departmemt == null)
            {
                return NotFound();
            }
            return View(departmemt);
        }

        // POST: Departmemts/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name")] Departmemt departmemt)
        {
            if (id != departmemt.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(departmemt);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DepartmemtExists(departmemt.Id))
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
            return View(departmemt);
        }

        // GET: Departmemts/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var departmemt = await _context.Departmemt
                .FirstOrDefaultAsync(m => m.Id == id);
            if (departmemt == null)
            {
                return NotFound();
            }

            return View(departmemt);
        }

        // POST: Departmemts/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var departmemt = await _context.Departmemt.FindAsync(id);
            _context.Departmemt.Remove(departmemt);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool DepartmemtExists(int id)
        {
            return _context.Departmemt.Any(e => e.Id == id);
        }
    }
}
