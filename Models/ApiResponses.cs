namespace DrinksWebAPI.Models;

public class ApiResponses
{
    public class CategoryResponse
    {
        public List<Category> drinks { get; set; }
    }
    public class DrinkResponse
    {
        public List<Drink> drinks { get; set; }
    }

    public class DetailResponse
    {
        public List<DrinkDetail> drinks { get; set; }

    }
}
