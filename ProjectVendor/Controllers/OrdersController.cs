using System.Collections.Generic;
using System;
using Microsoft.AspNetCore.Mvc;
using ProjectVendor.Models;

namespace ProjectVendor.Controllers
{
  public class OrderController : Controller
  {
    //below creating a new order with certain vendors 
    [HttpGet("/vendors/{vendorId}/order/new")]
    public ActionResult New(int vendorId)
    {
      Vendor vendor = Vendor.Find(vendorId);
      return View(vendor);
    }

    [HttpGet("vendors/{vendorId}/order/{orderId}")]
    public ActionResult Show(int vendorId, int orderId)
    {
      Dictionary<string, object> model = new Dictionary<string, object>();
      Order selectedOrder = Order.Find(orderId);
      Vendor findVendor = Vendor.Find(vendorId);
      model.Add("order", selectedOrder);
      model.Add("vendor", findVendor);
      return View(model);
    }
    //below is claimed in the vendor object ("add and list") therefore not needed to placed in Object controller
    // [HttpPost("/vendors/{vendorId}/order/{orderId}")]
    // public ActionResult Create(int orderId, string vendorTypeOfVendor)
    // {
    //   Dictionary<string, object> model = new Dictionary<string, object>();
    //   Order foundOrder = Order.Find(orderId);
    //   Vendor newVendor = new Vendor("", vendorTypeOfVendor);
    //   foundOrder.AddVendor(newVendor);
    //   List<Vendor> totalInfo = foundOrder.Vendor;
    //   model.Add("vendors", totalInfo);
    //   model.Add("order", foundOrder);
    //   return View("Show", model);
    // }
  }
}