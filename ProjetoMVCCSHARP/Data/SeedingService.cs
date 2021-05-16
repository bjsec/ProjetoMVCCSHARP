using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ProjetoMVCCSHARP.Models;
using ProjetoMVCCSHARP.Models.Enums;

namespace ProjetoMVCCSHARP.Data
{
    public class SeedingService
    {
        private ProjetoMVCCSHARPContext _context;

        public SeedingService(ProjetoMVCCSHARPContext context)
        {
            _context = context;
        }

        public void Seed()
        {
            if (_context.Department.Any() ||
                _context.Seller.Any() ||
                _context.SalesRecord.Any())
            {
                return;  //DB has been seeded
            }

            Department d1 = new Department(1,"Computers");
            Department d2 = new Department(2,"Electronics");
            Department d3 = new Department(3,"Fashion");
            Department d4 = new Department(4,"Books");


            Seller s1 = new Seller(1,"Bob Brow","bo@gmail.com",1000.0, new DateTime(1998,4,21), d1);
            Seller s2 = new Seller(2,"Maria","maria@gmail.com",1000.0,new DateTime(1979,1,12),d2);
            Seller s3 = new Seller(3,"Alex","alex@gmail.com",1000.0,new DateTime(1998,1,15),d3);
            Seller s4 = new Seller(4,"joao","joao@gmail.com",1000.0,new DateTime(1997,1,22),d4);

            SalesRecord r1 = new SalesRecord(1,new DateTime(2018,09,25),11000.0,SalesStatus.Billed,s1);
            SalesRecord r2 = new SalesRecord(2,new DateTime(2018,09,25),11000.0,SalesStatus.Billed,s2);
            SalesRecord r3 = new SalesRecord(3,new DateTime(2018,09,25),11000.0,SalesStatus.Billed,s3);
            SalesRecord r4 = new SalesRecord(4,new DateTime(2018,09,25),11000.0,SalesStatus.Billed,s4);

            _context.Department.AddRange(d1,d2,d3,d4);
            _context.Seller.AddRange(s1,s2,s3,s4);
            _context.SalesRecord.AddRange(r1,r2,r3,r4);

            _context.SaveChanges();
        }
    }
}
