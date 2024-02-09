using Newtonsoft.Json;

namespace doginals
{
    public class Doginal
    {
        public async Task<DoginalResult> GetItems(int pageNo)
        {
            var url = $"https://d20-api2.dogeord.io/ticks/list/ranking?size=100&page={pageNo}&filterByTick=";
            var httpClient = new HttpClient();
            var result = await httpClient.GetStringAsync(url);
            var jsonObject = JsonConvert.DeserializeObject<DoginalResult>(result);
            return jsonObject;
        }

        public async Task<List<HolderInfo>> GetHolderInfo(string token, int size=10)
        {
            var url = $"https://d20-api2.dogeord.io/trading/tokenholderinfo/{token}?size={size}";
            var httpClient = new HttpClient();
            var result = await httpClient.GetStringAsync(url);
            var jsonObject = JsonConvert.DeserializeObject<List<HolderInfo>>(result);
            return jsonObject;
        } 
    }
}