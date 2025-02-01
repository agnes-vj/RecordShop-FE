using RecordShop_Frontend.Model;

public class Response<T>
{
    public T Item { get; set; }
    public bool HasError { get; set; }
    public string ErrorMessage { get; set; }

}