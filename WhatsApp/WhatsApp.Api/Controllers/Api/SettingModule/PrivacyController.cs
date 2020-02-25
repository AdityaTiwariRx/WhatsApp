using Microsoft.AspNetCore.Mvc;
using System.Linq;
using WhatsApp.Domain.SettingModule;
using WhatsApp.Models.Main;
using RxWeb.Core.AspNetCore;
using RxWeb.Core.Security.Authorization;

namespace WhatsApp.Api.Controllers.SettingModule
{
    [ApiController]
    [Route("api/[controller]")]
	
	public class PrivacyController : BaseDomainController<Privacy,Privacy>

    {
        public PrivacyController(IPrivacyDomain domain):base(domain) {}

    }
}
