using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using movieTickets.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace movieTickets.Controllers
{
    public class ProducersController : Controller
    {
        private readonly AppDbContext _context;

        public ProducersController(AppDbContext context)
        {
            _context = context;
        }
        /* public IActionResult Index() //синхронно взимане на списъка с продуценти
        {
            var allProducers = _context.Producers.ToList();
            return View();
        }*/ 

        public async Task<IActionResult> Index() //асинхронно взимане на списъка с продуценти
        {
            var allProducers = await _context.Producers.ToListAsync();
            return View();
        }
    }
}
