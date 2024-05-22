using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MutexDotCom.Data;
using MutexDotCom.Data.Services.Abstract;
using MutexDotCom.Models;

namespace MutexDotCom.Controllers
{
    [Authorize(Roles = "Admin")]
    public class ManagerController : Controller
    {
        private readonly IManagerService _service;
        public ManagerController(IManagerService service)
        {
            _service = service;
        }
        public async Task<IActionResult> Index()
        {
            var data = await _service.GetAllAsync();
            return View(data);
        }
        //Get: Manager/create
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create([Bind("Name,ProfilePictureURL,Description")] Manager manager)
        {
            if (ModelState.IsValid)
            {
                return View(manager);
            }
            await _service.CreateAsync(manager);
            return RedirectToAction("Index");
        }
        //Get: Manager/Details/id
        public async Task<IActionResult> Details(int id)
        {
            var devDetails = await _service.GetByIdAsync(id);

            if (devDetails == null) return View("NotFound");
            return View(devDetails);
        }
        //Get: Manager/Edit/id
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
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,ProfilePictureURL,Description")] Manager manager)
        {
            if (ModelState.IsValid)
            {
                return View(manager);
            }
            await _service.UpdateAsync(id, manager);
            return RedirectToAction(nameof(Index));
        }
        //Get: Manager/Delete/id
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
