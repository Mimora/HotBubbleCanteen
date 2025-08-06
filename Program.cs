using Microsoft.EntityFrameworkCore;
using HotBubbleCanteen.Models;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlite(builder.Configuration.GetConnectionString("DefaultConnection")));

// Add services to the container.
builder.Services.AddControllersWithViews();

var app = builder.Build();

using (var scope = app.Services.CreateScope())
{
    var context = scope.ServiceProvider.GetRequiredService<AppDbContext>();

if (!context.Dishes.Any())
{
    context.Dishes.AddRange(
        // Meat - 10
        new Dish { Name = "Lamb Slices", Type = "Meat", Price = 10, IsAvailable = true, ImagePath = "/images/Meat_LambSlices.png", Description = "Tender lamb slices, perfect for quick hotpot cooking." },
        new Dish { Name = "Beef Slices", Type = "Meat", Price = 11, IsAvailable = true, ImagePath = "/images/Meat_BeefSlices.png", Description = "Richly marbled beef slices for a flavorful bite." },
        new Dish { Name = "Pork Belly", Type = "Meat", Price = 9, IsAvailable = true, ImagePath = "/images/Meat_PorkBelly.png", Description = "Fatty and juicy pork belly, melts in your mouth." },
        new Dish { Name = "Chicken Thigh", Type = "Meat", Price = 8, IsAvailable = true, ImagePath = "/images/Meat_ChickenThigh.png", Description = "Boneless chicken thigh, tender and protein-rich." },
        new Dish { Name = "Duck Breast", Type = "Meat", Price = 10, IsAvailable = true, ImagePath = "/images/Meat_DuckBreast.png", Description = "Lean duck breast with a rich, gamey taste." },
        new Dish { Name = "Luncheon Meat", Type = "Meat", Price = 8.5M, IsAvailable = true, ImagePath = "/images/Meat_LuncheonMeat.png", Description = "Classic canned meat with nostalgic flavor." },
        new Dish { Name = "Fish Fillet", Type = "Meat", Price = 11, IsAvailable = true, ImagePath = "/images/Meat_FishFillet.png", Description = "Fresh and delicate white fish fillet." },
        new Dish { Name = "Shrimp", Type = "Meat", Price = 12, IsAvailable = true, ImagePath = "/images/Meat_Shrimp.png", Description = "Juicy shrimp, shell-off and ready to cook." },
        new Dish { Name = "Tripe", Type = "Meat", Price = 10, IsAvailable = true, ImagePath = "/images/Meat_Tripe.png", Description = "Chewy beef tripe for the adventurous eater." },
        new Dish { Name = "Beef Tendon", Type = "Meat", Price = 9.5M, IsAvailable = true, ImagePath = "/images/Meat_BeefTendon.png", Description = "Gelatin-rich beef tendon, slow-cooked texture." },

        // Vegetable - 10
        new Dish { Name = "Enoki Mushrooms", Type = "Vegetable", Price = 5, IsAvailable = true, ImagePath = "/images/Vegetable_EnokiMushrooms.png", Description = "Delicate mushrooms with a crisp bite." },
        new Dish { Name = "Lettuce", Type = "Vegetable", Price = 4, IsAvailable = true, ImagePath = "/images/Vegetable_Lettuce.png", Description = "Fresh and light, great for wrapping meat." },
        new Dish { Name = "Winter Melon", Type = "Vegetable", Price = 4.5M, IsAvailable = true, ImagePath = "/images/Vegetable_WinterMelon.png", Description = "Mild, tender slices that absorb soup well." },
        new Dish { Name = "Tofu", Type = "Vegetable", Price = 5, IsAvailable = true, ImagePath = "/images/Vegetable_Tofu.png", Description = "Soft tofu that soaks up all the hotpot flavor." },
        new Dish { Name = "Napa Cabbage", Type = "Vegetable", Price = 4.5M, IsAvailable = true, ImagePath = "/images/Vegetable_NapaCabbage.png", Description = "Sweet and soft after boiling, a classic choice." },
        new Dish { Name = "Spinach", Type = "Vegetable", Price = 4.8M, IsAvailable = true, ImagePath = "/images/Vegetable_Spinach.png", Description = "Leafy green rich in iron and fiber." },
        new Dish { Name = "Potato Slices", Type = "Vegetable", Price = 4.5M, IsAvailable = true, ImagePath = "/images/Vegetable_PotatoSlices.png", Description = "Starchy slices that hold texture after cooking." },
        new Dish { Name = "Lotus Root", Type = "Vegetable", Price = 5.5M, IsAvailable = true, ImagePath = "/images/Vegetable_LotusRoot.png", Description = "Crunchy and refreshing with a hint of sweetness." },
        new Dish { Name = "Mung Bean Sprouts", Type = "Vegetable", Price = 4.2M, IsAvailable = true, ImagePath = "/images/Vegetable_MungBeanSprouts.png", Description = "Light, crunchy sprouts with a clean taste." },
        new Dish { Name = "Seaweed Knots", Type = "Vegetable", Price = 5.8M, IsAvailable = true, ImagePath = "/images/Vegetable_SeaweedKnots.png", Description = "Chewy seaweed knots rich in umami." },

        // Drink - 6
        new Dish { Name = "Coke", Type = "Drink", Price = 2.5M, IsAvailable = true, ImagePath = "/images/Drink_Coke.png", Description = "Classic carbonated soda, refreshing and fizzy." },
        new Dish { Name = "Sprite", Type = "Drink", Price = 2.5M, IsAvailable = true, ImagePath = "/images/Drink_Sprite.png", Description = "Lemon-lime soda with a light citrus taste." },
        new Dish { Name = "Lemon Water", Type = "Drink", Price = 2.8M, IsAvailable = true, ImagePath = "/images/Drink_LemonWater.png", Description = "Chilled lemon water, tangy and cleansing." },
        new Dish { Name = "Iced Tea", Type = "Drink", Price = 2.8M, IsAvailable = true, ImagePath = "/images/Drink_IcedTea.png", Description = "Refreshing tea served cold, slightly sweet." },
        new Dish { Name = "Sparkling Water", Type = "Drink", Price = 3.0M, IsAvailable = true, ImagePath = "/images/Drink_SparklingWater.png", Description = "Bubbly and light, great for palate cleansing." },
        new Dish { Name = "Tsingtao Beer", Type = "Drink", Price = 3.5M, IsAvailable = true, ImagePath = "/images/Drink_TsingtaoBeer.png", Description = "Classic Chinese lager, smooth and crisp." }
    );

    context.SaveChanges();
}
}

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseRouting();

app.UseAuthorization();

app.MapStaticAssets();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}")
    .WithStaticAssets();


app.Run();
