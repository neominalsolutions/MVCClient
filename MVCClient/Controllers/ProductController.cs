using Microsoft.AspNetCore.Mvc;
using MVCClient.Models;
using System.Net;

namespace MVCClient.Controllers
{
  public class ProductController : Controller
  {
    public async Task<IActionResult> Index()
    {
      // c# kendi yönetemediği dış kayanaklara ait maliyetli bağlantılarda using keyword kullanarak
      // kaynak yönetimini c# otomatik yapmasına imkan sağlarız. (API işlemleri, Database işlemleri, File İşlermleri maliyetli işlemler olduğundan dolayı using kod blogu içerisinde bağlantı kuruyoruz)
      using (var client = new HttpClient()) // Api bağlanmak için c# HttpClient sınıfı kullanıyoruz
      {
        client.BaseAddress = new Uri("https://localhost:7091/"); // bağlantılı olan sunucu adresi
        client.Timeout = TimeSpan.FromSeconds(30); // 30sn sunucu erişilemezse istek timeout düşsün

        var response =  await client.GetAsync("api/Products"); // endpoint veri çekeceğimiz uç

        if(response.StatusCode == HttpStatusCode.OK) // 200 dönmüş ise o zaman veri çekebilirim
        {
          // git bunu apiden json formatında oku json formatındaki veriyi ProductModel tipine çevir

          var productJsonString = response.Content.ReadAsStringAsync().Result;

          var model = System.Text.Json.JsonSerializer.Deserialize<List<ProductModel>>(productJsonString);

          return View(model);
        }
        else
        {
          return View("Error");
        }
      }
    }
  }
}
