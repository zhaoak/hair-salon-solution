using System.Collections.Generic;
using System;
using Microsoft.AspNetCore.Mvc;
using HairSalon.Models;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace HairSalon.Controllers;

public class StylistsController : Controller
{
  private readonly HairSalonContext _db;

  public StylistsController(HairSalonContext db)
  {
    _db = db;
  }

  // stylist list
  public ActionResult Index()
  {
    List<Stylist> model = _db.Stylists.ToList();
    return View(model);
  }

  // stylist registration form
  public ActionResult Create()
  {
    return View();
  }

  // stylist registration POST route
  [HttpPost]
  public ActionResult Create(Stylist stylist)
  {
    _db.Stylists.Add(stylist);
    _db.SaveChanges();
    return RedirectToAction("Index");
  }

  // individual stylist detail route
  public ActionResult Details(int id)
  {
    Stylist thisStylist = _db.Stylists
                                .Include(stylist => stylist.Clients)
                                .FirstOrDefault(stylist => stylist.StylistId == id);
    return View(thisStylist);
  }

  // stylist edit form
  public ActionResult Edit(int id)
  {
    Stylist thisStylist = _db.Stylists.FirstOrDefault(stylist => stylist.StylistId == id);
    return View(thisStylist);
  }

  // stylist edit POST route
  [HttpPost]
  public ActionResult Edit(Stylist stylist)
  {
    _db.Stylists.Update(stylist);
    _db.SaveChanges();
    return RedirectToAction("Index");
  }
}
