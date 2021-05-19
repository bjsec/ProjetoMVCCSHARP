using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ProjetoMVCCSHARP.Data;
using ProjetoMVCCSHARP.Models;
using Microsoft.Extensions.Hosting;


namespace ProjetoMVCCSHARP.Controllers
{
    public class NoticiasController:Controller
    {
        private readonly ProjetoMVCCSHARPContext _context;
        private readonly IHostingEnvironment hostingEnvironment;

        public NoticiasController(ProjetoMVCCSHARPContext context,IHostingEnvironment hostingenv)
        {
            hostingEnvironment = hostingenv;
            _context = context;
        }

        // GET: Noticias
        public async Task<IActionResult> Index()
        {
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

        // GET: Noticias/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Noticias/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,Titulo,Resumo,Conteudo,Imagem")] NoticiaViewModel noticia)
        {
            if(ModelState.IsValid)
            {
                string nomeUnicoArquivo = UploadedFile(noticia);
                Noticia noticiaFinal = new Noticia
                {
                    ID = noticia.ID,
                    Titulo = noticia.Titulo,
                    Resumo= noticia.Resumo,
                    Conteudo = noticia.Conteudo,
                    Imagem = nomeUnicoArquivo,
                };

                _context.Add(noticiaFinal);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(noticia);
        }

        // GET: Noticias/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if(id == null)
            {
                return NotFound();
            }

            var noticia = await _context.Noticia.FindAsync(id);
            if(noticia == null)
            {
                return NotFound();
            }
            return View(noticia);
        }

        // POST: Noticias/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id,[Bind("ID,Titulo,Resumo,Conteudo")] Noticia noticia)
        {
            if(id != noticia.ID)
            {
                return NotFound();
            }

            if(ModelState.IsValid)
            {
                try
                {
                    _context.Update(noticia);
                    await _context.SaveChangesAsync();
                }
                catch(DbUpdateConcurrencyException)
                {
                    if(!NoticiaExists(noticia.ID))
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
            return View(noticia);
        }

        // GET: Noticias/Delete/5
        public async Task<IActionResult> Delete(int? id)
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

        // POST: Noticias/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var noticia = await _context.Noticia.FindAsync(id);
            _context.Noticia.Remove(noticia);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool NoticiaExists(int id)
        {
            return _context.Noticia.Any(e => e.ID == id);
        }

        private string UploadedFile(NoticiaViewModel model)
        {
            string nomeUnicoArquivo = null;
            if(model.Imagem != null)
            {
                string pastaFotos = Path.Combine(hostingEnvironment.ContentRootPath,"wwwroot","images");
                nomeUnicoArquivo = Guid.NewGuid().ToString() + "_" + model.Imagem.FileName;
                string caminhoArquivo = Path.Combine(pastaFotos,nomeUnicoArquivo);
                using(var fileStream = new FileStream(caminhoArquivo,FileMode.Create))
                {
                    model.Imagem.CopyTo(fileStream);
                }
            }
            return nomeUnicoArquivo;
        }
    }
}
