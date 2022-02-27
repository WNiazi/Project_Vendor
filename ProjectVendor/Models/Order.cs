using System.Collections.Generic;

namespace ProjectVendor.Models
{
  public class Order
  {
    private static List<Order> _instances = new List<Order> { };
    public string Name { get; set; }
    public int Id { get; }
    public int Cost { get; set; }
    public int Quantity { get; set; }
    public string Description { get; set; }
    // public List<Vendor> Vendor { get; set; }-unsure if it goes here or in vendors
    public Order(string name, string description, int quantity, int cost)
    {
      Name = name;
      Description = description;
      Quantity = quantity;
      Cost = cost;
      _instances.Add(this);
      Id = _instances.Count;
      //Vendor = new List<Vendor> { };
    }

    public static void ClearAll()
    {
      _instances.Clear();
    }
    public static List<Order> GetAll()
    {
      return _instances;
    }
    public static Order Find(int searchId)
    {
      return _instances[searchId - 1];
    }
    // public void AddVendor(Vendor vendor)
    // {
    //   Vendor.Add(vendor);
    // }
  }
}