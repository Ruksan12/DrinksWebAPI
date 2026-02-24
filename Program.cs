using DrinksWebAPI.Models;
using DrinksWebAPI.Services;
using DrinksWebAPI.Validation;

var client = new HttpClient();
var api = new DrinksApiService(client);

while (true)
{
    var categories = await api.GetCategoriesAsync();

    Console.WriteLine("Pick a category (or type '0' to quit):");
    for (int i = 0; i < categories.Count; i++)
        Console.WriteLine($"[{i + 1}] {categories[i].StrCategory}");

    var choice = InputHelper.GetValidChoice(0, categories.Count);
    if (choice == null)
    {
        Console.Clear();
        Console.WriteLine("Invalid input. Please enter a number.");
        continue;
    }

    if (choice == 0)
        break;

    string picked = categories[choice.Value - 1].StrCategory;
    var drinks = await api.GetDrinksByCategoryAsync(picked);

    Console.Clear();
    Console.WriteLine($"\nPick a drink from {picked}:");
    for (int i = 0; i < drinks.Count; i++)
        Console.WriteLine($"[{i + 1}] {drinks[i].StrDrink}");

    int choice2 = InputHelper.GetValidChoiceWithRetry(1, drinks.Count,
        $"Please enter a number between 1 and {drinks.Count}:");

    var drink = await api.GetDrinkDetailAsync(drinks[choice2 - 1].IdDrink);
    if (drink == null)
    {
        Console.WriteLine("Could not retrieve drink details.");
        continue;
    }

    Console.Clear();

    Console.WriteLine($"\n── {drink.StrDrink} ──");
    Console.WriteLine($"Category:     {drink.StrCategory}");
    Console.WriteLine($"Alcoholic:    {drink.StrAlcoholic}");
    Console.WriteLine($"Glass:        {drink.StrGlass}");
    Console.WriteLine($"Instructions: {drink.StrInstructions}");
    Console.WriteLine("\nIngredients:");
    if (!string.IsNullOrEmpty(drink.StrIngredient1))
        Console.WriteLine($"  {drink.StrMeasure1} {drink.StrIngredient1}");
    if (!string.IsNullOrEmpty(drink.StrIngredient2))
        Console.WriteLine($"  {drink.StrMeasure2} {drink.StrIngredient2}");
    if (!string.IsNullOrEmpty(drink.StrIngredient3))
        Console.WriteLine($"  {drink.StrMeasure3} {drink.StrIngredient3}");

    Console.WriteLine("\nPress Enter to continue...");
    Console.ReadLine();
    Console.Clear();

}

Console.WriteLine("Goodbye");




