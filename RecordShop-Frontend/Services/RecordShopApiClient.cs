using RecordShop_Frontend.Model;

namespace RecordShop_Frontend.Services
{
    public class RecordShopApiClient
    {
         string BASE_URL;
    public RecordShopApiClient(IConfiguration configuration)
        {
            BASE_URL = configuration["BACKEND_URL:Dev"];
            Console.WriteLine("BASE" +BASE_URL);
        }
        public async Task<List<AlbumDTO>> GetAlbums()
        {
            
            using (HttpClient httpClient = new HttpClient())
            {
                string url = $"{BASE_URL}/api/albums";
                Console.WriteLine("URL :" + url);
                try
                {
                    List<AlbumDTO> albums = await httpClient.GetFromJsonAsync<List<AlbumDTO>>(url);
                    if (albums != null)
                        return albums;

                }
                catch (HttpRequestException error)
                {
                    Console.WriteLine($"Error: {error.Message}");                   
                }
            }
            return null;
        }
    }
}
