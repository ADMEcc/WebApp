using System;
using System.Collections.Generic;

namespace ADME_Website.Models
{
    public partial class Donations
    {
        public int Id { get; set; }
        public string Email { get; set; }
        public string Wallet { get; set; }
        public int Usertype { get; set; }
        public double Amount { get; set; }
        public DateTime DonateTime { get; set; }
    }
}
