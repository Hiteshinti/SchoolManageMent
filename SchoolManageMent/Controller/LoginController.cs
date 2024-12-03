using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Identity.Client.Platforms.Features.DesktopOs.Kerberos;
using Microsoft.IdentityModel.Tokens;
using SchoolManageMent.Models;
using System.IdentityModel.Tokens.Jwt;
using System.Net;
using System.Security.Claims;
using System.Text;

namespace SchoolManageMent.Controller
{
    [ApiController]
    public class LoginController : ControllerBase
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly IConfiguration _configuration;
        public LoginController
        (
            UserManager<AppUser> userManager,
            RoleManager<IdentityRole> roleManager,
            IConfiguration configuration
            
        )
        {
            _userManager = userManager;
            _roleManager = roleManager;
            _configuration = configuration;
        }
        [Route("Login/Index")]
        public IActionResult Index()
        {
            return Ok();
        }


        [Route("api/Login")]
        [HttpPost]
        public async Task<IActionResult> Login([FromBody]Login credential)
        { 
            RESPONSE rESPONSE = new RESPONSE(); 
            var user = await _userManager.FindByNameAsync(credential.email);
            if (user != null && await _userManager.CheckPasswordAsync(user, credential.password))
            {
                var userRoles = await _userManager.GetRolesAsync(user);

                var authClaims = new List<Claim>
                {
                    new Claim(ClaimTypes.Name, user.UserName),
                    new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                };

                foreach (var userRole in userRoles)
                {
                    authClaims.Add(new Claim(ClaimTypes.Role, userRole));
                }

                var token = GetToken(authClaims);

                rESPONSE.message = "login Successfully!!";
                rESPONSE.data = new
                {
                    token = new JwtSecurityTokenHandler().WriteToken(token),
                    expiration = token.ValidTo,
                    
                };

                return Ok(rESPONSE);
            }

            return Unauthorized();

        }

        private JwtSecurityToken GetToken(List<Claim> authClaims)
        {
            var authSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["JWT:Secret"]));

            var token = new JwtSecurityToken(
                issuer: _configuration["JWT:ValidIssuer"],
                audience: _configuration["JWT:ValidAudience"],
                expires: DateTime.Now.AddHours(1),
                claims: authClaims,
                signingCredentials: new SigningCredentials(authSigningKey, SecurityAlgorithms.HmacSha256)
                );

            return token;
        }
        
        [Authorize(Roles= "Teacher,Principal")]
        [Route("api/Profile")]
        [HttpGet]
        public async Task<IActionResult> Profile()
        {
            RESPONSE rESPONSE = new RESPONSE();
            rESPONSE.message = "profile fetched successfully";
            rESPONSE.data = this.User.Identity.Name;
            return Ok(rESPONSE);
        }

        [Route("api/UserName")]
        [HttpGet]
        public async Task<IActionResult>GetUSerName(string UserName)
        {
            RESPONSE rESPONSE = new RESPONSE();
            var user = await _userManager.FindByNameAsync(UserName);
            if (user == null)
                rESPONSE.data = true;
            else 
                rESPONSE.data = false;  

            return Ok(rESPONSE);

        }
    }
}
