using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Identity.Client;
using SchoolManageMent.Models;

namespace SchoolManageMent.Controller
{
    public class RoleController : ControllerBase
    {
        private readonly RoleManager<IdentityRole> _roleManager; 
        public  RoleController(RoleManager<IdentityRole> roleManager) 
        {
            _roleManager = roleManager;
        }
        [Route("api/GetRolesForRegister")]
        [HttpGet]
        public IActionResult GetRolesForRegister()
        {
            var roles = _roleManager.Roles;

            RESPONSE rESPONSE = new RESPONSE();
            rESPONSE.status = "200";
            rESPONSE.message = "Roles fetched Successfully";
            rESPONSE.data = roles;

            return Ok(rESPONSE);

        }
    }
}
