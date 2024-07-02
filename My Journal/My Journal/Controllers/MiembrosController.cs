using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using My_Journal.Models.Miembros;

namespace My_Journal.Controllers
{
    public class MiembrosController : Controller
    {
        public IActionResult Index(DateTime? startDate, DateTime? endDate)
        {
            try
            {
                // Leer las fechas desde los parámetros o desde las variables de sesión
                if (startDate.HasValue && endDate.HasValue)
                {
                    // Guardar las fechas en la sesión si se proporcionan
                    HttpContext.Session.SetString("startDate", startDate.Value.ToString("yyyy-MM-dd"));
                    HttpContext.Session.SetString("endDate", endDate.Value.ToString("yyyy-MM-dd"));
                }
                else
                {
                    var startDateString = HttpContext.Session.GetString("startDate");
                    var endDateString = HttpContext.Session.GetString("endDate");

                    if (!string.IsNullOrEmpty(startDateString))
                    {
                        startDate = DateTime.Parse(startDateString);
                    }
                    if (!string.IsNullOrEmpty(endDateString))
                    {
                        endDate = DateTime.Parse(endDateString);
                    }
                }

                // Si las fechas no están definidas, establecer un rango predeterminado (ej. último mes)
                if (!startDate.HasValue)
                {
                    startDate = DateTime.Now;
                }
                if (!endDate.HasValue)
                {
                    endDate = DateTime.Now;
                }

                // Lógica para obtener el listado de ofrendas según las fechas
                var desde = startDate.Value.ToString("yyyyMMdd");
                var hasta = endDate.Value.ToString("yyyyMMdd");

                MantMiembro mantDiezmo = new MantMiembro();
                var miembros = mantDiezmo.GetListadoMiembros(desde, hasta);

                // Pasar el listado de ofrendas y las fechas a la vista
                ViewBag.StartDate = startDate.Value.ToString("yyyy-MM-dd");
                ViewBag.EndDate = endDate.Value.ToString("yyyy-MM-dd");

                return View(miembros);
            }
            catch (Exception ex)
            {
                // Manejar la excepción según sea necesario
                ViewBag.ErrorMessage = $"Error al cargar el listado de ofrendas: {ex.Message}";
                return View(new List<Miembro>());
            }
        }

        [HttpPost]
        public IActionResult SetSessionDates(string startDate, string endDate)
        {
            try
            {
                // Guardar las fechas en formato string en las variables de sesión
                HttpContext.Session.SetString("startDate", startDate);
                HttpContext.Session.SetString("endDate", endDate);

                return Json(new { success = true });
            }
            catch (Exception ex)
            {
                return Json(new { success = false, message = ex.Message });
            }
        }
        //private readonly CbnIglesiaContext _context;

        //public MiembrosController(CbnIglesiaContext context)
        //{
        //    _context = context;
        //}

        //// GET: Miembroes
        //public async Task<IActionResult> Index()
        //{
        //    var cbnIglesiaContext = _context.Miembros.Include(m => m.UsuarioCreacionNavigation);
        //    return View(await cbnIglesiaContext.ToListAsync());
        //}

        //// GET: Miembroes/Details/5
        //public async Task<IActionResult> Details(int? id)
        //{
        //    if (id == null)
        //    {
        //        return NotFound();
        //    }

        //    var miembro = await _context.Miembros
        //        .Include(m => m.UsuarioCreacionNavigation)
        //        .FirstOrDefaultAsync(m => m.IdMiembro == id);
        //    if (miembro == null)
        //    {
        //        return NotFound();
        //    }

        //    return View(miembro);
        //}

        //// GET: Miembroes/Create
        //public IActionResult Create()
        //{
        //    ViewData["UsuarioCreacion"] = new SelectList(_context.Usuarios, "IdUsuario", "IdUsuario");
        //    return View();
        //}

        //// POST: Miembroes/Create
        //// To protect from overposting attacks, enable the specific properties you want to bind to.
        //// For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> Create([Bind("IdMiembro,Nombre,Apellido,Direccion,Telefono,FechaNacimiento,FechaBautismo,Estado,UsuarioCreacion,FechaCreacion,UsuarioModifica,FechaModifica")] Miembro miembro)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        _context.Add(miembro);
        //        await _context.SaveChangesAsync();
        //        return RedirectToAction(nameof(Index));
        //    }
        //    ViewData["UsuarioCreacion"] = new SelectList(_context.Usuarios, "IdUsuario", "IdUsuario", miembro.UsuarioCreacion);
        //    return View(miembro);
        //}

        //// GET: Miembroes/Edit/5
        //public async Task<IActionResult> Edit(int? id)
        //{
        //    if (id == null)
        //    {
        //        return NotFound();
        //    }

        //    var miembro = await _context.Miembros.FindAsync(id);
        //    if (miembro == null)
        //    {
        //        return NotFound();
        //    }
        //    ViewData["UsuarioCreacion"] = new SelectList(_context.Usuarios, "IdUsuario", "IdUsuario", miembro.UsuarioCreacion);
        //    return View(miembro);
        //}

        //// POST: Miembroes/Edit/5
        //// To protect from overposting attacks, enable the specific properties you want to bind to.
        //// For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> Edit(int id, [Bind("IdMiembro,Nombre,Apellido,Direccion,Telefono,FechaNacimiento,FechaBautismo,Estado,UsuarioCreacion,FechaCreacion,UsuarioModifica,FechaModifica")] Miembro miembro)
        //{
        //    if (id != miembro.IdMiembro)
        //    {
        //        return NotFound();
        //    }

        //    if (ModelState.IsValid)
        //    {
        //        try
        //        {
        //            _context.Update(miembro);
        //            await _context.SaveChangesAsync();
        //        }
        //        catch (DbUpdateConcurrencyException)
        //        {
        //            if (!MiembroExists(miembro.IdMiembro))
        //            {
        //                return NotFound();
        //            }
        //            else
        //            {
        //                throw;
        //            }
        //        }
        //        return RedirectToAction(nameof(Index));
        //    }
        //    ViewData["UsuarioCreacion"] = new SelectList(_context.Usuarios, "IdUsuario", "IdUsuario", miembro.UsuarioCreacion);
        //    return View(miembro);
        //}

        //// GET: Miembroes/Delete/5
        //public async Task<IActionResult> Delete(int? id)
        //{
        //    if (id == null)
        //    {
        //        return NotFound();
        //    }

        //    var miembro = await _context.Miembros
        //        .Include(m => m.UsuarioCreacionNavigation)
        //        .FirstOrDefaultAsync(m => m.IdMiembro == id);
        //    if (miembro == null)
        //    {
        //        return NotFound();
        //    }

        //    return View(miembro);
        //}

        //// POST: Miembroes/Delete/5
        //[HttpPost, ActionName("Delete")]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> DeleteConfirmed(int id)
        //{
        //    var miembro = await _context.Miembros.FindAsync(id);
        //    if (miembro != null)
        //    {
        //        _context.Miembros.Remove(miembro);
        //    }

        //    await _context.SaveChangesAsync();
        //    return RedirectToAction(nameof(Index));
        //}

        //private bool MiembroExists(int id)
        //{
        //    return _context.Miembros.Any(e => e.IdMiembro == id);
        //}
    }
}
