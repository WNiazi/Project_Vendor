using System.Collections.Generic;

namespace ProjectVendor.Models
{
  public class Vendor
  {
    public string Name { get; set; }
    public string TypeOfVendor { get; set; }
    public int Id { get; }
    private static List<Vendor> _instances = new List<Vendor> { };
    //this will provide all vendors that user creates
    //below helps hold all in a list,  when it is added
    //"this" is used to reference what is activately created

    public List<Order> Orders { get; set; }
    //above helps ability to link Order and vendors (unsure where it goes)
    public Vendor(string name, string typeOfVendor)
    {
      Name = name;
      TypeOfVendor = typeOfVendor;
      _instances.Add(this);
      Id = _instances.Count;
      Orders = new List<Order> { };
    }
    //since List is a static variable you have to declare it and call the class itself.  so it will go Vendor.GetAll

    public static List<Vendor> GetAll()
    {
      return _instances;
    }
    //clearall is not built in we had to add it ourselves; also static method
    public static void ClearAll()
    {
      _instances.Clear();
    }
    public static Vendor Find(int searchId)
    {
      return _instances[searchId - 1];
    }
    public void AddOrder(Order order)
    {
      Orders.Add(order);
    }
  }
}


//below is the example of overloaded constructed.  you do this to make sure you can pass one or two properties to the object
//why do this? change order of things being passed through or different types of parameters strings vs int
// public Item(string description)
// {
//   Description = description;
//   _instances.Add(this);
// }

// public Item(string description, int priority)
//   : this(description)
//(notes: :this(description will take the object from above))
// {
//   Priority = priority;