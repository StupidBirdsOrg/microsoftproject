using Microsoft.AspNetCore.Mvc;

namespace MyMicroservice.Controllers;


[ApiController]
[Route("api/[controller]")]
[Produces("javascript/json")]
public class BaseController : ControllerBase
{
}