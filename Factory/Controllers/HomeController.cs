using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using StringFactory.Models;
using System.Collections.Generic;
using System.Linq;

namespace StringFactory.Controllers
{
    public class HomeController : Controller
    {
      private readonly StringFactoryContext _db;
      public HomeController(StringFactoryContext db)
      {
        _db = db;
      }
      [HttpGet("/")]
      public ActionResult Index()
      {
        return View();
      }

      [HttpGet("/Both")]
      public ActionResult Both()
      {
        var workerguys = _db.Engineers.ToList();
        var fixablestuff = _db.Machines.ToList();
        return View();
      }
    }
}