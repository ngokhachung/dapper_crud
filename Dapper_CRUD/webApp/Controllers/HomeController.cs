using Microsoft.AspNetCore.Mvc;
using webApp.Models;
using webApp.Services;

namespace webApp.Controllers
{
    [Route("/api/[controller]")]
    public class HomeController : Controller
    {
        private readonly ICustomerService _customerService;

        public HomeController(ICustomerService customerService)
        {
            _customerService = customerService;
        }
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var result = await _customerService.GetAllAsync();
            return Ok(result);
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await _customerService.DeleteAsync(id);
            return Ok(result);
        }

        //Task<int> DeleteAsync(int id);
        //Task<IReadOnlyList<Customer>> GetAllAsync();
        //Task<Customer?> GetByIdAsync(int id);
        //Task<int> UpdateAsync(Customer entity)
    }
}
