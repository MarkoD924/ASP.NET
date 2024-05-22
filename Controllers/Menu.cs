using Microsoft.AspNetCore.Mvc;
using Menu.Data;
using Menu.Models;
using Microsoft.EntityFrameworkCore;

namespace Menu.Controllers
{
	public class Menu : Controller
	{
		private readonly MenuContekst _context;
		public Menu(MenuContekst context)
		{
			_context = context;
		}
		public async Task<IActionResult> Index(string searchString)
		{
			var jelo = from j in _context.Jelo
					   select j;
			if (!string.IsNullOrEmpty(searchString))
			{
				jelo=jelo.Where(j=>j.Ime.Contains(searchString));
                return View(await jelo.ToListAsync());
            }

			return View(await jelo.ToListAsync());
		}
		public async Task<IActionResult> Details(int? id)
		{
			var Jelo = await _context.Jelo.Include(di => di.SastojakJela)
				.ThenInclude(s => s.Sastojak)
				.FirstOrDefaultAsync(x => x.Id == id);
			if(Jelo == null)
			{
				return NotFound();
			}

			return View(Jelo);

		}
	}
}
