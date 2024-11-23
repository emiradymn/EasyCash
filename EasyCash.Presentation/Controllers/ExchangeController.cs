using System;
using System.Net.Http.Headers;
using System.Text.Json;
using Microsoft.AspNetCore.Mvc;

namespace EasyCash.Presentation.Controllers;

public class ExchangeController : Controller
{
    public async Task<IActionResult> Index()
    {
        #region 
        var client = new HttpClient();
        var request = new HttpRequestMessage
        {
            Method = HttpMethod.Get,
            RequestUri = new Uri("https://currency-converter-pro1.p.rapidapi.com/latest-rates?base=USD&currencies=TRY"),
            Headers =
        {
            { "x-rapidapi-key", "212b87b842msh6c656b9ba7c03cbp11fc6cjsnc34ff8ab1849" },
            { "x-rapidapi-host", "currency-converter-pro1.p.rapidapi.com" },
        },
        };
        using (var response = await client.SendAsync(request))
        {
            response.EnsureSuccessStatusCode();
            var body = await response.Content.ReadAsStringAsync();

            // JSON ayrıştırma işlemi
            var jsonDocument = JsonDocument.Parse(body);
            var usdToTryRate = jsonDocument.RootElement
                .GetProperty("result")
                .GetProperty("TRY")
                .GetDecimal();

            // Ondalık kısmı 2 basamak olacak şekilde düzenle
            ViewBag.UsdToTry = usdToTryRate.ToString("F2");
        }
        #endregion

        #region 
        var client2 = new HttpClient();
        var request2 = new HttpRequestMessage
        {
            Method = HttpMethod.Get,
            RequestUri = new Uri("https://currency-converter-pro1.p.rapidapi.com/latest-rates?base=EUR&currencies=TRY"),
            Headers =
        {
            { "x-rapidapi-key", "212b87b842msh6c656b9ba7c03cbp11fc6cjsnc34ff8ab1849" },
            { "x-rapidapi-host", "currency-converter-pro1.p.rapidapi.com" },
        },
        };
        using (var response2 = await client2.SendAsync(request2))
        {
            response2.EnsureSuccessStatusCode();
            var body2 = await response2.Content.ReadAsStringAsync();

            // JSON ayrıştırma işlemi
            var jsonDocument = JsonDocument.Parse(body2);
            var usdToTryRate = jsonDocument.RootElement
                .GetProperty("result")
                .GetProperty("TRY")
                .GetDecimal();

            // Ondalık kısmı 2 basamak olacak şekilde düzenle
            ViewBag.EurToTry = usdToTryRate.ToString("F2");
        }
        #endregion

        #region 
        var client3 = new HttpClient();
        var request3 = new HttpRequestMessage
        {
            Method = HttpMethod.Get,
            RequestUri = new Uri("https://currency-converter-pro1.p.rapidapi.com/latest-rates?base=GBP&currencies=TRY"),
            Headers =
        {
            { "x-rapidapi-key", "212b87b842msh6c656b9ba7c03cbp11fc6cjsnc34ff8ab1849" },
            { "x-rapidapi-host", "currency-converter-pro1.p.rapidapi.com" },
        },
        };
        using (var response3 = await client3.SendAsync(request3))
        {
            response3.EnsureSuccessStatusCode();
            var body3 = await response3.Content.ReadAsStringAsync();

            // JSON ayrıştırma işlemi
            var jsonDocument = JsonDocument.Parse(body3);
            var usdToTryRate = jsonDocument.RootElement
                .GetProperty("result")
                .GetProperty("TRY")
                .GetDecimal();

            // Ondalık kısmı 2 basamak olacak şekilde düzenle
            ViewBag.GbpToTry = usdToTryRate.ToString("F2");
        }
        #endregion
        return View();
    }
}
