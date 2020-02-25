using Microsoft.AspNetCore.Mvc;
using System.Linq;
using WhatsApp.Domain.UserModule;
using WhatsApp.Models.Main;
using RxWeb.Core.AspNetCore;
using RxWeb.Core.Security.Authorization;

namespace WhatsApp.Api.Controllers.UserModule
{
    [ApiController]
    [Route("api/[controller]")]
	
	public class UsersController : BaseDomainController<User,User>

    {
        public UsersController(IUserDomain domain):base(domain) {}

    }
}
