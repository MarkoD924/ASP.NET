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
		public async Task<IActionResult> Index()
		{
			return View(await _context.Jelo.ToListAsync());
		}
	}
}
