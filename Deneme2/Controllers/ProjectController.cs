using Deneme.Application.Repositories;
using Deneme.Domain.Entities.Common;
using Deneme.Infastructure.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace Deneme.WebApp.Controllers
{
    public class ProjectController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public readonly IProjectRepository _projectRepository;

        public ProjectController(IProjectRepository projectRepository)
        {
            _projectRepository = projectRepository;
        }

        public async Task<IActionResult> List()
        {
            return View(await _projectRepository.GetList());
        }

        public async Task<IActionResult> Add(Project model)
        {
            if (!ModelState.IsValid)
                return View(model);

            var result = await _projectRepository.Add(model);

            ViewBag.result = result;

            return View(model);
        }
    }
}
