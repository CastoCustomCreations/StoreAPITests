using Microsoft.VisualStudio.TestTools.UnitTesting;
using StoreAPI.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using StoreAPI.Models;
using StoreAPI.Data;
using Microsoft.EntityFrameworkCore;
namespace StoreAPI.Controllers.Tests
  {
  [TestClass()]
  public class CustomersControllerTests
    {
    
    private Mock<StoreContext> _mockContext;
    private CustomersController _controller;
    private List<Customer> _customers;

    [TestInitialize]
    public void Setup()
      {
      // Initialize mock data
      _customers = new List<Customer>
            {
                new Customer { Id = 1, FirstName = "John", LastName = "Doe", Email = "john@example.com" },
                new Customer { Id = 2, FirstName = "Jane", LastName = "Smith", Email = "jane@example.com" }
            };

      // Set up a mock DbSet for Customers
      var mockSet = new Mock<DbSet<Customer>>();
      mockSet.As<IQueryable<Customer>>().Setup(m => m.Provider).Returns(_customers.AsQueryable().Provider);
      mockSet.As<IQueryable<Customer>>().Setup(m => m.Expression).Returns(_customers.AsQueryable().Expression);
      mockSet.As<IQueryable<Customer>>().Setup(m => m.ElementType).Returns(_customers.AsQueryable().ElementType);
      mockSet.As<IQueryable<Customer>>().Setup(m => m.GetEnumerator()).Returns(_customers.AsQueryable().GetEnumerator());

      // Mock the context to return the DbSet
      _mockContext = new Mock<StoreContext>();
      _mockContext.Setup(c => c.Customers).Returns(mockSet.Object);

      // Initialize the controller
      _controller = new CustomersController(_mockContext.Object);
      }

    // Test GetCustomers
    [TestMethod]
    public void GetCustomers_ReturnsOkResult_WithListOfCustomers()
      {
      // Act
      var result = _controller.GetCustomers() as OkObjectResult;

      // Assert
      Assert.IsNotNull(result);
      Assert.AreEqual(200, result.StatusCode);
      var customers = result.Value as List<Customer>;
      Assert.AreEqual(2, customers.Count);
      }

    // Test GetCustomer by ID (existing customer)
    [TestMethod]
    public void GetCustomer_ExistingId_ReturnsOkResult()
      {
      // Act
      var result = _controller.GetCustomer(1) as OkObjectResult;

      // Assert
      Assert.IsNotNull(result);
      Assert.AreEqual(200, result.StatusCode);
      var customer = result.Value as Customer;
      Assert.AreEqual(1, customer.Id);
      Assert.AreEqual("John", customer.FirstName);
      }

    // Test GetCustomer by ID (non-existing customer)
    [TestMethod]
    public void GetCustomer_NonExistingId_ReturnsNotFound()
      {
      // Act
      var result = _controller.GetCustomer(99);

      // Assert
      Assert.IsInstanceOfType(result, typeof(NotFoundResult));
      }

    // Test AddCustomer
    [TestMethod]
    public void AddCustomer_ValidInput_ReturnsOkResult()
      {
      // Arrange
      var newCustomer = new AddCustomerDTO
        {
        FirstName = "Alice",
        LastName = "Johnson",
        Address1 = "123 Main St",
        City = "Sample City",
        State = "NY",
        Zipcode = "12345",
        Phone = "555-1234",
        Email = "alice@example.com",
        UserName = "alice123",
        Password = "password"
        };

      // Act
      var result = _controller.AddEmployee(newCustomer) as OkObjectResult;

      // Assert
      Assert.IsNotNull(result);
      Assert.AreEqual(200, result.StatusCode);
      var customer = result.Value as Customer;
      Assert.AreEqual("Alice", customer.FirstName);
      Assert.AreEqual("Johnson", customer.LastName);
      }

    // Test DeleteCustomer
    [TestMethod]
    public void DeleteCustomer_ExistingId_ReturnsOkResult()
      {
      // Act
      var result = _controller.DeleteEmployee(Guid.NewGuid()) as OkResult;

      // Assert
      Assert.IsNotNull(result);
      Assert.AreEqual(200, result.StatusCode);
      }

    // Test DeleteCustomer (non-existing customer)
    [TestMethod]
    public void DeleteCustomer_NonExistingId_ReturnsNotFound()
      {
      // Act
      var result = _controller.DeleteEmployee(Guid.NewGuid());

      // Assert
      Assert.IsInstanceOfType(result, typeof(NotFoundResult));
      }
    }
  }