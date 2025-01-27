using RecordShop_Frontend.Model;

public class AlbumLoadResult
{
    public List<AlbumDTO> Albums { get; set; }
    public bool HasError { get; set; }
    public string ErrorMessage { get; set; }

}