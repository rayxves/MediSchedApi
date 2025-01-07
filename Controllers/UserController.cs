
using MediSchedApi.Data;
using MediSchedApi.Dtos;
using MediSchedApi.Dtos.User;
using MediSchedApi.Interfaces;
using MediSchedApi.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;


namespace MediSchedApi.Controller
{
    [Route("/user")]
    [ApiController]

    public class UserController : ControllerBase
    {
        private readonly UserManager<User> _userManager;
        private readonly ITokenService _tokenService;
        private readonly SignInManager<User> _signInManager;
        private readonly RoleManager<Role> _roleManager;
        private readonly ApplicationDBContext _context;

        public UserController(UserManager<User> userManager, ITokenService tokenService, SignInManager<User> signInManager, RoleManager<Role> roleManager, ApplicationDBContext context)
        {
            _userManager = userManager;
            _tokenService = tokenService;
            _signInManager = signInManager;
            _roleManager = roleManager;
            _context = context;
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] RegisterDto registerDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var role = await _roleManager.FindByNameAsync(registerDto.Role);
            if (role == null)
            {
                return BadRequest("Role não encontrada.");
            }

            var user = new User
            {
                UserName = registerDto.UserName,
                Email = registerDto.Email,
                Role = role
            };

            var result = await _userManager.CreateAsync(user, registerDto.Password);
            if (!result.Succeeded)
            {
                return BadRequest(result.Errors);
            }


            await _userManager.AddToRoleAsync(user, registerDto.Role);

            return Ok(new NewUserDto
            {
                UserName = user.UserName,
                Email = user.Email,
                Role = registerDto.Role,
                Token = _tokenService.CreateToken(user)
            });
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login(LoginDto loginDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var user = await _userManager.Users.FirstOrDefaultAsync(u => u.UserName.ToLower() == loginDto.UserName.ToLower());

            if (user == null)
            {
                return Unauthorized("Invalid username!");
            }

            var result = await _signInManager.CheckPasswordSignInAsync(user, loginDto.Password, false);
            if (!result.Succeeded)
            {
                return Unauthorized("Username not found and/or password!");
            }

            var role = await _roleManager.FindByIdAsync(user.RoleId);
            if (role == null)
            {
                return Unauthorized("Role not found for this user!");
            }

            if (role.Name == "Medico")
            {
                var doctorSpecialty = new DoctorSpecialty{
                    UserId = user.Id,
                    SpecialtyId = 10
                };
                _context.DoctorSpecialties.Add(doctorSpecialty);
                await _context.SaveChangesAsync();
            }
            return Ok(new NewUserDto
            {
                UserName = user.UserName,
                Email = user.Email,
                Role = role.Name,
                Token = _tokenService.CreateToken(user)
            });
        }

        [Authorize(Roles = "Adm")]
        [HttpDelete("{name}")]
        public async Task<IActionResult> DeleteUser(string name)
        {


            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (string.IsNullOrEmpty(name))
            {
                return BadRequest("Nome não fornecido.");
            }

            var user = await _userManager.Users.FirstOrDefaultAsync(u => u.UserName.ToLower() == name.ToLower());

            if (user == null)
            {
                return NotFound("Usuário não encontrado.");
            }

            var result = await _userManager.DeleteAsync(user);
            if (!result.Succeeded)
            {
                return BadRequest("Erro ao deletar o usuário.");
            }

            return Ok("Usuário deletado com sucesso.");
        }

        [Authorize(Roles = "Adm")]
        [HttpGet("{role}")]
        public async Task<IActionResult> GetUsersByRole(string role)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (string.IsNullOrEmpty(role))
            {
                return BadRequest("Role não fornecida.");
            }

            var roleFound = await _roleManager.FindByNameAsync(role);
            if (roleFound == null)
            {
                return NotFound("Role não encontrada.");
            }

            var users = await _userManager.GetUsersInRoleAsync(role);
            if (users == null || users.Count == 0)
            {
                return NotFound("Usuários não encontrados.");
            }

            var userDtos = users.Select(user => new NewUserDto
            {
                UserName = user?.UserName,
                Email = user?.Email,
                Role = role,
            }).ToList();

            return Ok(userDtos);
        }

    }
}