﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using WebApplication1.Models;
using WebApplication1.ViewsModel;

namespace WebApplication1.Controllers
{
    public class MensagemController : Controller
    {
        private readonly WebApplication1Context _context;

        public MensagemController(WebApplication1Context context)
        {
            _context = context;
        }

        // GET: Mensagem
        public async Task<IActionResult> Index()
        {
            ViewData["CategoriaId"] = new SelectList(_context.Categoria, "CategoriaId", "Descricao");
            ViewData["MensagemId"] = new SelectList(_context.Mensagem, "MensagemId", "MensagemId");
            var blogContext = _context.Mensagem.Include(m => m.Comentarios);
            var blogContext1 = _context.Comentario.Include(c => c.Mensagem);

            var vm = new MensagemViewModel
            {
                Mensagens = await blogContext.ToListAsync(),
                Comentarios = await blogContext1.ToListAsync()
             
            };

            return View(vm);
        }

        // GET: Mensagem/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var mensagem = await _context.Mensagem
                .Include(m => m.Categorias)
                .FirstOrDefaultAsync(m => m.MensagemId == id);
            if (mensagem == null)
            {
                return NotFound();
            }

            return View(mensagem);
        }

        // GET: Mensagem/Create
        public IActionResult Create()
        {
            ViewData["CategoriaId"] = new SelectList(_context.Categoria, "CategoriaId", "CategoriaId");
            return View();
        }

        // POST: Mensagem/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("MensagemId,Titulo,Descricao,DataDeCriacao,CategoriaId")] Mensagem mensagem)
        {
            if (ModelState.IsValid)
            {
                _context.Add(mensagem);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["CategoriaId"] = new SelectList(_context.Categoria, "CategoriaId", "CategoriaId", mensagem.CategoriaId);
            return View(mensagem);
        }

        // GET: Mensagem/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var mensagem = await _context.Mensagem.FindAsync(id);
            if (mensagem == null)
            {
                return NotFound();
            }
            ViewData["CategoriaId"] = new SelectList(_context.Categoria, "CategoriaId", "CategoriaId", mensagem.CategoriaId);
            return View(mensagem);
        }

        // POST: Mensagem/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("MensagemId,Titulo,Descricao,DataDeCriacao,CategoriaId")] Mensagem mensagem)
        {
            if (id != mensagem.MensagemId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(mensagem);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MensagemExists(mensagem.MensagemId))
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
            ViewData["CategoriaId"] = new SelectList(_context.Categoria, "CategoriaId", "CategoriaId", mensagem.CategoriaId);
            return View(mensagem);
        }

        // GET: Mensagem/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var mensagem = await _context.Mensagem
                .Include(m => m.Categorias)
                .FirstOrDefaultAsync(m => m.MensagemId == id);
            if (mensagem == null)
            {
                return NotFound();
            }

            return View(mensagem);
        }

        // POST: Mensagem/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var mensagem = await _context.Mensagem.FindAsync(id);
            _context.Mensagem.Remove(mensagem);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool MensagemExists(int id)
        {
            return _context.Mensagem.Any(e => e.MensagemId == id);
        }
    }
}
