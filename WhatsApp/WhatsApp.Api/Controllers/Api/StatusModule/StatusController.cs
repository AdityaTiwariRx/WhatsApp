using Microsoft.AspNetCore.Mvc;
using System.Linq;
using WhatsApp.Domain.StatusModule;
using WhatsApp.Models.Main;
using RxWeb.Core.AspNetCore;
using RxWeb.Core.Security.Authorization;

namespace WhatsApp.Api.Controllers.StatusModule
{
    [ApiController]
    [Route("api/[controller]")]
	
	public class StatusController : BaseDomainController<Status,Status>

    {
        public StatusController(IStatusDomain domain):base(domain) {}

    }
}
