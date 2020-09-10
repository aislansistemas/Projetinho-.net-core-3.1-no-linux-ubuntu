using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using testelinux.ViewModels;

namespace testelinux.Controllers
{
    public class AccountController : Controller
    {
        private readonly UserManager<IdentityUser> _userManager;
        private readonly SignInManager<IdentityUser> _signInManager;

        private readonly RoleManager<IdentityRole> _roleManeger;

        public AccountController(UserManager<IdentityUser> userManager,
         SignInManager<IdentityUser> signManager,
         RoleManager<IdentityRole> roleManeger)
        {
            _userManager = userManager;
            _signInManager = signManager;
            _roleManeger = roleManeger;
        }

        //implementar login, registro e logout
        public IActionResult Login(string returnUrl)
        {
            return View(new LoginViewModel()
            {
                ReturnUrl = returnUrl
            });
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginViewModel loginVM)
        {
            if (!ModelState.IsValid)
                return View(loginVM);

            var usuario = _userManager.FindByNameAsync(loginVM.UserName).Result;
            if (_userManager.CheckPasswordAsync(usuario, loginVM.Password).Result) {
                
                await _signInManager.SignInAsync(usuario,false);
                if (string.IsNullOrEmpty(loginVM.ReturnUrl))
                {
                    return RedirectToAction("Index", "Home");
                }
                return Redirect(loginVM.ReturnUrl);
                
            }
            

            ModelState.AddModelError("", "Usuário/Senha inválidos ou não localizados!!");
            return View(loginVM);
        }

        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Register(LoginViewModel registroVM)
        {
            if (ModelState.IsValid)
            {
                var user = new IdentityUser() { UserName = registroVM.UserName };
                var result = await _userManager.CreateAsync(user, registroVM.Password);

                if (result.Succeeded)
                {
                    //Adiciona o usuário padrão ao perfil Member
                    await _userManager.AddToRoleAsync(user, "admin");
                    await _signInManager.SignInAsync(user, isPersistent: false);

                    return RedirectToAction(nameof(Login));
                }
            }
            return View(registroVM);
        }

        public ViewResult LoggedIn() => View();

        [HttpPost]
        [Authorize]
        public async Task<IActionResult> Logout()
        {
            await _signInManager.SignOutAsync();
            return RedirectToAction("Index", "Home");
        }

        [HttpGet]
        public IActionResult CreateRoles(){
            return View();
        }

        [HttpPost,ActionName("CreateRoles")]
        public async Task<IActionResult> CreateRoles(string role){
            await _roleManeger.CreateAsync(new IdentityRole(role));
            return RedirectToAction(nameof(Login));
        }
    }
}