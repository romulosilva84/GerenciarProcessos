using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using GerenciarProcessos.Models;

namespace GerenciarProcessos.Controllers
{
    public class ProcessosController : Controller
    {
        private readonly GerenciarProcessosContext _context;

        public ProcessosController(GerenciarProcessosContext context)
        {
            _context = context;
        }

        // GET: Processos
        public async Task<IActionResult> Index()
        {
            Query1();
            Query2();
            Query3();
            Query4();
            Query5();
            Query6();

            return View(await _context.Processo.ToListAsync());
        }

        // GET: Processos/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var processo = await _context.Processo
                .FirstOrDefaultAsync(m => m.ProcessoID == id);
            if (processo == null)
            {
                return NotFound();
            }

            return View(processo);
        }

        // GET: Processos/Create
        public IActionResult Create()
        {
            PopularClientesDropDownList();
            return View();
        }

        // POST: Processos/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ProcessoID,ClienteID,Numero,Estado,Valor,Data,Estaativo")] Processo processo)
        {
            if (ModelState.IsValid)
            {
                _context.Add(processo);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            PopularClientesDropDownList(processo.ClienteID);
            return View(processo);
        }

        // GET: Processos/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var processo = await _context.Processo.FindAsync(id);
            if (processo == null)
            {
                return NotFound();
            }
            return View(processo);
        }

        // POST: Processos/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ProcessoID,ClienteID,Numero,Estado,Valor,Data,Estaativo")] Processo processo)
        {
            if (id != processo.ProcessoID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(processo);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ProcessoExists(processo.ProcessoID))
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
            return View(processo);
        }

        // GET: Processos/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var processo = await _context.Processo
                .FirstOrDefaultAsync(m => m.ProcessoID == id);
            if (processo == null)
            {
                return NotFound();
            }

            return View(processo);
        }

        // POST: Processos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var processo = await _context.Processo.FindAsync(id);
            _context.Processo.Remove(processo);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ProcessoExists(int id)
        {
            return _context.Processo.Any(e => e.ProcessoID == id);
        }

        private void PopularClientesDropDownList(object selectedClient = null)
        {
            var clientsQuery = from d in _context.Cliente
                               orderby d.Nome
                               select d;
            ViewBag.ClienteID = new SelectList(clientsQuery.AsNoTracking(), "ClienteID", "Nome", selectedClient);
        }

        private void Query1()
        {
            var sum1 =  (from d in _context.Processo
                         where d.Estaativo == true
                         select d.Valor).ToList();

            ViewBag.result1 = sum1.Sum();
        }

        private void Query2()
        {
            var count21 = (from d in _context.Processo
                           where d.ClienteID == 1
                           where d.Estado == "Rio de Janeiro"
                           select d.Valor).ToList();

            var count22 = from d in _context.Processo
                          where d.ClienteID == 1
                          where d.Estado == "Rio de Janeiro"
                          select d.Numero;

            int result21 = count21.Sum();
            int result22 = count22.Count();
            ViewBag.result2 = result21 / result22;
        }

        private void Query3()
        {
            var count3 = from d in _context.Processo
                         where d.Valor > 100000
                         select d.Numero;
            ViewBag.result3 = count3.Count();
        }

        private void Query4()
        {
            DateTime startdate = Convert.ToDateTime("01/09/2007");
            DateTime enddate = Convert.ToDateTime("30/09/2007");

            var count4 = (from d in _context.Processo
                          where d.Data >= startdate && d.Data <= enddate
                          select d.Numero).ToList();

            ViewBag.result4 = count4;
        }

        private void Query5()
        {
            var join5 = (from p in _context.Processo
                         join c in _context.Cliente on p.ClienteID equals c.ClienteID
                         where c.Estado == p.Estado
                         select new { Nome = c.Nome, Numero = p.Numero});

            ViewBag.result5 = join5;
        }
        private void Query6()
        {
            var count6 = (from d in _context.Processo
                          where d.Numero.Contains("TRAB")
                          select d.Numero).ToList();

            ViewBag.result6 = count6;
        }
    }
}
