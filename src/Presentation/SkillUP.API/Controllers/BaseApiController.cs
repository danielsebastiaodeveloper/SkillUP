using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace SkillUP.API.Controllers;

[ApiController]
[Route("api/v{version:apiVersion}/[controller]")]
public abstract class BaseApiController : ControllerBase
{

}
