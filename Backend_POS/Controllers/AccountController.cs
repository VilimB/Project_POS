﻿using Backend_POS.Interfaces;
using Backend_POS.Models.DbSet;
using Backend_POS.Models.DTO.Account;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

[Route("api/account")]
[ApiController]
public class AccountController : ControllerBase
{
    private readonly UserManager<User> _userManager;
    private readonly ITokenService _tokenService;
    private readonly SignInManager<User> _signInManager;

    public AccountController(UserManager<User> userManager, ITokenService tokenService, SignInManager<User> signInManager)
    {
        _userManager = userManager;
        _tokenService = tokenService;
        _signInManager = signInManager;
    }

    [HttpPost("login")]
    public async Task<IActionResult> Login(LoginDTO loginDTO)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState);

        var user = await _userManager.Users.FirstOrDefaultAsync(x => x.UserName == loginDTO.Username.ToLower());

        if (user == null)
            return Unauthorized("Nevažeće korisničko ime!");

        var result = await _signInManager.CheckPasswordSignInAsync(user, loginDTO.Password, false);

        if (!result.Succeeded)
            return Unauthorized("Korisničko ime nije pronađeno i/ili lozinka je netočna");

        var token = _tokenService.CreateToken(user);

        return Ok(new { Token = token });
    }

    [HttpPost("register")]
    public async Task<IActionResult> Register([FromBody] RegisterDTO registerDTO)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState);

        var user = new User
        {
            UserName = registerDTO.Username,
            Email = registerDTO.Email,
        };

        var createdUser = await _userManager.CreateAsync(user, registerDTO.Password);

        if (createdUser.Succeeded)
        {
            var roleResult = await _userManager.AddToRoleAsync(user, "USER");

            if (roleResult.Succeeded)
            {
                var token = _tokenService.CreateToken(user);
                return Ok(new { Token = token });
            }
            else
            {
                return StatusCode(500, roleResult.Errors);
            }
        }
        else
        {
            return StatusCode(500, createdUser.Errors);
        }
    }
}

