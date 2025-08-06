using Microsoft.AspNetCore.Mvc;
using HotBubbleCanteen.Models;

namespace HotBubbleCanteen.Controllers
{
    public class MembersController : Controller
    {
        private readonly AppDbContext _context;

        public MembersController(AppDbContext context)
        {
            _context = context;
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Member member)
        {
            if (ModelState.IsValid)
            {
                member.PromoCode = GeneratePromoCode();
                _context.Members.Add(member);
                _context.SaveChanges();
                return RedirectToAction("Success", new { id = member.Id });
            }
            return View(member);
        }

        public IActionResult Success(int id)
        {
            var member = _context.Members.Find(id);
            if (member == null)
            {
                return NotFound();
            }
            return View(member);
        }

        // GET: Members/Search
        public IActionResult Search()
        {
            return View();
        }

        // POST: Members/SearchResult
        [HttpPost]
        public IActionResult SearchResult(Member searchInput)
        {
            var member = _context.Members
                .FirstOrDefault(m => m.FirstName == searchInput.FirstName
                                  && m.LastName == searchInput.LastName
                                  && m.PhoneNumber == searchInput.PhoneNumber);

            if (member == null)
            {
                TempData["NotFound"] = "No matching membership found.";
                return RedirectToAction("Search");
            }

            return View("SearchResult", member);
        }

        // GET: Members/ConfirmDelete/5
        public IActionResult ConfirmDelete(int id)
        {
            var member = _context.Members.Find(id);
            if (member == null)
            {
                return NotFound();
            }
            return View(member);
        }

        // POST: Members/DeleteConfirmed/5
        [HttpPost, ActionName("DeleteConfirmed")]
        public IActionResult DeleteConfirmed(int id)
        {
            var member = _context.Members.Find(id);
            if (member != null)
            {
                _context.Members.Remove(member);
                _context.SaveChanges();
            }

            return RedirectToAction("Search");
        }

        private string GeneratePromoCode()
        {
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789";
            var random = new Random();
            return new string(Enumerable.Repeat(chars, 6)
                .Select(s => s[random.Next(s.Length)]).ToArray());
        }
    }
}