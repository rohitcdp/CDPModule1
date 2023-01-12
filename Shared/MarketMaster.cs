using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CDPModule1.Shared.Model
{
    public class MarketMaster
    {
        [Key]
        public int Id { get; set; }
        public int SelectedMarket { get; set; }
        [ForeignKey("CampaignMaster")]
        public int CompaignId { get; set; }
    }
}
