using Microsoft.AspNetCore.Mvc;

namespace Infoway.eCommerce.Mvc.Controllers;

public class CartsController : Controller
{
    public IActionResult Index()
    {
        return View();
    }
}
