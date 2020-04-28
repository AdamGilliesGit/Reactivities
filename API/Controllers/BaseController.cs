using MediatR;
using Microsoft.Extensions.DependencyInjection;
using Mvc = Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Mvc.Route("api/[controller]")]
    [Mvc.ApiController]
    public class ControllerBase : Mvc.ControllerBase
    {
        private IMediator _mediator;
        protected IMediator Mediator => _mediator ?? (_mediator = HttpContext.RequestServices.GetService<IMediator>());
    }
}