using Microsoft.AspNetCore.Mvc;
using ProjectVendor.Models;
using System.Collections.Generic;
using System;

namespace ProjectVendor.Controllers
{
  public class VendorController : Controller
  {
    [HttpGet("/vendors")]
    public ActionResult Index()
    {
      List<Vendor> allVendors = Vendor.GetAll();
      return View(allVendors);
    }

    // //below is attached to the form, allows to create "NEW" -in the newcsthml paget, vendors
    [HttpGet("/vendors/new")]
    public ActionResult New()
    {
      return View();
    }
    // //below is attached to the form , and creates the object for vendors
    [HttpPost("/vendors")]
    public ActionResult Create(string name, string typeOfVendor)
    {
      Vendor myVendor = new Vendor(name, typeOfVendor);
      return RedirectToAction("Index");
      //"index is the function up top, index(). only takes strings. its' function is to show the list of all the vendors 
    }

    [HttpPost("/vendors/delete")]
    public ActionResult DeleteAll()
    {
      Vendor.ClearAll();
      return View();
    }

    //finding one vendor and attaching orders in Dictionary ; you are getting it here
    [HttpGet("/vendors/{Id}")]
    public ActionResult Show(int Id)
    {
      Dictionary<string, object> model = new Dictionary<string, object>();
      Vendor selectedVendor = Vendor.Find(Id);
      List<Order> vendorOrders = selectedVendor.Orders;
      model.Add("vendor", selectedVendor);
      model.Add("order", vendorOrders);
      return View(model);
    }
    //here you are attaching the vendorId and object of order together and posting it 

    [HttpPost("/vendors/{vendorId}/order")]

    public ActionResult Create(int vendorId, string orderName, string description, int cost, int quantity)
    {
      Dictionary<string, object> model = new Dictionary<string, object>();
      Vendor foundVendor = Vendor.Find(vendorId);
      Order newOrder = new Order(orderName, description, cost, quantity);
      foundVendor.AddOrder(newOrder);
      List<Order> vendorOrders = foundVendor.Orders;
      model.Add("order", vendorOrders);
      model.Add("vendor", foundVendor);
      return View("Show", model);
    }

  }
}