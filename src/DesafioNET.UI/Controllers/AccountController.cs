using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using DesafioNET.Services;
using DesafioNET.Services.Exceptions;
using DesafioNET.Services.Models;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;

namespace DesafioNET.UI.Controllers
{
    public class AccountController : BaseController
    {
        private readonly IAuthService _auth;

        public AccountController(IAuthService auth)
        {
            _auth = auth;
        }

        [HttpGet]
        [AllowAnonymous]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(LoginDTO dto)
        {
            var user = await _auth.TryLoginAsync(dto.Email, dto.Password);

            if(user == null)
            {
                ModelState.AddModelError("","Tentativa de login inválida");
                return View(dto);
            }

            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.Email, user.Email),
                new Claim(ClaimTypes.Name, user.Name),
                new Claim(ClaimTypes.NameIdentifier, user.UserId.ToString())
            };

            var identity = new ClaimsIdentity(claims, "DesafioNetAuth");

            var userPrincipal = new ClaimsPrincipal(identity);

            await HttpContext.SignInAsync(userPrincipal);

            return RedirectToAction("Index", "Home");

        }

        [HttpGet]
        [AllowAnonymous]
        public IActionResult Recover()
        {
            return View();
        }

        [HttpPost]
        [AllowAnonymous]
        public IActionResult Recover(RecoveryDTO dto)
        {
            return View();
        }

        [HttpGet]
        [AllowAnonymous]
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        [AllowAnonymous]
        public IActionResult Register(RegisterDTO dto)
        {
            try
            {
                var res = _auth.Register(dto.Name, dto.Email, dto.Password);

                _auth.Save();
                
                return RedirectToAction("Login");
            }
            catch (Exception e)
            {
                ModelState.AddModelError("", e.Message);
                return View(dto);
            }
           
            
        }

        public IActionResult LogOut()
        {
            HttpContext.SignOutAsync();

            return RedirectToAction("Login");
        }

    }
}
