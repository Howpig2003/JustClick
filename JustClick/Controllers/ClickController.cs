using JustClick.Data;
using JustClick.Models.ClickCounter;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;

namespace JustClick.Controllers
{
    public class ClickController : Controller
    {
        private readonly AppDbContext _context;

        public ClickController(AppDbContext AppDbContext)
        {
            _context = AppDbContext;
        }
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var counter = await _context.ClickCounters.FirstOrDefaultAsync(c => c.Id == 1);
            if (counter == null)
            {
                counter = new ClickCounter { Id = 1, TotalClickCount = 0, LastClickTime = DateTime.Now };
                _context.ClickCounters.Add(counter);
                await _context.SaveChangesAsync();
            }
            return View(counter);
        }

        [HttpPost]
        public async Task<IActionResult> RecordClick()
        {
            var counter = await _context.ClickCounters.FirstOrDefaultAsync(c => c.Id == 1);
            if (counter != null)
            {
                counter.TotalClickCount++;
                counter.LastClickTime = DateTime.Now;
                await _context.SaveChangesAsync();
                return Json(new { success = true, totalClickCount = counter.TotalClickCount });
            }
            return Json(new { success = false, message = "計數器未找到" });
        }
    }
}
