using System.Collections.Generic;
using System;
using Microsoft.AspNetCore.Mvc;
using ProjectVendor.Models;

namespace ProjectVendor.Controllers
{
  public class OrderController : Controller
  {
    //below creating a new order using form with certain vendors 
    [HttpGet("/vendors/{vendorId}/order/new")]
    public ActionResult New(int vendorId)
    {
      Vendor vendor = Vendor.Find(vendorId);
      return View(vendor);
    }
    // Submission of the form created above
    [HttpPost("/vendors/{vendorId}/order/new")]
    public ActionResult New(int vendorId, string name, string description, int cost, int quantity)
    {
      Vendor findVendor = Vendor.Find(vendorId);
      Order order = new Order(name, description, cost, quantity);
      return RedirectToAction("Show");
    }

    [HttpPost("/vendors/{vendorId}/order/new")]
    public ActionResult Create(int vendorId, string orderName, string description, int cost, int quantity)
    {
      Dictionary<string, object> model = new Dictionary<string, object>();
      Vendor selectedVendor = Vendor.Find(vendorId);
      Order newOrder = new Order(orderName, description, cost, quantity);
      selectedVendor.AddOrder(newOrder);
      List<Order> vendorOrders = selectedVendor.Orders;
      model.Add("orders", vendorOrders);
      model.Add("vendor", selectedVendor);
      return View("Show", model);
    }
    // [HttpPost("vendors/{vendorId}/order")]
    // public ActionResult Show(int vendorId)
    // {
    //   Vendor findVendor = Vendor.Find(vendorId);
    //   display orders for that vendor
    //   return View(vendorId);
    // }

  }
}