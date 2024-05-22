using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MutexDotCom.Data;
using MutexDotCom.Data.Services.Abstract;
using MutexDotCom.Data.ViewModels;

namespace MutexDotCom.Controllers
{
    public class ProjectController : Controller
    {
        private readonly IProjectService _service;
        public ProjectController(IProjectService service)
        {
            _service = service;  
        }
        [AllowAnonymous]
        public async Task<IActionResult> Index()
        {
            var data = await _service.GetAllAsync(n=>n.Department);
            return View(data);
        }
        [AllowAnonymous]
        public async Task<IActionResult> Details(int id)
        {
            var data = await _service.GetProjectByIdAsync(id);
            return View(data);
        }
        
        //GET/Project/Create/id
        public async Task<IActionResult> Create()
        {
            var data = await _service.GetProjectServiceValues();

            ViewBag.Departmnets = new SelectList(data.Departments, "Id", "Name");
            ViewBag.Managers = new SelectList(data.Managers, "Id", "Name");
            ViewBag.Developers = new SelectList(data.Developers, "Id", "Name");

            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(NewProjectVM project)
        {
            if(!ModelState.IsValid)
            {
                var data = await _service.GetProjectServiceValues();


                ViewBag.Departments = new SelectList(data.Departments, "Id", "Name");
                ViewBag.Managers = new SelectList(data.Managers, "Id", "Name");
                ViewBag.Developers = new SelectList(data.Developers, "Id", "Name");

                return View(project);
            }
            await _service.AddNewProjectAsync(project);
            return RedirectToAction(nameof(Index));
        }
        
        //GET/Project/Edit/id
        public async Task<IActionResult> Edit(int id)
        {
            var data= await _service.GetProjectByIdAsync(id);

            var res = new NewProjectVM()
            {
                Id = data.Id,
                Name = data.Name,
                ProbelemStatement = data.ProbelemStatement,
                ClientName = data.ClientName,
                ImageURL = data.ImageURL,
                InitialDate = data.InitialDate,
                EndDate = data.EndDate,
                DepartmentIds=data.DepartmentId,
                ManagerIds=data.ManagerId,
                DevelopersIds=data.DevProjects.Select(n=>n.DevId).ToList(),
            };

            var projectDD = await _service.GetProjectServiceValues();
            ViewBag.Departments = new SelectList(projectDD.Departments, "Id", "Name");
            ViewBag.Managers = new SelectList(projectDD.Managers, "Id", "Name");
            ViewBag.Developers = new SelectList(projectDD.Developers, "Id", "Name");
            return View(res);
        }
        [HttpPost]
        public async Task<IActionResult> Edit(int id, NewProjectVM project)
        {
            if (id != project.Id) return View("NotFound");

            if (!ModelState.IsValid)
            {
                var projectDD = await _service.GetProjectServiceValues();
                ViewBag.Departments = new SelectList(projectDD.Departments, "Id", "Name");
                ViewBag.Managers = new SelectList(projectDD.Managers, "Id", "Name");
                ViewBag.Developers = new SelectList(projectDD.Developers, "Id", "Name");

                return View(project);
            }
            await _service.UpdateProjectAsync(project);
            return RedirectToAction(nameof(Index));
        }
        public async Task<IActionResult> Filter(string searchString)
        {
            var data = await _service.GetAllAsync(n => n.Department);

            if (!string.IsNullOrEmpty(searchString))
            {
                var filterRes = data.Where(n => string.Equals(n.Name, searchString, StringComparison.CurrentCultureIgnoreCase) || string.Equals(n.ProbelemStatement, searchString, StringComparison.CurrentCultureIgnoreCase)).ToList();
                return View("Index", filterRes);
            }

            return View("Index", data);
        }

    }
}
