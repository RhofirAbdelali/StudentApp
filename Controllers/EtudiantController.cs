using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

public class EtudiantController : Controller
{
    private readonly ApplicationDbContext _context;

    public EtudiantController(ApplicationDbContext context)
    {
        _context = context;
    }

    // GET: Etudiant
    public async Task<IActionResult> Index()
    {
        return View(await _context.Etudiants.ToListAsync());
    }

    // GET: Etudiant/Create
    public IActionResult Create()
    {
        return View();
    }


    // POST: Etudiant/Create
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create(Etudiant etudiant)
    {
        if (ModelState.IsValid)
        {
            _context.Add(etudiant);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
        return View(etudiant);
    }



    // GET: Etudiant/Edit/{id}
    public async Task<IActionResult> Edit(int? id)
    {
        if (id == null) return NotFound();
        var etudiant = await _context.Etudiants.FindAsync(id);
        if (etudiant == null) return NotFound();
        return View(etudiant);
    }

    // POST: Etudiant/Edit/{id}
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Edit(int id, Etudiant etudiant)
    {
        if (id != etudiant.Id) return NotFound();
        if (ModelState.IsValid)
        {
            _context.Update(etudiant);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
        return View(etudiant);
    }

    // GET: Etudiant/Delete/{id}
    public async Task<IActionResult> Delete(int? id)
    {
        if (id == null) return NotFound();

        var etudiant = await _context.Etudiants.FirstOrDefaultAsync(m => m.Id == id);
        if (etudiant == null) return NotFound();

        return View(etudiant);
    }

    // POST: Etudiant/Delete/{id}
    [HttpPost, ActionName("Delete")]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> DeleteConfirmed(int id)
    {
        var etudiant = await _context.Etudiants.FindAsync(id);
        if (etudiant != null)
        {
            _context.Etudiants.Remove(etudiant);
            await _context.SaveChangesAsync();
        }
        return RedirectToAction(nameof(Index));
    }
}