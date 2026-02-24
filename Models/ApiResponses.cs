namespace DrinksWebAPI.Models;

public class ApiResponses
{
    public class CategoryResponse
    {
        public List<Category> Drinks { get; set; }
    }
    public class DrinkResponse
    {
        public List<Drink> Drinks { get; set; }
    }

    public class DetailResponse
    {
        public List<DrinkDetail> Drinks { get; set; }

    }
}
