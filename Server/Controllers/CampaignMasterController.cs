using CDPModule1.Shared.View_Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Phoenix_Deloitte.Server;
using CDPModule1.Shared;
using CDPModule1.Shared.View_Model;
using CDPModule1.Server;
using CDPModule1.Server.Interface;

namespace Phoenix_Deloitte.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CampaignMasterController : ControllerBase
    {
        private readonly CDPDbContext _context;
        private readonly ICampaign _compaign;
        public CampaignMasterController(CDPDbContext context, ICampaign campaign)
        {
            _context = context;
            _compaign = campaign;
        }
        [HttpGet("GetMarkets")]
        public  IActionResult GetMarkets()
        {
            try
            {
                var Mlist = _compaign.GetMarketList();
                return Ok(Mlist);
            }
            catch (Exception er)
            {
                return BadRequest(er.Message);
            }

        }
        [HttpGet("GetMarketMaster")]
        public IActionResult GetMarketMaster()
        {
            try
            {
                var Tlist = _compaign.GetselectedMarketList();
                return Ok(Tlist);
            }
            catch (Exception er)
            {
                return BadRequest(er.Message);
            }
        }
        [HttpGet("GetTargets")]
        public  IActionResult GetTargets()
        {

            try
            {
                var Tlist = _compaign.GetTargetList();
                return Ok(Tlist);
            }
            catch (Exception er)
            {
                return BadRequest(er.Message);
            }
        }
        [HttpGet("GetTargetMaster")]
        public IActionResult GetTargetMaster()
        {
            try
            {
                var Tlist = _compaign.GetselectedTargetList();
                return Ok(Tlist);
            }
            catch (Exception er)
            {
                return BadRequest(er.Message);
            }
        }
        [HttpGet("GetBrands")]
        public IActionResult GetBrands()
        {
            try
            {
                var Brands = _compaign.GetBrandList();
                return Ok(Brands);
            }
            catch (Exception er)
            {
                return BadRequest(er.Message);
            }
        }

        [HttpPost("SaveCampaigning")]
        public  IActionResult SaveCampaigning(CampaignView requestData)
        {
            try
            {
                bool status =  _compaign.SaveCampaign(requestData);
                return Ok(status);
            }
            catch (Exception er)
            {
                return BadRequest(er.Message);
            }
        }

        [HttpGet("GetCampaign")]
        public IActionResult GetCampaign()
        {
            try
            {
                var campaigns = _compaign.GetCampaignlist();
                return Ok(campaigns);
            }
            catch (Exception er)
            {
                return BadRequest(er.Message);
            }
        }
    }
}
