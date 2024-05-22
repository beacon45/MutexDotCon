using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MutexDotCom.Data;
using MutexDotCom.Data.Services.Abstract;
using MutexDotCom.Models;

namespace MutexDotCom.Controllers
{
    [Authorize(Roles = "Admin")]
    public class DepartmentController : Controller
    {
        private readonly IDepartmentService _service;
        public DepartmentController(IDepartmentService service)
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
        public async Task<IActionResult> Create([Bind("Name,Logo,Description")] Department department)
        {
            if (ModelState.IsValid)
            {
                return View(department);
            }
            await _service.CreateAsync(department);
            return RedirectToAction("Index");
        }
        //Get: Departments/Details/id
        public async Task<IActionResult> Details(int id)
        {
            var devDetails = await _service.GetByIdAsync(id);

            if (devDetails == null) return View("NotFound");
            return View(devDetails);
        }

        //Get: Departments/Edit/id
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
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,Logo,Description")] Department department)
        {
            if (ModelState.IsValid)
            {
                return View(department);
            }
            await _service.UpdateAsync(id, department);
            return RedirectToAction(nameof(Index));
        }
        //Get: Department/Delete/id
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
