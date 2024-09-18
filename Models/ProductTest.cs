using Microsoft.VisualStudio.TestTools.UnitTesting;
using StoreAPI.Models;

namespace StoreAPITests
  {
  [TestClass]
  public class ProductTest
    {
    [TestMethod]
    public void Product_Initialization_SetsDefaultValues()
      {
      // Arrange
      var product = new Product();

      // Act & Assert
      Assert.IsNull(product.CategoryId, "CategoryId should be null by default");
      Assert.IsNull(product.Description, "Description should be null by default");
      Assert.IsNull(product.ImageOne, "ImageOne should be null by default");
      Assert.IsNull(product.ImageTwo, "ImageTwo should be null by default");
      Assert.IsNull(product.ImageThree, "ImageThree should be null by default");
      Assert.IsNull(product.ImageFour, "ImageFour should be null by default");
      Assert.IsNull(product.ImageFive, "ImageFive should be null by default");
      Assert.IsNull(product.UnitsInStock, "UnitsInStock should be null by default");
      Assert.IsNull(product.UnitsOnOrder, "UnitsOnOrder should be null by default");
      Assert.IsNull(product.UnitsReorderLevel, "UnitsReorderLevel should be null by default");
      Assert.IsNull(product.SupplierId, "SupplierId should be null by default");
      Assert.IsNull(product.UnitsSold, "UnitsSold should be null by default");
      Assert.IsNull(product.UnitWeight, "UnitWeight should be null by default");
      Assert.IsNull(product.UnitDimensions, "UnitDimensions should be null by default");
      Assert.IsNull(product.UnitCost, "UnitCost should be null by default");
      Assert.AreEqual(0, product.Price, "Price should default to 0");
      }

    [TestMethod]
    public void Product_SetProperties_UpdatesValues()
      {
      // Arrange
      var product = new Product();

      // Act
      
      product.Name = "Test Product";
      product.Price = 19.99m;
      product.CategoryId = 2;
      product.Description = "A test product";
      product.ImageOne = "image1.jpg";
      product.ImageTwo = "image2.jpg";
      product.ImageThree = "image3.jpg";
      product.ImageFour = "image4.jpg";
      product.ImageFive = "image5.jpg";
      product.UnitsInStock = 50;
      product.UnitsOnOrder = 10;
      product.UnitsReorderLevel = 5;
      product.SupplierId = 1;
      product.UnitsSold = 20;
      product.UnitWeight = 1.5m;
      product.UnitDimensions = "10x10x5";
      product.UnitCost = 9.99m;

      // Assert
      
      Assert.AreEqual("Test Product", product.Name);
      Assert.AreEqual(19.99m, product.Price);
      Assert.AreEqual(2, product.CategoryId);
      Assert.AreEqual("A test product", product.Description);
      Assert.AreEqual("image1.jpg", product.ImageOne);
      Assert.AreEqual("image2.jpg", product.ImageTwo);
      Assert.AreEqual("image3.jpg", product.ImageThree);
      Assert.AreEqual("image4.jpg", product.ImageFour);
      Assert.AreEqual("image5.jpg", product.ImageFive);
      Assert.AreEqual(50, product.UnitsInStock);
      Assert.AreEqual(10, product.UnitsOnOrder);
      Assert.AreEqual(5, product.UnitsReorderLevel);
      Assert.AreEqual(1, product.SupplierId);
      Assert.AreEqual(20, product.UnitsSold);
      Assert.AreEqual(1.5m, product.UnitWeight);
      Assert.AreEqual("10x10x5", product.UnitDimensions);
      Assert.AreEqual(9.99m, product.UnitCost);
      }
    }
  }
