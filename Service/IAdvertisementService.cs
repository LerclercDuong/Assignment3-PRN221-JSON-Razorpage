using BOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service
{
    public interface IAdvertisementService
    {
        public List<Advertisement> GetAdvertisements();

        public Advertisement GetAdvertisement(int adsId);

        public bool CreateAdvertisement(Advertisement ads);
    }
}
