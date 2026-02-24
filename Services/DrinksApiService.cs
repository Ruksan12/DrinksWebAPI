using System.Text.Json;
using DrinksWebAPI.Models;
using static DrinksWebAPI.Models.ApiResponses;

namespace DrinksWebAPI.Services;

public class DrinksApiService
{
    private readonly HttpClient _client;
    private const string BaseURL = "https://www.thecocktaildb.com/api/json/v1/1";
    private static readonly JsonSerializerOptions _jsonOptions = new()
    {
        PropertyNameCaseInsensitive = true
    };


    public DrinksApiService(HttpClient client)
    {
        _client = client;
    }

    public async Task<List<Category>> GetCategoriesAsync()
    {
        try
        {
            var json = await _client.GetStringAsync($"{BaseURL}/list.php?c=list");
            var response = JsonSerializer.Deserialize<CategoryResponse>(json, _jsonOptions);
            return response?.Drinks ?? [];
        }
        catch (HttpRequestException ex)
        {
            Console.WriteLine($"API Error: Unable to fetch categories. {ex.Message}");
            return [];
        }
    }

    public async Task<List<Drink>> GetDrinksByCategoryAsync(string category)
    {
        try
        {
            var encoded = Uri.EscapeDataString(category);
            var json = await _client.GetStringAsync($"{BaseURL}/filter.php?c={encoded}");
            var response = JsonSerializer.Deserialize<DrinkResponse>(json, _jsonOptions);
            return response?.Drinks ?? [];
        }
        catch (HttpRequestException ex)
        {
            Console.WriteLine($"API Error: Unable to fetch categories. {ex.Message}");
            return [];
        }
    }

    public async Task<DrinkDetail?> GetDrinkDetailAsync(string id)
    {
        try
        {
            var json = await _client.GetStringAsync($"{BaseURL}/lookup.php?i={id}");
            var response = JsonSerializer.Deserialize<DetailResponse>(json, _jsonOptions);
            return response?.Drinks?.FirstOrDefault();
        }
        catch (HttpRequestException ex)
        {
            Console.WriteLine($"API Error: Unable to fetch categories. {ex.Message}");
            return null;
        }
    }
}