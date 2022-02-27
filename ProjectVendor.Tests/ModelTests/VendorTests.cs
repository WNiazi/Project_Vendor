using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using ProjectVendor.Models;
using System;

namespace ProjectVendor.Tests
{
  [TestClass]
  //any code put into dispose, runs after the test; this is because our GetAll is not returning empty.  "I" in front; you can use IMotor and OnSwitch  (these are interface they add more functionality to class) there are abstract class (anima) in which the child can override it as an object (chimpazee). it will be presented chimpazee:animal ;  you can call on chimpazee and method walk like this: chimpazee.walk() vs animal.walk().  difference between interfaces and abstract is that inferance can be many but only on abstract
  public class VendorTests : IDisposable
  {

    public void Dispose()
    {
      Vendor.ClearAll();
    }

    [TestMethod]
    public void VendorConstructor_CreatesInstanceOfVendor_Vendor()
    {
      Vendor newVendor = new Vendor("test", "test");
      Assert.AreEqual(typeof(Vendor), newVendor.GetType());
    }

    [TestMethod]
    public void GetListOfOrder_ReturnsListOfOrder_String()
    {
      //Arrange
      string typeOfVendor = "Baked Goods Vendor";
      string vendorName = "Tommies";

      //Act
      Vendor newVendor = new Vendor(vendorName, typeOfVendor);
      string result = newVendor.Name;
      string result2 = newVendor.TypeOfVendor;

      //Assert
      Assert.AreEqual(vendorName, result);
      Assert.AreEqual(typeOfVendor, result2);
    }
    [TestMethod]
    public void GetId_VendorsInstantiateWithAnIdAndGetterReturns_Int()
    {
      //Arrange
      string typeOfVendor = "Baked goods";
      string name = "Tommies";
      Vendor newVendor = new Vendor(name, typeOfVendor);

      //Act
      int result = newVendor.Id;

      //Assert
      Assert.AreEqual(1, result);
    }

    [TestMethod]
    public void SetListOfOrder_SetListOfOrder_String()
    {
      //Arrange
      string typeOfVendor = "Baked Goods";
      string name = "Tommies";
      Vendor newVendor = new Vendor(name, typeOfVendor);

      //Act
      string updatedVendor = "Sandwich Goods";
      newVendor.TypeOfVendor = updatedVendor;
      string result = newVendor.TypeOfVendor;

      //Assert
      Assert.AreEqual(updatedVendor, result);
    }

    [TestMethod]
    public void GetAll_ReturnsEmptyList_VendorList()
    {
      // Arrange
      List<Vendor> newVendor = new List<Vendor> { };

      // Act
      List<Vendor> result = Vendor.GetAll();

      foreach (Vendor thisVendor in result)
      {
        Console.WriteLine("Output from empty list GetAll test: " + thisVendor.TypeOfVendor);
      }

      // Assert
      CollectionAssert.AreEqual(newVendor, result);
    }

    [TestMethod]
    public void GetAll_ReturnsVendors_VendorList()
    {
      //Arrange
      // string name = "Tommies";
      // string name2 = "Billies";
      // string typeOfVendor = "Baked Goods";
      // string typeOfVendor2 = "Sandwich Goods";
      Vendor newVendor1 = new Vendor("Tommies", "Baked Goods");
      Vendor newVendor2 = new Vendor("Billies", "Sandwich Goods");
      List<Vendor> newVendor = new List<Vendor> { newVendor1, newVendor2 };

      //Act
      List<Vendor> result = Vendor.GetAll();

      foreach (Vendor thisVendor in result)
      {
        Console.WriteLine("Output from second GetAll test: " + thisVendor.TypeOfVendor);
      }

      //Assert
      CollectionAssert.AreEqual(newVendor, result);
    }
    [TestMethod]
    public void Find_ReturnsCorrectVendor_Vendor()
    {
      //Arrange
      string name = "Tommies";
      string name2 = "Billies";
      string typeOfVendor = "Baked Goods";
      string typeOfVendor2 = "Sandwich Goods";
      Vendor newVendor1 = new Vendor(name, typeOfVendor);
      Vendor newVendor2 = new Vendor(name2, typeOfVendor2);

      //Act
      Vendor result = Vendor.Find(2);

      //Assert
      Assert.AreEqual(newVendor2, result);
    }

  }
}
