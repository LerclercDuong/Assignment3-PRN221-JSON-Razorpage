using BOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service
{
    public interface IKoiFishService
    {
        public List<KoiFish> GetFishList();
        public KoiFish GetFishById(string id);
    }
}
