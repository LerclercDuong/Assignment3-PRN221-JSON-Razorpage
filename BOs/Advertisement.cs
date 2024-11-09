using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BOs
{
    public class Advertisement
    {
        public int AdvertisementId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public decimal? Price { get; set; } 
        public string KoiFishId { get; set; } 
        public string PostedByUserId { get; set; }
    }
}
