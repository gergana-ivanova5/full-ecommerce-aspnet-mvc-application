using Microsoft.AspNetCore.Mvc;
using movieTickets.Data;
using movieTickets.Data.Services;
using movieTickets.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace movieTickets.Controllers
{
    public class ActorsController : Controller
    {
        private readonly IActorsService _service;

        public ActorsController(IActorsService service)
        {
            _service = service;
        }

        public async Task<IActionResult> Index()
        {
            var data = await _service.GetAllAsync();
            return View(data);
        }

        //Get: Actors/Create
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create([Bind("FullName, ProfilePictureURL, Bio")] Actor actor)
        {
            if (!ModelState.IsValid)
            {
                return View(actor);
            }
            await _service.AddAsync(actor);
            return RedirectToAction(nameof(Index));
        }

        //Get: Actors/Details/1
        public async Task<IActionResult> Details(int id)
        {
            //we need to check if an actor with that id exists in our database
            var actorDetails = await _service.GetByIdAsync(id);

            //we check if the actor is known
            if (actorDetails == null) return View("NotFound");
            return View(actorDetails);
        }

        //Get: Actors/Edit/1
        public async Task<IActionResult> Edit(int id)
        {
            //we need to check if an actor with that id exists in our database
            var actorDetails = await _service.GetByIdAsync(id);

            //we check if the actor is known
            if (actorDetails == null) return View("NotFound");
            return View(actorDetails);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(int id, Actor actor)
        {
            if (!ModelState.IsValid)
            {
                return View(actor);
            }

            await _service.UpdateAsync(id, actor);
            return RedirectToAction(nameof(Index));

        }
        //Get: Actors/Delete/1
        public async Task <IActionResult> Delete(int id)
        {
          //we need to check if an actor with that id exists in our database
          var actorDetails = await _service.GetByIdAsync(id);

          //we check if the actor is known
         if (actorDetails == null) return View("NotFound");
         return View(actorDetails);
         }

        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
          var actorDetails = await _service.GetByIdAsync(id);
          if (actorDetails == null) return View("NotFound");

          await _service.DeleteAsync(id); //може и да се предаде actorDetails като параметър
          return RedirectToAction(nameof(Index));

        }
    }
}