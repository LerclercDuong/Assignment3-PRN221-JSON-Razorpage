using BOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Daos
{
    public class AdvertisementDAO
    {
        public static AdvertisementDAO _instance;

        public static AdvertisementDAO Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new AdvertisementDAO();
                }
                return _instance;
            }
        }
        private readonly string filePath = "Advertisement.json";

        public List<Advertisement> GetAdvertisements()
        {
            if (!File.Exists(filePath))
                return new List<Advertisement>();

            string strData = File.ReadAllText(filePath);
            var options = new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            };
            return JsonSerializer.Deserialize<List<Advertisement>>(strData, options);
        }
        public Advertisement GetAdvertisement(int adsId)
        {
            List<Advertisement> adsList = GetAdvertisements().ToList();
            return adsList.FirstOrDefault(x => x.AdvertisementId == adsId);
        }

        public void SaveAdvertisements(List<Advertisement> advertisements)
        {
            var options = new JsonSerializerOptions { WriteIndented = true };
            string jsonData = JsonSerializer.Serialize(advertisements, options);
            File.WriteAllText(filePath, jsonData);
        }

        public bool CreateAdvertisement(Advertisement newAd)
        {
            var success = false;
            try
            {
                var advertisements = GetAdvertisements();
                newAd.AdvertisementId = advertisements.Count > 0 ? advertisements.Max(a => a.AdvertisementId) + 1 : 1; // Auto-increment ID
                advertisements.Add(newAd);
                SaveAdvertisements(advertisements);
                success = true;
            }
            catch (Exception ex)
            {

            }

            return success;
        }

        public Advertisement UpdateAdvertisement(int id, Advertisement updatedAd)
        {
            var advertisements = GetAdvertisements();
            var ad = advertisements.FirstOrDefault(a => a.AdvertisementId == id);
            if (ad != null)
            {
                ad.Title = updatedAd.Title;
                ad.Description = updatedAd.Description;
                SaveAdvertisements(advertisements);
            }
            return ad;
        }

        public bool DeleteAdvertisement(int id)
        {
            var advertisements = GetAdvertisements();
            var ad = advertisements.FirstOrDefault(a => a.AdvertisementId == id);
            if (ad != null)
            {
                advertisements.Remove(ad);
                SaveAdvertisements(advertisements);
                return true;
            }
            return false;
        }
    }
}

