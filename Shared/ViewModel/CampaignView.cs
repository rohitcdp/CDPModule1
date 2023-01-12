using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CDPModule1.Shared.View_Model
{
    public class CampaignView
    {
        //[Required(ErrorMessage = "Market is required")]
        public List<int>? Market { get; set; }= new List<int>();
        //[Required(ErrorMessage = "Target is required")]
        public List<int>? Target { get; set; }=new List<int>();
        [Required(ErrorMessage = "Brand name is required")]
        public int? BrandName { get; set; }
        [Required(ErrorMessage = "From-date is required")]
        public DateTime? Fromdate { get; set; }
        [Required(ErrorMessage = "required")]
        public DateTime? Todate { get; set; }
        [Required(ErrorMessage = "required")]
        public string? Duration { get; set; }
        [Required(ErrorMessage = "Campaign Name is required")]
        public string? CampaignName { get; set; }
    }
}
