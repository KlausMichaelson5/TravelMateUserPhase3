using AdminMvcUi.Services;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace AdminMvcUi.Controllers
{
    public class AdminUiController : Controller
    {
        private readonly IAdminService _adminService;

        public AdminUiController(IAdminService adminService)
        {
            _adminService = adminService;
        }

        public async Task<IActionResult> Index()
        {
            var users = await _adminService.GetAll();
            return View(users);
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(int id)
        {
            await _adminService.DeleteUser(id);
            return Ok();
        }
    }
}
