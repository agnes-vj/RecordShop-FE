using RecordShop_Frontend.Model;
using System.Net;
using System.Numerics;

namespace RecordShop_Frontend.Services
{
    public class RecordShopApiClient
    {
        string BASE_URL;
        string albumsUrl;

        HttpClient _httpClient = new HttpClient();
        public RecordShopApiClient(IConfiguration configuration)
        {
            BASE_URL = configuration["BACKEND_URL:Dev"];
            albumsUrl = $"{BASE_URL}/api/albums";
            Console.WriteLine("Albums url " + albumsUrl);
        }
        public async Task<AlbumResponse> GetAlbums()
        {
            var result = new AlbumResponse();
            using (_httpClient)
            {
                try
                {
                    HttpResponseMessage response = await _httpClient.GetAsync(albumsUrl);

                    if (response.IsSuccessStatusCode)
                    {
                        result.Albums = await response.Content.ReadFromJsonAsync<List<AlbumDTO>>();                       

                    }
                    else
                    {
                        result.HasError = true;
                        switch (response.StatusCode)
                        {
                            case HttpStatusCode.NotFound:
                                result.ErrorMessage = "Sorry, we couldn't find the albums you're looking for. Please try again later.";
                                break;

                            case HttpStatusCode.InternalServerError:
                                result.ErrorMessage = "Sorry, we encountered an unexpected error while trying to load the albums. Please try again later.";
                                break;

                            default:
                                result.ErrorMessage = "Unexpected error occurred";
                                break;
                        }                       
                    }
                }
                catch (Exception ex)
                {
                    result.HasError = true;
                    result.ErrorMessage = "Sorry, We encountered an unexpected error while trying to connect to the server... Please try again later.";
                }
            }
            return result;
        }

        public async Task<AlbumResponse> AddAlbum(AlbumDTO album)
        {
            var result = new AlbumResponse();

            try
            {
                HttpResponseMessage response = await _httpClient.PostAsJsonAsync(albumsUrl, album);
                if (response.IsSuccessStatusCode)
                {
                    result.Album = await response.Content.ReadFromJsonAsync<AlbumDTO>();

                }
                else
                {
                    result.HasError = true;
                    result.ErrorMessage = await response.Content.ReadAsStringAsync();
                            
                }
            }
            catch (Exception ex)
            {
                result.HasError = true;
                result.ErrorMessage = "Sorry, We encountered an unexpected error while trying to connect to the server... Please try again later.";
            }
            return result;
        }

        public async Task<string> DeletAlbum(int id)
        {
            string deleteAlbumUrl = $"{albumsUrl}/{id}";

                try
                {
                    HttpResponseMessage response = await _httpClient.DeleteAsync(deleteAlbumUrl);
                    return response.StatusCode switch
                    {
                        System.Net.HttpStatusCode.OK => "SUCCESS",
                        System.Net.HttpStatusCode.NotFound => "NOT_FOUND",
                        System.Net.HttpStatusCode.InternalServerError => "INTERNAL_SERVER_ERROR",
                        _ => "FAILURE"
                    };
                }
                catch (HttpRequestException error)
                {
                    Console.WriteLine($"Error: {error.Message}");
                    return "FAILURE";
                }
        }
    }
}
