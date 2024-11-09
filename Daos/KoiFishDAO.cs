using BOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Daos
{
    public class KoiFishDAO
    {
        public static KoiFishDAO _instance;
        public List<KoiFish> KoiFishList;
        public KoiFishDAO() {
            KoiFishList = GetKoiFishes();
        }

        public static KoiFishDAO Instance
        {
            get {
                if (_instance == null) { 
                    _instance = new KoiFishDAO();   
                }
                return _instance;
            }
        }
        public List<KoiFish> GetKoiFishes()
        {
            // Đọc dữ liệu từ file JSON
            string strData = File.ReadAllText("KoiFish.json");
            var options = new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            };
            return JsonSerializer.Deserialize<List<KoiFish>>(strData, options);
        }
        public KoiFish GetFishById(string id) {
            return KoiFishList.FirstOrDefault(x => x.Id.Equals(id));
        }
    }
}
