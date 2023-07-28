using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using HairSalon.Models;
using System.Collections.Generic;
using System.Linq;

namespace HairSalon.Controllers
{
  public class ClientsController : Controller
  {
    private readonly HairSalonContext _db;

    public ClientsController(HairSalonContext db)
    {
      _db = db;
    }
    
    // full client list
    public ActionResult Index()
    {
      // get a list of clients from the DB, plus the stylist each belongs to
      List<Client> model = _db.Clients
                            .Include(client => client.Stylist)
                            .ToList();
      return View(model);
    }

    // add client form page
    public ActionResult Create()
    {
      ViewBag.StylistId = new SelectList(_db.Stylists, "StylistId", "Name");
      return View();
    }

    // add client form submission route
    [HttpPost]
    public ActionResult Create(Client client)
    {
      if (client.StylistId == 0)
      {
        // cannot create client with no assigned stylist
        // if user tries, loop back to create form without updating DB
        return RedirectToAction("Create");
      }
      _db.Clients.Add(client);
      _db.SaveChanges();
      return RedirectToAction("Index");
    }

    // client detail page
    public ActionResult Details(int id)
    {
      // queries the _db object's clients list, finds the first that matches 
      // relevant id, then returns that client
      Client thisClient = _db.Clients
                            .Include(client => client.Stylist)
                            .FirstOrDefault(client => client.ClientId == id);
      return View(thisClient);
    }
  }
}
