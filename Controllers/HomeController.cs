using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using HotBubbleCanteen.Models;

namespace HotBubbleCanteen.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;
    private readonly AppDbContext _context;

    public HomeController(ILogger<HomeController> logger, AppDbContext context)
    {
        _logger = logger;
        _context = context;
    }

    public IActionResult Index()
    {
        // 获取所有可用菜品，按照数据库顺序排列
        var dishes = _context.Dishes
            .Where(d => d.IsAvailable)
            .OrderBy(d => d.Id)
            .ToList();

        return View(dishes); // 传递给 Index.cshtml
    }

    public IActionResult Privacy()
    {
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}