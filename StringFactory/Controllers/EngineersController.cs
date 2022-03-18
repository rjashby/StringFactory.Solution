using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using StringFactory.Models;
using System.Collections.Generic;
using System.Linq;

namespace StringFactory.Controllers
{
  public class EngineersController : Controller
  {
    private readonly StringFactoryContext _db;

    public EngineersController(StringFactoryContext db)
    {
      _db = db;
    }

    public ActionResult Index()
    {
      return View(_db.Engineers.ToList());
    }

    public ActionResult Create()
    {
      ViewBag.MachineId = new SelectList(_db.Machines, "MachineId", "Name");
      return View();
    }

    [HttpPost]
    public ActionResult Create(Engineer engineer, int MachineId)
    {
      _db.Engineers.Add(engineer);
      _db.SaveChanges();
      if (MachineId != 0)
      {
        _db.MachineItem.Add(new MachineItem() { MachineId = MachineId, ItemId = item.ItemId });
        _db.SaveChanges();
      }
      return RedirectToAction("Index");
    }

    public ActionResult Details(int id)
    {
      var thisItem = _db.Engineers
          .Include(item => item.JoinEntities)
          .ThenInclude(join => join.Machine)
          .FirstOrDefault(item => item.ItemId == id);
      return View(thisItem);
    }

    public ActionResult Edit(int id)
    {
      var thisItem = _db.Engineers.FirstOrDefault(item => item.ItemId == id);
      ViewBag.MachineId = new SelectList(_db.Machines, "MachineId", "Name");
      return View(thisItem);
    }

    [HttpPost]
    public ActionResult Edit(Item item, int MachineId)
    {
      if (MachineId != 0)
      {
        _db.MachineEngineer.Add(new MachineEngineer() { MachineId = MachineId, EngineerId = enginner.EngineerId });
      }
      _db.Entry(item).State = EntityState.Modified;
      _db.SaveChanges();
      return RedirectToAction("Index");
    }

    public ActionResult AddMachine(int id)
    {
      var thisItem = _db.Engineers.FirstOrDefault(item => item.ItemId == id);
      ViewBag.MachineId = new SelectList(_db.Machines, "MachineId", "Name");
      return View(thisItem);
    }

    [HttpPost]
    public ActionResult AddMachine(Item item, int MachineId)
    {
      if (MachineId != 0)
      {
        _db.MachineItem.Add(new MachineItem() { MachineId = MachineId, ItemId = item.ItemId });
        _db.SaveChanges();
      }
      return RedirectToAction("Index");
    }

    public ActionResult Delete(int id)
    {
      var thisItem = _db.Engineers.FirstOrDefault(item => item.ItemId == id);
      return View(thisItem);
    }

    [HttpPost, ActionName("Delete")]
    public ActionResult DeleteConfirmed(int id)
    {
      var thisItem = _db.Engineers.FirstOrDefault(item => item.ItemId == id);
      _db.Engineers.Remove(thisItem);
      _db.SaveChanges();
      return RedirectToAction("Index");
    }

    [HttpPost]
    public ActionResult DeleteMachine(int joinId)
    {
      var joinEntry = _db.MachineItem.FirstOrDefault(entry => entry.MachineItemId == joinId);
      _db.MachineItem.Remove(joinEntry);
      _db.SaveChanges();
      return RedirectToAction("Index");
    }
  }
}