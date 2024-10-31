using Common.Entity;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using Service.Interfaces;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace commemorative_project.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController: ControllerBase
    {
        private readonly ILoginService service;
        private IConfiguration configuration;
        public UserController(IConfiguration configuration, ILoginService service)
        {
            this.service = service;
            this.configuration = configuration;
        }

        private async Task<UserDetailesDto> Authenticate(string Email, string Password)
        {
            return service.Login(Email, Password);
        }

        private string Generate(UserDetailesDto user)
        {
            var securitykey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["Jwt:Key"]));
            var credentials = new SigningCredentials(securitykey, SecurityAlgorithms.HmacSha256);
  
            var claims = new[] {
            new Claim(ClaimTypes.Email,user.Email),
            new Claim(ClaimTypes.GivenName,user.Name),
            new Claim(ClaimTypes.GroupSid,user.Amount_stories.ToString()),
            new Claim(ClaimTypes.Surname,user.Id_person),//היה כתוב surName
            new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()), // החלף את Id עם תכונת מזהה המשתמש בפועל

            };
            var token = new JwtSecurityToken(configuration["Jwt:Issuer"], configuration["Jwt:Audience"],
                claims,

                expires: DateTime.Now.AddMinutes(15),
                signingCredentials: credentials);
            return new JwtSecurityTokenHandler().WriteToken(token);
        }

        [HttpGet]
        public async Task<List<UserDetailesDto>> Get()
        {
            return await service.getAllAsync();
        }

        [HttpGet("{id}")]
        public async Task<UserDetailesDto> Get(int id)
        {
            return await service.getAsync(id);
        }

        [HttpPost]
        public async Task<ActionResult> Post([FromBody] UserDetailesDto user)
        {
           return Ok(await service.AddAsync(user));
        }

        [HttpPost("/login")]
        public async Task<ActionResult> Login([FromBody] UserDetailesDto user)
        {
            UserDetailesDto u = await Authenticate(user.Email, user.Id_person);
            if (u != null)
            {
                var token = Generate(u);
                return Ok(token);
            }
            return NotFound("user not found");
        }


        [HttpPut("{id}")]
        [Authorize]
        public async Task<IActionResult> Put(int id, [FromBody] UserDetailesDto u)
        {
            await service.updateAsync(id,u);
            return Ok();
        }
        



        [HttpDelete("{id}")]
        public async Task Delete(int id)
        {
            await service.deleteAsync(id);
        }
    }
}
