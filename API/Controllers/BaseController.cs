using Microsoft.AspNetCore.Mvc;
using MediatR;

namespace API.Controllers;

public class BaseController : Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class ApiBaseController : ControllerBase
    {
        private ISender _mediator = null!;
        protected ISender Mediator => _mediator ??= HttpContext.RequestServices.GetRequiredService<ISender>();
    }
}