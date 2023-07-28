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
}
