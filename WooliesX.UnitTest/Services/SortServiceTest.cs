using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NSubstitute;
using WooliesX.Model;
using WoooliesX.Service;

namespace WooliesX.UnitTest.Services
{
    [TestClass]
    public class SortServiceTest
    {
        const string jsonResponse = "[{\"name\":\"Test Product A\",\"price\":99.99,\"quantity\":0.0},{\"name\":\"Test Product B\",\"price\":101.99,\"quantity\":0.0},{\"name\":\"Test Product C\",\"price\":10.99,\"quantity\":0.0},{\"name\":\"Test Product D\",\"price\":5.0,\"quantity\":0.0},{\"name\":\"Test Product F\",\"price\":999999999999.0,\"quantity\":0.0}]";
        private ISortService _sortService;
        private HttpClient _client;

        [TestInitialize]
        public void Initialize()
        {
            //arrange
            var messageHandler = Substitute.For<MockHttpMessageHandler>(jsonResponse, HttpStatusCode.OK);
            var httpClient = new HttpClient(messageHandler);

            _sortService = Substitute.For<ISortService>();
            
        }

        [TestMethod]
        public async Task SortService_ProductResponse()
        {
            var lstProducts = new List<Product>()
            {
                new Product()
                {
                    Name = "Test Product A",
                    Price = 99.99M,
                    Quantity = 0
                },
                new Product()
                {
                    Name = "Test Product B",
                    Price = 101.99M,
                    Quantity = 0
                },
                new Product()
                {
                    Name = "Test Product C",
                    Price = 10.99M,
                    Quantity = 0
                },
                new Product()
                {
                    Name = "Test Product D",
                    Price = 5,
                    Quantity = 0
                },
                new Product()
                {
                    Name = "Test Product F",
                    Price = 999999999999,
                    Quantity = 0
                }
            };

            _sortService.SortProducts("High").Returns(lstProducts);
            //act
            var response = await _sortService.SortProducts("High");
            //assert
            Assert.AreEqual(5, response.Count);
        }

        [TestMethod]
        public async Task SortService_SortAsending()
        {
            var lstProducts = new List<Product>()
            {
                new Product()
                {
                    Name = "Test Product A"
                }
            };
            _sortService.SortProducts("Ascending").Returns(lstProducts);

            //act
            var firstProduct = await _sortService.SortProducts("Ascending");
            //assert
            Assert.AreEqual("Test Product A", firstProduct[0].Name);
        }

        [TestMethod]
        public async Task SortService_SortDescending()
        {
            var lstProducts = new List<Product>()
            {
                new Product()
                {
                    Name = "Test Product F"
                }
            };
            _sortService.SortProducts("Descending").Returns(lstProducts);
            //act
            var firstProduct = await _sortService.SortProducts("Descending");
            //assert
            Assert.AreEqual("Test Product F", firstProduct[0].Name);
        }

        [TestMethod]
        public async Task SortService_SortLow()
        {
            var lstProducts = new List<Product>()
            {
                new Product()
                {
                    Name = "Test Product",
                    Price = 5.0M
                }
            };
            _sortService.SortProducts("Low").Returns(lstProducts);

            //arrange
            decimal price = 5.0M;
            //act
            var firstProduct = await _sortService.SortProducts("Low");
            //assert
            Assert.AreEqual(price, firstProduct[0].Price);
        }

        [TestMethod]
        public async Task SortService_SortHigh()
        {

            var lstProducts = new List<Product>()
            {
                new Product()
                {
                    Name = "Test Product",
                    Price = 999999999999.0M
                }
            };
            _sortService.SortProducts("High").Returns(lstProducts);

            //arrange
            decimal price = 999999999999.0M;
            //act
            var firstProduct = await _sortService.SortProducts("High");
            //assert
            Assert.AreEqual(price, firstProduct[0].Price);
        }

    }
}
