using CDPModule1.Server.IServices;
using CDPModule1.Shared;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Data;

namespace CDPModule1.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TenantController : ControllerBase
    {
        private readonly ITenantService _tenantService;

        public TenantController(ITenantService tenantService)
        {
            _tenantService = tenantService;
        }

        [HttpGet]
        [Route("GetAllTenants")]
        [Authorize(Roles = Roles.Admin)]
        public  List<Tenant> GetAllTenants()
        {
            return  _tenantService.GetAllTenants().Result;
        }

        [HttpGet]
        [Route("GetTenantById")]
        [Authorize(Roles = Roles.Admin)]
        public Tenant GetTenantById([FromQuery] Guid Id)
        {
            return _tenantService.GetById(Id).Result;
        }
    }
}
