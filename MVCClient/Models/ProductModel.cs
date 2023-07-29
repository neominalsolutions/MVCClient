using System.Text.Json.Serialization;

namespace MVCClient.Models
{
  public class ProductModel
  {
    // api dan çekilecek olan verile bu modeli dolduracak.

    [JsonPropertyName("id")]
    public int Id { get; set; } // json properyNamelere göre model açtık 


    [JsonPropertyName("name")]
    public string Name { get; set; }

    [JsonPropertyName("price")]
    public decimal Price { get; set; }

    [JsonPropertyName("stock")]
    public short? Stock { get; set; }


  }
}
