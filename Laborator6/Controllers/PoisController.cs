using System;
using System.Threading.Tasks;
using BusinessLayer.Implementations;
using DataLayer;
using DataLayer.Entities;
using Laborator6.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Laborator6.Controllers
{
    public class PoisController : Controller
    {
        private readonly Repository _repo;

        public PoisController(PoiContext context)
        {
            _repo = new PoiRepository(context);
        }
        
        public async Task<IActionResult> Index()
        {
            return View(await _repo.GetAll<Poi>());
        }
        
        public async Task<IActionResult> Details(Guid id)
        {
            var poi = await _repo.GetById<Poi>(id);
            if (poi == null)
            {
                return NotFound();
            }

            return View(poi);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create([Bind("Id,Name,Description")] PoiViewModel poiModel)
        {
            if (ModelState.IsValid)
            {
                var poi = new Poi
                {
                    Id = Guid.NewGuid(),
                    Name = poiModel.Name,
                    Description = poiModel.Description

                };
                _repo.Create(poi);
                _repo.Save();
                return RedirectToAction(nameof(Index));
            }
            return View(poiModel);
        }

        public async Task<IActionResult> Edit(Guid id)
        {
            var poi = await _repo.GetById<Poi>(id);
            if (poi == null)
            {
                return NotFound();
            }

            PoiViewModel poiModel = new PoiViewModel
                               {
                                   Description = poi.Description,
                                   Name = poi.Name
                               };

            return View(poiModel);
        }
        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, [Bind("Id,Name,Description")] PoiViewModel poiModel)
        {
            if (id != poiModel.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                var poi = new Poi
                              {
                                  Id = poiModel.Id,
                                  Name = poiModel.Name,
                                  Description = poiModel.Description

                              };

                try
                {
                    _repo.Update(poi);
                    _repo.Save();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (! (await PoiExists(poiModel.Id)))
                    {
                        return NotFound();
                    }

                    throw;
                }
                return RedirectToAction(nameof(Index));
            }
            return View(poiModel);
        }
        
        public async Task<IActionResult> Delete(Guid id)
        {
            var poi = await _repo.GetById<Poi>(id);

            if (poi == null)
            {
                return NotFound();
            }

            PoiViewModel poiModel = new PoiViewModel
                                        {
                                            Description = poi.Description,
                                            Name = poi.Name
                                        };

            return View(poiModel);
        }
        
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            var todo = await _repo.GetById<Poi>(id);
            _repo.Delete(todo);
            _repo.Save();
            return RedirectToAction(nameof(Index));
        }

        private async Task<bool> PoiExists(Guid id)
        {
            var poi = await _repo.GetById<Poi>(id);
            if (poi == null)
            {
                return false;
            }

            return true;
        }
    }
}