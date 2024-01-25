using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BearerJWT.Controllers;

[Route("auth")]
[AllowAnonymous]
public class AuthorizationController : ControllerBase
{
    private readonly ILogger<AuthorizationController> _logger;

    public AuthorizationController(ILogger<AuthorizationController> logger)
    {
        _logger = logger;
    }

    [HttpPost]
    public IActionResult Post([FromBody] UserLoginDto user)
    {
        string token = new JwtTokenFactory().CreateToken(user);
        return Ok(token);
    }
}