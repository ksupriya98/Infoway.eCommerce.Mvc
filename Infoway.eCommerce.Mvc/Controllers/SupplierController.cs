using Infoway.eCommerce.Mvc.Dal;
using Infoway.eCommerce.Mvc.Models;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace Infoway.eCommerce.Mvc.Controllers
{
    public class SupplierController : Controller
    {
        private readonly eCommerceDbContext _context;

        public SupplierController(eCommerceDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var suppliers = _context.Suppliers.ToList();
            return View(suppliers);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Supplier supplier)
        {
            if (ModelState.IsValid)
            {
                _context.Suppliers.Add(supplier);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(supplier);
        }
    }
}