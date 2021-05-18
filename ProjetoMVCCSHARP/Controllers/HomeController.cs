using Microsoft.AspNetCore.Mvc;
using ProjetoMVCCSHARP.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ProjetoMVCCSHARP.Data;

namespace ProjetoMVCCSHARP.Controllers
{
    public class HomeController:Controller
    {
        private readonly ProjetoMVCCSHARPContext _context;

        public HomeController(ProjetoMVCCSHARPContext context)
        {
            _context = context;
        }

        // GET: Noticias
        public async Task<IActionResult> Index()
        {
            var minhaNoticia = View(await _context.Noticia.OrderByDescending(noticia => noticia.ID).ToListAsync());
            Console.WriteLine(minhaNoticia.ToString());
            
            return View(await _context.Noticia.OrderByDescending(noticia => noticia.ID).ToListAsync());
        }
        // GET: Noticias/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if(id == null)
            {
                return NotFound();
            }

            var noticia = await _context.Noticia
                .FirstOrDefaultAsync(m => m.ID == id);
            if(noticia == null)
            {
                return NotFound();
            }

            return View(noticia);
        }


        public IActionResult About()
        {
            ViewData["Message"] = "Primeiro projeto MVC";
            ViewData["email"] = "ayres.sailing@gmail.com";
            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0,Location = ResponseCacheLocation.None,NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
