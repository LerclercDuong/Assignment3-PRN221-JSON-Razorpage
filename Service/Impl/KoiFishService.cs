using BOs;
using Daos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Impl
{
    public class KoiFishService : IKoiFishService
    {
        public List<KoiFish> GetFishList()
        {
            return KoiFishDAO.Instance.GetKoiFishes();
        }
        public KoiFish GetFishById(string id)
        {
            return KoiFishDAO.Instance.GetFishById(id);
        }
    }
}
