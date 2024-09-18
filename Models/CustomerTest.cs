using Microsoft.VisualStudio.TestTools.UnitTesting;
using StoreAPI.Models;

namespace StoreAPITests
  {
  [TestClass]
  public class CustomerTests
    {
    [TestMethod]
    public void Customer_Initialization_SetsDefaultValues()
      {
      // Arrange
      var customer = new Customer();

      // Act & Assert
      Assert.IsNull(customer.FirstName, "FirstName should be null by default");
      Assert.IsNull(customer.LastName, "LastName should be null by default");
      Assert.IsNull(customer.Email, "Email should be null by default");

      Assert.IsNull(customer.Address1, "Address1 should be null by default");
      Assert.IsNull(customer.Address2, "Address2 should be null by default");
      Assert.IsNull(customer.City, "City should be null by default");
      Assert.IsNull(customer.State, "State should be null by default");
      Assert.IsNull(customer.Zipcode, "Zipcode should be null by default");
      Assert.IsNull(customer.Phone, "Phone should be null by default");
      Assert.IsNull(customer.UserName, "UserName should be null by default");
      Assert.IsNull(customer.Password, "Password should be null by default");
      }

    [TestMethod]
    public void Customer_SetProperties_UpdatesValues()
      {
      // Arrange
      var customer = new Customer();

      // Act
      customer.FirstName = "John";
      customer.LastName = "Doe";
      customer.Email = "john.doe@example.com";
      customer.Address1 = "123 Main St";
      customer.City = "Springfield";
      customer.State = "IL";
      customer.Zipcode = "62701";
      customer.Phone = "555-1234";

      // Assert
      Assert.AreEqual("John", customer.FirstName);
      Assert.AreEqual("Doe", customer.LastName);
      Assert.AreEqual("john.doe@example.com", customer.Email);
      Assert.AreEqual("123 Main St", customer.Address1);
      Assert.AreEqual("Springfield", customer.City);
      Assert.AreEqual("IL", customer.State);
      Assert.AreEqual("62701", customer.Zipcode);
      Assert.AreEqual("555-1234", customer.Phone);
      }
    }
  }
