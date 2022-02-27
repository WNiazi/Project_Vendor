using Microsoft.AspNetCore.Mvc;
using ProjectVendor.Models;
using System.Collections.Generic;

namespace ProjectVendor.Controllers
{
  public class HomeController : Controller
  {
    [HttpGet("/")]
    public ActionResult Index()
    {
      return View();
    }
  }
}
