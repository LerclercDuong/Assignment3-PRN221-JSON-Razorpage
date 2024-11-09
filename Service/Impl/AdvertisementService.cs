using BOs;
using Daos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Impl
{
    public class AdvertisementService : IAdvertisementService
    {
        public bool CreateAdvertisement(Advertisement ads)
        {
            return AdvertisementDAO.Instance.CreateAdvertisement(ads);
        }

        public Advertisement GetAdvertisement(int adsId)
        {
            return AdvertisementDAO.Instance.GetAdvertisement(adsId);
        }

        public List<Advertisement> GetAdvertisements()
        {
            return AdvertisementDAO.Instance.GetAdvertisements();
        }
    }
}
