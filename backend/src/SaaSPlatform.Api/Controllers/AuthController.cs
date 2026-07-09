using Microsoft.AspNetCore.Mvc;
using SaaSPlatform.Api.Dtos;

namespace SaaSPlatform.Api.Controllers;

[ApiController]
[Route("api/auth")]
public class AuthController : ControllerBase
{
    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        return;
    }

    [HttpPost]
    public async Task<IActionResult> Create(RegisterTenantRequest request)
    {
        return request;
    }
    
}