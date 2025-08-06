namespace HotBubbleCanteen.Models;

public class Dish
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Type { get; set; } // Meat, Vegetable, Drink
    public decimal Price { get; set; }
    public string ImagePath { get; set; } = string.Empty;
    public string Description { get; set; }
    public bool IsAvailable { get; set; }
}

