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
      List<Vendor> Vendors = Vendor.GetAll();
      return View(Vendors);
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
    [HttpGet("/vendors/{id}")]
    public ActionResult Show(int id)
    {
      Dictionary<string, object> model = new Dictionary<string, object>();
      Vendor selectedVendor = Vendor.Find(id);
      List<Order> vendorOrders = selectedVendor.Orders;
      model.Add("vendor", selectedVendor);
      model.Add("order", vendorOrders);
      return View(model);
    }


    // [HttpGet("/vendor/{vendorId}/order/")]
    // public ActionResult Index(int vendorId)
    // {
    //   Vendor currentVendor = Vendor.Find(vendorId);
    //   return View(currentVendor);
    // }

    //here you are attaching the vendorId and object of order together and posting it 
    // [HttpPost("/vendors/{vendorId}/order/new")]
    // public ActionResult Create(int vendorId, string orderName, string description, int cost, int quantity)
    // {
    //   Dictionary<string, object> model = new Dictionary<string, object>();
    //   Vendor selectedVendor = Vendor.Find(vendorId);
    //   Order newOrder = new Order(orderName, description, cost, quantity);
    //   selectedVendor.AddOrder(newOrder);
    //   List<Order> vendorOrders = selectedVendor.Orders;
    //   model.Add("orders", vendorOrders);
    //   model.Add("vendor", selectedVendor);
    //   return View("Show", model);
    // }

  }
}