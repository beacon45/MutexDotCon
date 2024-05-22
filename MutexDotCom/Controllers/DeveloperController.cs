using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MutexDotCom.Data;
using MutexDotCom.Data.Services.Abstract;
using MutexDotCom.Models;

namespace MutexDotCom.Controllers
{
    [Authorize(Roles = "Admin")]
    public class DeveloperController : Controller
    {
        private readonly IDeveloperService _service;
        public DeveloperController(IDeveloperService service)
        {
            _service = service;
        }
        public async Task<IActionResult> Index()
        {
            var data=await _service.GetAllAsync();
            return View(data);
        }
        
        //Get: Actors/Developer
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create([Bind("Name,ProfilePictureURL,Skills")] Developer developer)
        {
            if (ModelState.IsValid)
            {
                return View(developer);
            }
            await _service.CreateAsync(developer);
            return RedirectToAction("Index");
        }
        
        //Get: Developers/Details/id
        public async Task<IActionResult> Details(int id)
        {
            var devDetails = await _service.GetByIdAsync(id);

            if (devDetails == null) return View("NotFound");
            return View(devDetails);
        }

        //Get: Developers/Edit/id
        public async Task<IActionResult> Edit(int id)
        {
            var devDetails = await _service.GetByIdAsync(id);
            if (devDetails == null)
            {
                return View("NotFound");
            }
            return View(devDetails);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,ProfilePictureURL,Skills")] Developer developer)
        {
            if (ModelState.IsValid)
            {
                return View(developer);
            }
            await _service.UpdateAsync(id, developer);
            return RedirectToAction(nameof(Index));
        }

        //Get: Developer/Delete/id
        public async Task<IActionResult> Delete(int id)
        {
            var devDetails = await _service.GetByIdAsync(id);
            if (devDetails == null) return View("NotFound");
            return View(devDetails);
        }
        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var devDetails = await _service.GetByIdAsync(id);
            if (devDetails == null) return View("NotFound");

            await _service.DeleteAsync(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
