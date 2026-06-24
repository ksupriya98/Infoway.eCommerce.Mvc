using Microsoft.AspNetCore.Mvc;

namespace Infoway.eCommerce.Mvc.Controllers;

public class CustomersController : Controller
{
    public IActionResult Index()
    {
        return View();
    }
}
