using System.Threading.Tasks;
using DomainBusinessLogic.Interfaces;
using DomainBusinessLogic.Models;
using Entities;
using Microsoft.AspNetCore.Mvc;

namespace UserManagement.WebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserManagementController : ControllerBase
    {
        private readonly IUserManager _userManager;

        public UserManagementController(IUserManager userManager)
        {
            _userManager = userManager;
        }

        [HttpPost]
        [Route("[action]")]
        public Task RegisterMrGreenUser([FromBody] MrGreenUser user)
        {
            return _userManager.RegisterUser(user);
        }
        
        [HttpPost]
        [Route("[action]")]
        public Task RegisterRedBetUser([FromBody] RedBetUser user)
        {
            return _userManager.RegisterUser(user);
        }

        [HttpGet]
        [Route("[action]")]
        public async Task<IActionResult> GetAllUsers([FromQuery] PaginationFilter filter)
        {
            var users = await _userManager.GetAllUsersAsync(filter);

            return this.Ok(users);
        }
    }
}