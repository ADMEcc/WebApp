using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;
using ADME_Website.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ADME_Website.Controllers
{
    public class DonationController : Controller
    {
        private readonly ADME_WebsiteContext _context;

        public DonationController(ADME_WebsiteContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public void Index(IFormCollection formCollection)
        {
            //int personId = int.Parse(formCollection["PersonId"]);

            //id-t generálni
            Random r = new Random();
            int id = r.Next(1, 1024);
            while(_context.Donations.Find(id) != null)
            {
                id = r.Next(1, 1024);
            }

            string email = formCollection["Email"];
            string wallet = formCollection["Wallet"];
            int usertype = int.Parse(formCollection["Usertype"]);

            double amount = double.Parse(formCollection["Amount"]);
            string donatetimestring = formCollection["DonateTime"];

            DateTime donatetime;
            //DateTime.TryParse(donatetimestring, "YYYY-MM-DD HH:mm", out donatetime,);

            bool done = DateTime.TryParseExact(formCollection["DonateTime"], "yyyy-MM-dd HH:mm", CultureInfo.InvariantCulture,
                DateTimeStyles.None, out donatetime);
            



            if (ModelState.IsValid)
            {
                Donations newDonation = new Donations();
                newDonation.Id = id;
                newDonation.Email = email;
                newDonation.Wallet = wallet;
                newDonation.Usertype = usertype;
                newDonation.Amount = amount;
                newDonation.DonateTime = donatetime;

                _context.Donations.Add(newDonation);
                _context.SaveChanges();

            }
        }
    }
}