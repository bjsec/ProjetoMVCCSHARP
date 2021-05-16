using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ProjetoMVCCSHARP.Models;

namespace ProjetoMVCCSHARP.Data
{
    public class ProjetoMVCCSHARPContext : DbContext
    {
        public ProjetoMVCCSHARPContext (DbContextOptions<ProjetoMVCCSHARPContext> options)
            : base(options)
        {
        }

        public DbSet<Department> Department { get; set; }
        public DbSet<Seller> Seller { get; set; }
        public DbSet<SalesRecord> SalesRecord { get; set; }
    }
}
