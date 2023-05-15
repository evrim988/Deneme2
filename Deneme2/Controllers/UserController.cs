using Deneme.Application.Repositories;
using Deneme.Domain.Common;
using Deneme.Domain.Entities.Common;
using Deneme.Infastructure.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace Deneme.WebApp.Controllers
{
    public class UserController : Controller
    {
        public readonly IUserRepository _userRepository;

        public UserController(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public IActionResult Index()
        {
            return View();
        }

        public async Task<IActionResult> List()
        {
            return View(await _userRepository.GetList());
        }
        [HttpPost]
        public async Task<IActionResult> Add(User model)
        {
            if (!ModelState.IsValid)
                return View(model);

            var result = await _userRepository.Add(model);

            ViewBag.Result = result;

            return View(model);
        }
        [HttpPost]
        public async Task<IActionResult> Update(User model)
        {
            if (!ModelState.IsValid)
                return View(model);

            var result = await _userRepository.Update(model);

            ViewBag.Result = result;

            return View(model);
        }
    }
}
