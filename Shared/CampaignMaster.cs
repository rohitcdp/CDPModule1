using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CDPModule1.Shared.Model
{
    public class CampaignMaster
    {
        [Key]
        public int Id { get; set; }
        [ForeignKey("Brand")]
        public int BrandId { get; set; }
        public string? Fromdate { get; set; }
        public string? Todate { get; set; }
        public string? Duration { get; set; }
        public string? CampaignName { get; set; }
        public DateTime CreatedOn { get; set; } = DateTime.Now;
    }
}
