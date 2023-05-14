using Deneme.Domain.Common;
using Deneme.Persistence.Repositories.CustomerRepository.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace Deneme.WebApp.Controllers
{
    public class CustomerController : Controller
    {
        private readonly ICustomerRepository _customerRepository;
        public CustomerController(ICustomerRepository customerRepository)
        {
            _customerRepository = customerRepository;
        }

        public async Task<IActionResult> List()
        {
            return View(await _customerRepository.GetList());
        }

        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Add(Customer model)
        {
            if (!ModelState.IsValid)
                return View(model);

            var result = await _customerRepository.Add(model);

            ViewBag.Result = result;

            return View(model);
        }


        public async Task<IActionResult> Update(int id)
        {
            var customer = await _customerRepository.GetById(id);

            if (customer.ResultObject == null)
                return RedirectToAction(nameof(List));

            return View(customer.ResultObject);
        }

        [HttpPost]
        public async Task<IActionResult> Update(Customer model)
        {
            if (!ModelState.IsValid)
                return View(model);

            var result = await _customerRepository.Update(model);

            ViewBag.Result = result;

            return View(model);
        }
    }
}
