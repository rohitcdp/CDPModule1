using CDPModule1.Shared;
using CDPModule1.Shared.Model;
using CDPModule1.Shared.View_Model;

namespace CDPModule1.Server.Interface
{
    public interface ICampaign
    {
        IEnumerable<Market> GetMarketList();
        IEnumerable<CDPModule1.Shared.Model.Target> GetTargetList();
        IEnumerable<Brand> GetBrandList();
        bool SaveCampaign(CampaignView obj);
        IEnumerable<CampaignMaster> GetCampaignlist();
        IEnumerable<MarketMaster> GetselectedMarketList();
        IEnumerable<TargetMaster> GetselectedTargetList();
    }
}
