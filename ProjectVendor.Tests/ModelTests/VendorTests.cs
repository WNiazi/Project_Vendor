using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using ProjectVendor.Models;
using System;

namespace ProjectVendor.Tests
{
  [TestClass]
  //any code put into dispose, runs after the test; this is because our GetAll is not returning empty
  public class VendorTests : IDisposable
  {

    public void Dispose()
    {
      Vendor.ClearAll();
    }

    [TestMethod]
    public void VendorConstructor_CreatesInstanceOfVendor_Vendor()
    {
      Vendor newVendor = new Vendor("test");
      Assert.AreEqual(typeof(Vendor), newVendor.GetType());
    }

    [TestMethod]
    public void GetListOfOrder_ReturnsListOfOrder_String()
    {
      //Arrange
      string listOfOrder = "Walk the dog.";

      //Act
      Vendor newVendor = new Vendor(listOfOrder);
      string result = newVendor.ListOfOrder;

      //Assert
      Assert.AreEqual(listOfOrder, result);
    }

    [TestMethod]
    public void SetListOfOrder_SetListOfOrder_String()
    {
      //Arrange
      string listOfOrder = "Walk the dog.";
      Vendor newVendor = new Vendor(listOfOrder);

      //Act
      string updatedVendor = "Do the dishes";
      newVendor.ListOfOrder = updatedVendor;
      string result = newVendor.ListOfOrder;

      //Assert
      Assert.AreEqual(updatedVendor, result);
    }

    [TestMethod]
    public void GetAll_ReturnsEmptyList_ItemList()
    {
      // Arrange
      List<Vendor> newVendor = new List<Vendor> { };

      // Act
      List<Vendor> result = Vendor.GetAll();

      // Assert
      CollectionAssert.AreEqual(newVendor, result);
    }

    //     [TestMethod]
    //     public void GetAll_ReturnsItems_ItemList()
    //     {
    //       //Arrange
    //       string listOfOrder01 = "Walk the dog";
    //       string listOfOrder02 = "Wash the dishes";
    //       Vendor newVendor1 = new ListOfOrders(description01);
    //       Vendor newVendor2 = new ListOfOrders(description02);
    //       Vendor<Item> newVendor = new Vendor<Item> { newVendor1, newVendor2 };

    //       //Act
    //       List<Vendor> result = Vendor.GetAll();

    //       //Assert
    //       CollectionAssert.AreEqual(newVendor, result);
    //     }
  }
}
