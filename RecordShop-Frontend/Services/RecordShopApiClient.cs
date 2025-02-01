using RecordShop_Frontend.Model;
using System.Net;
using System.Numerics;

namespace RecordShop_Frontend.Services
{
    public class RecordShopApiClient
    {
        string BASE_URL;
        string albumsUrl;
        string artistUrl;

        private HttpClient _httpClient;

        public RecordShopApiClient()
        {
            BASE_URL = "https://localhost:7074";
            albumsUrl = $"{BASE_URL}/api/albums";
            artistUrl = $"{BASE_URL}/api/artists";
        }
        public async Task<Response<List<AlbumDTO>>> GetAlbums()
        {
            _httpClient = new HttpClient();
            var result = new Response<List<AlbumDTO>>();
            using (_httpClient)
            {
                try
                {
                    HttpResponseMessage response = await _httpClient.GetAsync(albumsUrl);

                    if (response.IsSuccessStatusCode)
                    {
                        result.Item = await response.Content.ReadFromJsonAsync<List<AlbumDTO>>();


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
            }
            return result;
        }

        public async Task<Response<AlbumDTO>> AddAlbum(AlbumDTO album)
        {
            _httpClient = new HttpClient();
            var result = new Response<AlbumDTO>();
            using (_httpClient)
            {
                try
                {
                    HttpResponseMessage response = await _httpClient.PostAsJsonAsync(albumsUrl, album);
                    if (response.IsSuccessStatusCode)
                    {
                        result.Item = await response.Content.ReadFromJsonAsync<AlbumDTO>();

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
                    Console.WriteLine("Inside try - addalbums");
                    result.ErrorMessage = "Sorry, We encountered an unexpected error while trying to connect to the server... Please try again later.";
                    Console.WriteLine($"Errorrrrrrrr:{ex.Message}");
                }
            }
            return result;
        }
        public async Task<Response<AlbumDTO>> UpdateAlbum(int id, AlbumDTO album)
        {
            _httpClient = new HttpClient(); 
            var result = new Response<AlbumDTO>();

            string updateAlbumByIdUrl = $"{albumsUrl}/{id}";
            using (_httpClient)
            {
                try
                {
                    HttpResponseMessage response = await _httpClient.PutAsJsonAsync(updateAlbumByIdUrl, album);
                    if (response.IsSuccessStatusCode)
                    {
                        result.Item = await response.Content.ReadFromJsonAsync<AlbumDTO>();

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
                    Console.WriteLine("Inside try - upa albums");
                    result.ErrorMessage = "Sorry, We encountered an unexpected error while trying to connect to the server... Please try again later.";
                }
            }
            return result;
        }
        public async Task<Response<AlbumDTO>> GetAlbumById(int id)
        {
            _httpClient = new HttpClient();
            string getAlbumByIdUrl = $"{albumsUrl}/{id}";
            var result = new Response<AlbumDTO>();
            using (_httpClient)
            {
                try
                {
                    HttpResponseMessage response = await _httpClient.GetAsync(getAlbumByIdUrl);

                    if (response.IsSuccessStatusCode)
                    {
                        result.Item = await response.Content.ReadFromJsonAsync<AlbumDTO>();

                    }
                    else
                    {
                        Console.WriteLine("Inside try - getidalbums");
                        result.HasError = true;
                        result.ErrorMessage = await response.Content.ReadAsStringAsync();

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
        public async Task<string> DeleteAlbum(int id)
        {
            _httpClient = new HttpClient();
            string deleteAlbumUrl = $"{albumsUrl}/{id}";
            using (_httpClient)
            {
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
        public async Task<Response<List<Artist>>> GetArtists()
        {
            _httpClient = new HttpClient();
            var result = new Response<List<Artist>>();
            using (_httpClient)
            {
                try
                {
                    HttpResponseMessage response = await _httpClient.GetAsync(artistUrl);

                    if (response.IsSuccessStatusCode)
                    {
                        result.Item = await response.Content.ReadFromJsonAsync<List<Artist>>();


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
            }
            return result;
        }
        public async Task<Response<Artist>> AddArtist(Artist newArtist)
        {
            _httpClient = new HttpClient();
            var result = new Response<Artist>();
            using (_httpClient)
            {
                try
                {
                    HttpResponseMessage response = await _httpClient.PostAsJsonAsync(artistUrl, newArtist);
                    if (response.IsSuccessStatusCode)
                    {
                        result.Item = await response.Content.ReadFromJsonAsync<Artist>();

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
                    Console.WriteLine("Inside try - addalbums");
                    result.ErrorMessage = "Sorry, We encountered an unexpected error while trying to connect to the server... Please try again later.";
                }
            }
            return result;
        }
        public async Task<Response<Artist>> GetArtistByName(string artistName)
        {
            _httpClient = new HttpClient();
            var result = new Response<Artist>();
            using (_httpClient)
            {
                try
                {
                    HttpResponseMessage response = await _httpClient.GetAsync($"{artistUrl}/{artistName}");

                    if (response.IsSuccessStatusCode)
                    {
                        result.Item = await response.Content.ReadFromJsonAsync<Artist>();


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
            }
            return result;
        }

    }
}
