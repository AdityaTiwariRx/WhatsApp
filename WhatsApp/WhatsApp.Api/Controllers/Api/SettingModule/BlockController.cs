using Microsoft.AspNetCore.Mvc;
using System.Linq;
using WhatsApp.Domain.SettingModule;
using WhatsApp.Models.Main;
using RxWeb.Core.AspNetCore;
using RxWeb.Core.Security.Authorization;
using WhatsApp.Models.ViewModels;

namespace WhatsApp.Api.Controllers.SettingModule
{
    [ApiController]
    [Route("api/[controller]")]
	
	public class BlockController : BaseDomainController<BlockedUser,BlockedUser>

    {
        public BlockController(IBlockDomain domain):base(domain) {}

    }
}
