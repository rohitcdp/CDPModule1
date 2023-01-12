using Microsoft.EntityFrameworkCore;
using Phoenix_Deloitte.Server;
using CDPModule1.Shared;
using CDPModule1.Shared;
using CDPModule1.Shared.View_Model;
using CDPModule1.Server;
using CDPModule1.Shared.Model;
using CDPModule1.Server.Interface;

namespace CDPModule1.Server.Service
{
    public class CampaignService : ICampaign
    {
        private readonly CDPDbContext _context;
        public CampaignService(CDPDbContext context)
        {
            _context=context;
        }
           
        public  IEnumerable<Brand> GetBrandList()
        {
            try
            {
                var res = _context.brands.ToList();
                return res;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message + ex.InnerException);
            }
        }

        public IEnumerable<CampaignMaster> GetCampaignlist()
        {
            try
            {
                var res = _context.campaigns.ToList();
                return res;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message + ex.InnerException);
            }
        }

        public  IEnumerable<Market> GetMarketList()
        {
            try
            {
                var res =  _context.markets.ToList();
                return res;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message + ex.InnerException);
            }
        }

        public IEnumerable<MarketMaster> GetselectedMarketList()
        {
            try
            {
                var res = _context.marketMasters.ToList();
                return res;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message + ex.InnerException);
            }
        }

        public IEnumerable<TargetMaster> GetselectedTargetList()
        {
            try
            {
                var res = _context.targetMasters.ToList();
                return res;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message + ex.InnerException);
            }
        }

        public  IEnumerable<Shared.Model.Target> GetTargetList()
        {
            try
            {
                var res =  _context.targets.ToList();
                return res;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message + ex.InnerException);
            }
        }

        public bool SaveCampaign(CampaignView obj)
        {
            try
            {
                CampaignMaster campaignMaster = new CampaignMaster();
                campaignMaster.BrandId = Convert.ToInt32(obj.BrandName);
                campaignMaster.Fromdate = obj.Fromdate.ToString();
                campaignMaster.Todate = obj.Todate.ToString();
                campaignMaster.Duration = obj.Duration;
                campaignMaster.CampaignName=obj.CampaignName;
                _context.campaigns.Add(campaignMaster);
                _context.SaveChanges();
                //------------Target save------------------
                TargetMaster targetMaster = new TargetMaster();
                foreach (var items in obj.Target)
                {
                    targetMaster.Id=0;
                    targetMaster.Selectedtarget = items.ToString();
                    targetMaster.CompaignId = campaignMaster.Id;
                    _context.targetMasters.Add(targetMaster);
                    _context.SaveChanges();
                }
                //------------Market save------------------
                MarketMaster marketMaster = new MarketMaster();
                foreach (var item in obj.Market)
                {
                    marketMaster.Id=0;
                    marketMaster.SelectedMarket = item;
                    marketMaster.CompaignId = campaignMaster.Id;
                    _context.marketMasters.Add(marketMaster);
                    _context.SaveChanges();
                }
                return true;
            }
            catch (Exception er)
            {
                return false;
            }

        }


    }
}
