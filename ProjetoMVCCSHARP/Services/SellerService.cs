using ProjetoMVCCSHARP.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ProjetoMVCCSHARP.Models;

namespace ProjetoMVCCSHARP.Services
{
    public class SellerService
    {
        private readonly ProjetoMVCCSHARPContext _context;

        public SellerService(ProjetoMVCCSHARPContext context)
        {
            _context = context;
        }
        public List<Seller> FindAll()
        {
            return _context.Seller.ToList();
        }
    }
}
