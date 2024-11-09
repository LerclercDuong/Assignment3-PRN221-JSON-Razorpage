using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BOs
{
    public class KoiFish
    {
        public string Id { get; set; }
        public string KoiFishName { get; set; }
        public string KoiFishColor { get; set; }
        public double KoiFishSize { get; set; }
        public double KoiFishAge { get; set; }
        public List<string> KoiFishPictures { get; set; }
        public FengshuiElement FengShuiElement { get; set; }
        public string SymbolicMeaning { get; set; }
        public string EnergyType { get; set; }
        public int FavorableNumber { get; set; }
        public string FavorableColor { get; set; }
        public string KoiFishOrigin { get; set; }
        public string KoiFishDescription { get; set; }
        public double KoiFishPrice { get; set; }
    }
}
