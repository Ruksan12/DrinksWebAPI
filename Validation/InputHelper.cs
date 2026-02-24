namespace DrinksWebAPI.Validation;

public static class InputHelper
{
    public static int? GetValidChoice(int min, int max)
    {
        if (!int.TryParse(Console.ReadLine(), out int choice))
            return null;

        if (choice < min || choice > max)
            return null;

        return choice;
    }

    public static int GetValidChoiceWithRetry(int min, int max, string prompt)
    {
        while (true)
        {
            var choice = GetValidChoice(min, max);
            if (choice.HasValue)
                return choice.Value;

            Console.WriteLine(prompt);
        }
    }
}