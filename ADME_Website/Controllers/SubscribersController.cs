using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ADME_Website.Models;
using Microsoft.AspNetCore.Http;

namespace ADME_Website.Controllers
{
    public class SubscribersController : Controller
    {
        private readonly ADME_WebsiteContext _context;

        public SubscribersController(ADME_WebsiteContext context)
        {
            _context = context;
        }

        
        [HttpPost]
        public String Index(IFormCollection formCollection)
        {
            String message = "";

            List<Subscribers> existingemail = _context.Subscribers.Where(p => p.Email.Equals(formCollection["Email"])).ToList();
            if(existingemail.Count == 0)
            {
                Random r = new Random();
                int id = r.Next(1, 1024);
                while (_context.Subscribers.Find(id) != null)
                {
                    id = r.Next(1, 1024);
                }

                string email = formCollection["Email"];


                if (ModelState.IsValid)
                {
                    Subscribers newSubscriber = new Subscribers();
                    newSubscriber.Id = id;
                    newSubscriber.Email = email;

                    _context.Subscribers.Add(newSubscriber);
                    _context.SaveChanges();
                    message = "Success! Thank you for subscribing!";
                }
            }
            else
            {
                message = "Sorry, this e-mail already exists!";
            }

            return message;
        }

        // GET: Subscribers/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var subscribers = await _context.Subscribers
                .FirstOrDefaultAsync(m => m.Id == id);
            if (subscribers == null)
            {
                return NotFound();
            }

            return View(subscribers);
        }

        // GET: Subscribers/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Subscribers/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Email")] Subscribers subscribers)
        {
            if (ModelState.IsValid)
            {
                _context.Add(subscribers);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(subscribers);
        }

        // GET: Subscribers/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var subscribers = await _context.Subscribers.FindAsync(id);
            if (subscribers == null)
            {
                return NotFound();
            }
            return View(subscribers);
        }

        // POST: Subscribers/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Email")] Subscribers subscribers)
        {
            if (id != subscribers.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(subscribers);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SubscribersExists(subscribers.Id))
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
            return View(subscribers);
        }

        // GET: Subscribers/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var subscribers = await _context.Subscribers
                .FirstOrDefaultAsync(m => m.Id == id);
            if (subscribers == null)
            {
                return NotFound();
            }

            return View(subscribers);
        }

        // POST: Subscribers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var subscribers = await _context.Subscribers.FindAsync(id);
            _context.Subscribers.Remove(subscribers);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool SubscribersExists(int id)
        {
            return _context.Subscribers.Any(e => e.Id == id);
        }
    }
}
