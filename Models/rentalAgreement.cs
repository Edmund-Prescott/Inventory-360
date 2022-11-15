using System;
namespace instrumentRentals2.Models
{
    public class rentalAgreement
    {
        public int id { get; set; }
        public DateTime rentalStart { get; set; }
        // Not Sure how to Set these from Already Created Database Objects
        public instrument instrument { get; set; }
        public customer customer { get; set; }
    }
}

