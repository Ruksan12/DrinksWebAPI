using System.Collections.Generic;
using System.Net.Http;
using System.Runtime.InteropServices;
using System.Security.Claims;
using System.Security.Cryptography.X509Certificates;
using System.Text.Json;
using System.Threading.Tasks;

class Item
{
    public string strCategory { get; set; }
}

class Response
{
    public List<Item> drinks { get; set; }
}
class program
{
    static async Task Main()
    {
        HttpClient client = new HttpClient();
        const string BaseURL = "https://www.thecocktaildb.com/api/json/v1/1";

        var json = await client.GetStringAsync($"{BaseURL}/list.php?c=list");


        var Result = JsonSerializer.Deserialize<Response>(json);

        foreach (var item in Result.drinks)
        {
            Console.WriteLine(item.strCategory);
        }
    }
}




