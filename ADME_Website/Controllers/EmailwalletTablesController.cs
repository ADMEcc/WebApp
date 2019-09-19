using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ADME_Website.Models;

namespace ADME_Website.Controllers
{
    public class EmailwalletTablesController : Controller
    {
        private readonly ADME_WebsiteContext _context;

        public EmailwalletTablesController(ADME_WebsiteContext context)
        {
            _context = context;
        }

        // GET: EmailwalletTables
        public async Task<IActionResult> Index()
        {
            return View(await _context.EmailwalletTable.ToListAsync());
        }

        // GET: EmailwalletTables/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var emailwalletTable = await _context.EmailwalletTable
                .FirstOrDefaultAsync(m => m.Id == id);
            if (emailwalletTable == null)
            {
                return NotFound();
            }

            return View(emailwalletTable);
        }

        // GET: EmailwalletTables/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: EmailwalletTables/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Email,Wallet")] EmailwalletTable emailwalletTable)
        {
            if (ModelState.IsValid)
            {
                _context.Add(emailwalletTable);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(emailwalletTable);
        }

        // GET: EmailwalletTables/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var emailwalletTable = await _context.EmailwalletTable.FindAsync(id);
            if (emailwalletTable == null)
            {
                return NotFound();
            }
            return View(emailwalletTable);
        }

        // POST: EmailwalletTables/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Email,Wallet")] EmailwalletTable emailwalletTable)
        {
            if (id != emailwalletTable.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(emailwalletTable);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!EmailwalletTableExists(emailwalletTable.Id))
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
            return View(emailwalletTable);
        }

        // GET: EmailwalletTables/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var emailwalletTable = await _context.EmailwalletTable
                .FirstOrDefaultAsync(m => m.Id == id);
            if (emailwalletTable == null)
            {
                return NotFound();
            }

            return View(emailwalletTable);
        }

        // POST: EmailwalletTables/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var emailwalletTable = await _context.EmailwalletTable.FindAsync(id);
            _context.EmailwalletTable.Remove(emailwalletTable);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool EmailwalletTableExists(int id)
        {
            return _context.EmailwalletTable.Any(e => e.Id == id);
        }
    }
}
