using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using SchoolManageMent.IRepository;
using SchoolManageMent.Models;  

namespace SchoolManageMent.Controller
{

    [ApiController]
    public class RegisterController : ControllerBase
     {
        //private readonly IUserRepository _userRepository;
        private readonly UserManager<AppUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        private  readonly ILogger<RegisterController> _logger;


        public RegisterController
        (
            
            UserManager<AppUser> userManager,
            RoleManager<IdentityRole> roleManager,
            ILogger<RegisterController> logger
        )
        {
           
            _userManager = userManager;
            _roleManager = roleManager;
            _logger = logger;



        }

        [Route("api/CreateUser")]
        [HttpPost]
        public async Task<IActionResult> CreateUser([FromBody] AppUser user , string RoleName)
        {
            RESPONSE rESPONSE = new RESPONSE();
            try
            {
               
                if (ModelState.IsValid)
                {
                    user.UserName = user.Email;
                    var data = await _userManager.CreateAsync(user,user.Password);


                    if (data.Succeeded)
                    {
                        var result = await _userManager.AddToRoleAsync(user, RoleName);

                        if (result.Succeeded)
                        {

                            rESPONSE.message = "User Cerated Successfully";
                            rESPONSE.status = "200";
                        }
                        else
                        {
                            rESPONSE.message = "User Added Succssfulley  failed to create Role for User!";
                            rESPONSE.status = "200";
                        }
                    }
                }
                else
                {
                    string erromesge = "";
                    foreach (var error in ModelState.Values)
                    {
                        erromesge = erromesge + error.ToString() + ",";
                    }
                    rESPONSE.message = erromesge;
                    rESPONSE.status = "200";
                }
                return Ok(rESPONSE);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                rESPONSE.message = ex.Message;
                rESPONSE.status = "200";
                return Ok(rESPONSE);
            }
        }
    }
}
