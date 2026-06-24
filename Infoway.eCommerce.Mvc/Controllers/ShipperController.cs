using Infoway.eCommerce.Mvc.Dal;
using Infoway.eCommerce.Mvc.Models;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace Infoway.eCommerce.Mvc.Controllers
{
    public class ShipperController : Controller
    {
        private readonly eCommerceDbContext _context;

        public ShipperController(eCommerceDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var shippers = _context.Shippers.ToList();
            return View(shippers);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Shipper shipper)
        {
            if (ModelState.IsValid)
            {
                _context.Shippers.Add(shipper);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(shipper);
        }
    }
}