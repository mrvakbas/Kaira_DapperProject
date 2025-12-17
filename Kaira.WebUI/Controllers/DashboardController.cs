using Dapper;
using Kaira.WebUI.Context;
using Microsoft.AspNetCore.Mvc;
using System.Data;

namespace Kaira.WebUI.Controllers
{
    public class DashboardController(AppDbContext context) : Controller
    {
        private readonly IDbConnection _db = context.CreateConnection();
        public async Task<IActionResult> Index()
        {
            //collection count
            var query = "select Count(*) from collections";
            var totalCount = await _db.QuerySingleAsync<int>(query);
            ViewBag.collection = totalCount;

            var query2 = "select Count(*) from categories";
            var totalCount2 = await _db.QuerySingleAsync<int>(query2);
            ViewBag.category = totalCount2;

            var query3 = "select Count(*) from testimonials";
            var totalCount3 = await _db.QuerySingleAsync<int>(query3);
            ViewBag.testimonial = totalCount3;

            var query4 = "select Count(*) from products";
            var totalCount4 = await _db.QuerySingleAsync<int>(query4);
            ViewBag.product = totalCount4;

            var query5 = "select Count(*) from brands";
            var totalCount5 = await _db.QuerySingleAsync<int>(query5);
            ViewBag.brand = totalCount5;

            var query6 = "select Count(*) from newProduct";
            var totalCount6 = await _db.QuerySingleAsync<int>(query6);
            ViewBag.newProduct = totalCount6;





            return View();
        }
    }
}