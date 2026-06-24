using Microsoft.AspNetCore.Mvc;

namespace Infoway.eCommerce.Mvc.Controllers;

public class InvoicesController : Controller
{
    public IActionResult Index()
    {
        return View();
    }
}
