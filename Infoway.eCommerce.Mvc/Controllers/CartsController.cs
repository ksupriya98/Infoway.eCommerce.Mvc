using Infoway.eCommerce.Mvc.Dal;
using Infoway.eCommerce.Mvc.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Infoway.eCommerce.Mvc.Controllers;

public class CartsController : Controller
{
    private const string CartSessionKey = "CartId";
    private readonly eCommerceDbContext _context;

    public CartsController(eCommerceDbContext context)
    {
        _context = context;
    }

    public async Task<IActionResult> Index()
    {
        var cartId = HttpContext.Session.GetInt32(CartSessionKey);
        if (cartId == null)
        {
            return View(new List<CartItem>());
        }

        var items = await _context.CartItems
            .Include(ci => ci.Product)
            .Where(ci => ci.CartId == cartId)
            .ToListAsync();

        UpdateCartCount(items.Sum(i => i.Quantity));
        return View(items);
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> AddToCart(int productId)
    {
        var product = await _context.Products.FindAsync(productId);
        if (product == null)
        {
            return NotFound();
        }

        var cartId = HttpContext.Session.GetInt32(CartSessionKey);
        Cart? cart = null;
        if (cartId != null)
        {
            cart = await _context.Carts.FindAsync(cartId.Value);
        }

        if (cart == null)
        {
            cart = new Cart { CartDate = DateTime.Now };
            _context.Carts.Add(cart);
            await _context.SaveChangesAsync();
            HttpContext.Session.SetInt32(CartSessionKey, cart.CartId);
        }

        var item = await _context.CartItems
            .FirstOrDefaultAsync(ci => ci.CartId == cart.CartId && ci.ProductId == productId);

        if (item == null)
        {
            _context.CartItems.Add(new CartItem
            {
                CartId = cart.CartId,
                ProductId = productId,
                Quantity = 1
            });
        }
        else
        {
            item.Quantity++;
        }

        await _context.SaveChangesAsync();

        var totalQty = await _context.CartItems
            .Where(ci => ci.CartId == cart.CartId)
            .SumAsync(ci => ci.Quantity);
        UpdateCartCount(totalQty);

        return RedirectToAction(nameof(Index));
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> RemoveItem(int cartItemId)
    {
        var item = await _context.CartItems.FindAsync(cartItemId);
        if (item != null)
        {
            _context.CartItems.Remove(item);
            await _context.SaveChangesAsync();
        }
        return RedirectToAction(nameof(Index));
    }

    private void UpdateCartCount(int count)
    {
        HttpContext.Session.SetInt32("CartCount", count);
    }
}
