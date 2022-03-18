using Microsoft.AspNetCore.Mvc;

namespace StringFactory.Controllers
{
    public class HomeController : Controller
    {
      [HttpGet("/")]
      public ActionResult Index()
      {
        return View();
      }
    }
}