using Microsoft.AspNetCore.Mvc;
using movieTickets.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace movieTickets.Controllers
{
    public class ActrosController : Controller
    {
        private readonly AppDbContext _context;

        public ActrosController(AppDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var data = _context.Actors.ToList();
            return View();
        }
    }
}
