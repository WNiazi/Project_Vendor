using System.Collections.Generic;

namespace ProjectVendor.Models
{
  public class Order
  {
    private static List<Order> _instances = new List<Order> { };
    public string OrderName { get; set; }
    public int Id { get; }
    public int Cost { get; set; }
    public int Quantity { get; set; }
    public string Description { get; set; }

    public Order(string orderName, string description, int quantity, int cost)
    {
      OrderName = orderName;
      Description = description;
      Quantity = quantity;
      Cost = cost;
      Id = _instances.Count;
      _instances.Add(this);

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
  }
}