using Microsoft.AspNetCore.Mvc;
using HairSalon.Models;
using System.Collections.Generic;
using System;

namespace HairSalon.Controllers
{
  public class HomeController : Controller
  {
    [HttpGet("/")]
    public ActionResult Index()
    {
      return View(Stylist.GetAll());
    }

    [HttpGet("/add-stylist")]
    public ActionResult AddStylist()
    {
      return View();
    }

    [HttpPost("/stylist-hired")]
    public ActionResult StyListAdded()
    {
      Stylist newStylist = new Stylist(Request.Form["stylist-name"]);
      newStylist.Save();

      return View("Index", Stylist.GetAll());
    }

    [HttpPost("/stylists-deleted")]
    public ActionResult DeleteAllStylists()
    {
      Stylist.DeleteAll();
      return View("Index", Stylist.GetAll());
    }

    [HttpGet("/stylist-details/{id}")]
    public ActionResult StylistDetails(int id)
    {
      return View(Stylist.Find(id));
    }

    [HttpGet("/stylist-details/{id}/add-client")]
    public ActionResult AddClient(int id)
    {
      return View(Stylist.Find(id));
    }

    [HttpPost("/stylist-details/{id}/client-added")]
    public ActionResult ClientAdded(int id)
    {
      Client newClient = new Client(Request.Form["client-name"], id);
      newClient.Save();

      return View("StylistDetails", Stylist.Find(id));
    }

    [HttpGet("/stylist-details/{styleId}/edit-client/{clientId}")]
    public ActionResult EditClient(int styleId, int clientId)
    {
      Dictionary<string, object> model = new Dictionary<string, object> {};
      model.Add("stylist", Stylist.Find(styleId));
      model.Add("client", Client.Find(clientId));

      return View(model);
    }

    [HttpPost("/stylist-details/{styleId}/client-edited/{clientId}")]
    public ActionResult ClientEdited(int styleId, int clientId)
    {
      Client.Find(clientId).Update(Request.Form["client-edited"]);

      return View("StylistDetails", Stylist.Find(styleId));
    }

    [HttpPost("/stylist-details/{styleId}/client-deleted/{clientId}")]
    public ActionResult ClientDeleted(int styleId, int clientId)
    {
      Client.Find(clientId).Delete();

      return View("StylistDetails", Stylist.Find(styleId));
    }

  }
}
