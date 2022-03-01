using Microsoft.VisualStudio.TestTools.UnitTesting;
using ProjectVendor.Models;
using System.Collections.Generic;
using System;

namespace ProjectVendor.Tests
{
  [TestClass]
  public class OrderTests : IDisposable
  {

    public void Dispose()
    {
      Order.ClearAll();
    }

    [TestMethod]
    public void OrderConstructor_CreatesInstanceOfOrder_Order()
    {
      Order newOrder = new Order("test category", "test", 1, 2);
      Assert.AreEqual(typeof(Order), newOrder.GetType());
    }

    [TestMethod]
    public void GetName_ReturnsIndividualItems_String()
    {
      //Arrange
      string name = "Cake";
      string description = "Big Cake";
      int quantity = 1;
      int cost = 20;

      Order newOrder = new Order(name, description, quantity, cost);

      //Act
      string result = newOrder.OrderName;
      string result2 = newOrder.Description;
      int result3 = newOrder.Quantity;
      int result4 = newOrder.Cost;

      //Assert
      Assert.AreEqual(name, result);
      Assert.AreEqual(description, result2);
      Assert.AreEqual(quantity, result3);
      Assert.AreEqual(cost, result4);
    }

    [TestMethod]
    public void GetAll_ReturnsAllObjects_OrderList()
    {
      //Arrange
      string name = "Cake";
      string name2 = "Cookie";
      string description = "Big Cake";
      string description2 = "Small Cookie";

      int quantity = 1;
      int quantity2 = 12;
      int cost = 20;
      int cost2 = 10;

      Order newOrder1 = new Order(name, description, quantity, cost);
      Order newOrder2 = new Order(name2, description2, cost2, quantity2);


      List<Order> newList = new List<Order> { newOrder1, newOrder2 };

      //Act
      List<Order> result = Order.GetAll();

      //Assert
      CollectionAssert.AreEqual(newList, result);
    }

    [TestMethod]
    public void Find_ReturnsCorrectOrder_Order()
    {
      string name = "Cake";
      string name2 = "Cookie";
      string description = "Big Cake";
      string description2 = "Small Cookie";
      int quantity = 1;
      int quantity2 = 12;
      int cost = 20;
      int cost2 = 10;

      Order newOrder1 = new Order(name, description, quantity, cost);
      Order newOrder2 = new Order(name2, description2, quantity2, cost2);

      //       //Act
      Order result = Order.Find(2);

      //       //Assert
      Assert.AreEqual(newOrder2, result);
    }


    [TestMethod]
    public void AddOrder_AssociatesVendortoOrders_OrderList()
    {
      //Arrange
      Order newOrder = new Order("testname", "testdescription", 1, 20);
      List<Order> newList = new List<Order> { newOrder };
      string vendorName = "Tommies";
      string typeOfVendor = "Baked Goods";
      Vendor newVendor = new Vendor(vendorName, typeOfVendor);
      newVendor.AddOrder(newOrder);

      //Act
      List<Order> result = newVendor.Orders;

      //Assert
      CollectionAssert.AreEqual(newList, result);
    }
  }
}