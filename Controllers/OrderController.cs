using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

public class OrderController : Controller
{
    private readonly AppDbContext _context;

    public OrderController(AppDbContext context)
    {
        _context = context;
    }

    // GET: /Order/Menu
    public IActionResult Menu()
    {
        var dishes = _context.Dishes
            .Where(d => d.IsAvailable)
            .ToList();

        var typeOrder = new List<string> { "Meat", "Vegetable", "Drink" };

        var grouped = dishes
            .GroupBy(d => d.Type)
            .OrderBy(g => typeOrder.IndexOf(g.Key))
            .ToList();

        return View(grouped); // 注意！这时返回的是分组结果
    }

    [HttpPost]
    public IActionResult SubmitOrder(string customerName, string tableNumber, Dictionary<int, int> quantities, string promoCode)
    {
        if (string.IsNullOrWhiteSpace(customerName) || quantities == null)
        {
            return BadRequest("Missing order data.");
        }

        // 创建订单主表
        var order = new Order
        {
            CustomerName = customerName,
            TableNumber = tableNumber,
            OrderTime = DateTime.Now,
            Items = new List<OrderItem>()
        };

        // 加入每一个选中的菜品
        foreach (var entry in quantities)
        {
            int dishId = entry.Key;
            int quantity = entry.Value;

            if (quantity > 0)
            {
                order.Items.Add(new OrderItem
                {
                    DishId = dishId,
                    Quantity = quantity
                });
            }
        }

        // 如果啥都没点就不保存
        if (order.Items.Count == 0)
        {
            return BadRequest("No items selected.");
        }

        // 默认折扣
        decimal discountRate = 0;

        // 检查 PromoCode
        if (!string.IsNullOrWhiteSpace(promoCode))
        {
            var member = _context.Members.FirstOrDefault(m => m.PromoCode == promoCode);
            if (member != null)
            {
                if (member.MembershipLevel == 3)
                    discountRate = 0.10m;
                else if (member.MembershipLevel == 2)
                    discountRate = 0.05m;
            }
        }

        _context.Orders.Add(order);
        _context.SaveChanges();

        return RedirectToAction("Confirmation", new { orderId = order.Id, discount = discountRate });
    }

    // public IActionResult Confirmation(int orderId)
    // {
    //     var order = _context.Orders
    //         .Include(o => o.Items)
    //         .ThenInclude(oi => oi.Dish)
    //         .FirstOrDefault(o => o.Id == orderId);

    //     if (order == null)
    //     {
    //         return NotFound();
    //     }

    //     return View(order);
    // }

    public IActionResult Confirmation(int orderId, decimal discount = 0)
    {
        var order = _context.Orders
            .Include(o => o.Items)
            .ThenInclude(i => i.Dish)
            .FirstOrDefault(o => o.Id == orderId);

        if (order == null)
        {
            return NotFound();
        }

        ViewBag.Discount = discount;
        return View(order);
    }

    [HttpGet]
    public IActionResult Search()
    {
        return View();
    }

    [HttpPost]
    public IActionResult SearchResults(string customerName, string tableNumber, DateTime? date)
    {
        if (string.IsNullOrWhiteSpace(customerName) || string.IsNullOrWhiteSpace(tableNumber))
        {
            ViewBag.Error = "Please provide both name and table number.";
            return View("Search");
        }

        var queryDate = date ?? DateTime.Today;

        var orders = _context.Orders
            .Include(o => o.Items)
            .ThenInclude(i => i.Dish)
            .Where(o =>
                o.CustomerName == customerName &&
                o.TableNumber == tableNumber &&
                o.OrderTime.Date == queryDate.Date)
            .OrderByDescending(o => o.OrderTime)
            .ToList();

        return View("SearchResults", orders);
    }

}