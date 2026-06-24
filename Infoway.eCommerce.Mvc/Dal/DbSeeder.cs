using Infoway.eCommerce.Mvc.Models;
using Microsoft.EntityFrameworkCore;

namespace Infoway.eCommerce.Mvc.Dal;

public static class DbSeeder
{
    public static void Seed(eCommerceDbContext context)
    {
        context.Database.Migrate();

        if (context.Categories.Any())
        {
            return;
        }

        var sports = new Category { CategoryName = "Sports Shoes", Description = "Performance footwear built for running, training and the field." };
        var casual = new Category { CategoryName = "Casual Shoes", Description = "Everyday comfort and style for any occasion." };
        var boots = new Category { CategoryName = "Boots", Description = "Rugged, durable boots made for the outdoors." };
        var lifestyle = new Category { CategoryName = "Lifestyle", Description = "Trend-forward sneakers to complete your look." };

        context.Categories.AddRange(sports, casual, boots, lifestyle);
        context.SaveChanges();

        var products = new List<Product>
        {
            new() { ProductName = "Adidas Galaxy Runner", BrandId = 1, CategoryId = sports.CategoryId, Description = "Lightweight cushioned running shoe for men.", UnitPrice = 5999, Discount = 15, Gender = "Men", Picture = "~/Images/adidas_soc_m_1.jpeg" },
            new() { ProductName = "Adidas Cloudfoam (W)", BrandId = 1, CategoryId = sports.CategoryId, Description = "Breathable everyday trainer for women.", UnitPrice = 5499, Discount = 10, Gender = "Women", Picture = "~/Images/adidas_soc_w_1.jpeg" },
            new() { ProductName = "Adidas Pure Boost (W)", BrandId = 1, CategoryId = sports.CategoryId, Description = "Responsive boost cushioning for long runs.", UnitPrice = 7999, Discount = 20, Gender = "Women", Picture = "~/Images/adidas_soc_w_2.jpeg" },
            new() { ProductName = "Nike Air Zoom", BrandId = 2, CategoryId = sports.CategoryId, Description = "Springy Zoom Air unit for explosive pace.", UnitPrice = 8999, Discount = 18, Gender = "Men", Picture = "~/Images/nike_soc_m_1.jpeg" },
            new() { ProductName = "Nike Revolution (W)", BrandId = 2, CategoryId = sports.CategoryId, Description = "Soft foam midsole for daily training.", UnitPrice = 6499, Discount = 12, Gender = "Women", Picture = "~/Images/nike_soc_w_1.jpeg" },
            new() { ProductName = "Puma Velocity", BrandId = 3, CategoryId = sports.CategoryId, Description = "Energy-return running shoe for men.", UnitPrice = 5799, Discount = 25, Gender = "Men", Picture = "~/Images/puma_soc_m_1.jpeg" },
            new() { ProductName = "Puma Nitro Pro", BrandId = 3, CategoryId = sports.CategoryId, Description = "Premium nitrogen-infused racing foam.", UnitPrice = 9499, Discount = 22, Gender = "Men", Picture = "~/Images/puma_soc_m_2.png" },
            new() { ProductName = "Reebok Floatride (W)", BrandId = 4, CategoryId = sports.CategoryId, Description = "Plush, lightweight ride for women.", UnitPrice = 6999, Discount = 14, Gender = "Women", Picture = "~/Images/reebook_soc_w1.jpeg" },

            new() { ProductName = "Bata Comfort Walk", BrandId = 5, CategoryId = casual.CategoryId, Description = "All-day casual comfort for men.", UnitPrice = 2499, Discount = 10, Gender = "Men", Picture = "~/Images/bata_c_m_1.jpeg" },
            new() { ProductName = "Bata Slip-On", BrandId = 5, CategoryId = casual.CategoryId, Description = "Easy slip-on casual shoe.", UnitPrice = 1999, Discount = 5, Gender = "Men", Picture = "~/Images/bata_c_m_2.jpeg" },
            new() { ProductName = "Bata Breeze (W)", BrandId = 5, CategoryId = casual.CategoryId, Description = "Lightweight casual shoe for women.", UnitPrice = 2299, Discount = 8, Gender = "Women", Picture = "~/Images/bata_c_w_1.jpeg" },
            new() { ProductName = "Campus Street", BrandId = 6, CategoryId = casual.CategoryId, Description = "Sporty casual look for men.", UnitPrice = 1799, Discount = 12, Gender = "Men", Picture = "~/Images/campus_c_m_1.jpeg" },
            new() { ProductName = "Campus Bloom (W)", BrandId = 6, CategoryId = casual.CategoryId, Description = "Fashion-forward casual for women.", UnitPrice = 1899, Discount = 15, Gender = "Women", Picture = "~/Images/campus_c_w_2.jpeg" },
            new() { ProductName = "Sparx Active (W)", BrandId = 7, CategoryId = casual.CategoryId, Description = "Comfortable casual everyday shoe.", UnitPrice = 1599, Discount = 10, Gender = "Women", Picture = "~/Images/sparx_c_w_1.jpeg" },
            new() { ProductName = "Puma Casual Court", BrandId = 3, CategoryId = casual.CategoryId, Description = "Clean court-style casual sneaker.", UnitPrice = 3499, Discount = 18, Gender = "Men", Picture = "~/Images/puma_c_m_1.jpg" },

            new() { ProductName = "Woodland Trekker", BrandId = 8, CategoryId = boots.CategoryId, Description = "Rugged leather boots for tough terrain.", UnitPrice = 4999, Discount = 12, Gender = "Men", Picture = "~/Images/woodland_b_m_1.jpeg" },
            new() { ProductName = "Woodland Summit", BrandId = 8, CategoryId = boots.CategoryId, Description = "Durable hiking boots with grip sole.", UnitPrice = 5499, Discount = 16, Gender = "Men", Picture = "~/Images/woodland_b_m_2.jpg" },
            new() { ProductName = "Woodland Trail (W)", BrandId = 8, CategoryId = boots.CategoryId, Description = "Outdoor ankle boots for women.", UnitPrice = 4799, Discount = 10, Gender = "Women", Picture = "~/Images/woodland_b_w_1.jpg" },
            new() { ProductName = "Bata Ranger", BrandId = 5, CategoryId = boots.CategoryId, Description = "Sturdy everyday work boots.", UnitPrice = 3299, Discount = 8, Gender = "Men", Picture = "~/Images/bata_b_m_1.jpg" },
            new() { ProductName = "Campus Hiker", BrandId = 6, CategoryId = boots.CategoryId, Description = "Lightweight hiking boots for men.", UnitPrice = 2999, Discount = 14, Gender = "Men", Picture = "~/Images/campus_b_m_1.jpg" },

            new() { ProductName = "Nike Lifestyle Low", BrandId = 2, CategoryId = lifestyle.CategoryId, Description = "Iconic everyday lifestyle sneaker.", UnitPrice = 7499, Discount = 20, Gender = "Men", Picture = "~/Images/nike_l_m_1.jpg" },
            new() { ProductName = "Nike Retro Court", BrandId = 2, CategoryId = lifestyle.CategoryId, Description = "Retro court styling for daily wear.", UnitPrice = 6999, Discount = 15, Gender = "Men", Picture = "~/Images/nike_l_m_2.jpg" },
            new() { ProductName = "Nike Street (W)", BrandId = 2, CategoryId = lifestyle.CategoryId, Description = "Streetwear-ready sneaker for women.", UnitPrice = 7299, Discount = 18, Gender = "Women", Picture = "~/Images/nike_l_w_1.jpg" },
            new() { ProductName = "Campus Urban", BrandId = 6, CategoryId = lifestyle.CategoryId, Description = "Modern lifestyle sneaker for men.", UnitPrice = 2199, Discount = 12, Gender = "Men", Picture = "~/Images/campus_l_m_2.jpg" },
            new() { ProductName = "Puma Lifestyle (W)", BrandId = 3, CategoryId = lifestyle.CategoryId, Description = "Stylish everyday sneaker for women.", UnitPrice = 3999, Discount = 22, Gender = "Women", Picture = "~/Images/puma_l_w_1.jpg" }
        };

        context.Products.AddRange(products);

        context.Suppliers.AddRange(
            new Supplier { Name = "Adidas India Pvt Ltd", City = "Bengaluru" },
            new Supplier { Name = "Nike Sports Trading", City = "Mumbai" },
            new Supplier { Name = "Bata India Ltd", City = "Kolkata" },
            new Supplier { Name = "Campus Activewear", City = "New Delhi" }
        );

        context.Shippers.AddRange(
            new Shipper { Name = "BlueDart Express", ContactNumber = "1800-233-1234", EmailId = "support@bluedart.com" },
            new Shipper { Name = "Delhivery", ContactNumber = "1800-209-3666", EmailId = "care@delhivery.com" },
            new Shipper { Name = "DTDC Couriers", ContactNumber = "1860-123-4567", EmailId = "help@dtdc.com" }
        );

        context.SaveChanges();
    }
}
