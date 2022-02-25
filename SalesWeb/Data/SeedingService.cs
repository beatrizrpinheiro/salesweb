using SalesWeb.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SalesWeb.Data
{
    public class SeedingService
    {
        private SalesWebContext _context;

        public SeedingService(SalesWebContext context)
        {
            _context = context;
        }

        public void Seed()
        {
            if (_context.Department.Any() ||
                _context.Seller.Any() ||
                _context.SalesRecord.Any())
            {
                return; // DB has been seeded
            }

            Department d1 = new Department(1, "Computers");
            Department d2 = new Department(2, "Electronics");
            Department d3 = new Department(3, "Books");

            Seller s1 = new Seller(1, "Cassio dos Santos", "cassio@gmail.com", new DateTime(1998, 4, 21), 1500.0, d1);
            Seller s2 = new Seller(2, "Amanda Reis", "amandareis@gmail.com", new DateTime(1995, 3, 21), 4000.0, d2);
            Seller s3 = new Seller(3, "Beatriz Santos", "beatrizrpinheiro@outllook.com", new DateTime(1995, 2, 23), 4800.0, d3);
            

            SalesRecord r1 = new SalesRecord(1, new DateTime(2018, 09, 25), 11000.0, Models.Enums.SaleStatus.Billed, s1);
            SalesRecord r2 = new SalesRecord(2, new DateTime(2022, 02, 23), 20000.0, Models.Enums.SaleStatus.Billed, s1);
            SalesRecord r3 = new SalesRecord(3, new DateTime(2022, 02, 20), 8000.0, Models.Enums.SaleStatus.Billed, s2);

            _context.Department.AddRange(d1, d2, d3);
          
            _context.SalesRecord.AddRange(r1, r2, r3);

            _context.SaveChanges();
        }

    }
}
