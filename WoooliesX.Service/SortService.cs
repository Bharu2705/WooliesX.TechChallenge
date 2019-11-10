using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using WooliesX.Model;
using System.Linq;
using NLog;

namespace WoooliesX.Service
{
    public class SortService : ISortService
    {
        private readonly HttpClient _httpClient;
        private readonly Logger logger = LogManager.GetCurrentClassLogger();

        public SortService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<List<Product>> SortProducts(string sortOptions)
        {
            if (string.Equals(sortOptions, Constants.SortOption.Recommended, StringComparison.OrdinalIgnoreCase))
            {
                return await GetShopperHistory();
            }
            var productList = await GetProducts();
            return SortProductList(sortOptions, productList);
        }

        private async Task<List<Product>> GetProducts()
        {
            return await ResourceLookup<List<Product>>(Constants.Url.ProductResourceApiUrl);
        }

        private async Task<Product> ResourceLookup<Product>(string resourceEndpoint)
        {
            var response = await _httpClient.GetStringAsync($"{resourceEndpoint}?token={Constants.Authentication.Token}");
            var productList = JsonConvert.DeserializeObject<Product>(response);
            return productList;
        }

        private async Task<List<Product>> GetShopperHistory()
        {
            var customers = await ResourceLookup<List<Customer>>(Constants.Url.CustomerResourceApiUrl);
            var customerList = new List<Product>();
            foreach (Customer c in customers)
            {
                customerList.AddRange(c.Products);
            }
            return customerList;
        }

        private List<Product> SortProductList(string sortOptions, List<Product> productForSort)
        {
            var result = new List<Product>();
            switch (sortOptions)
            {
                case Constants.SortOption.Low:
                    result = productForSort.OrderBy(x => x.Price).ToList();
                    break;
                case Constants.SortOption.High:
                    result = productForSort.OrderByDescending(x => x.Price).ToList();
                    break;
                case Constants.SortOption.Ascending:
                    result = productForSort.OrderBy(x => x.Name).ToList();
                    break;
                case Constants.SortOption.Descending:
                    result = productForSort.OrderByDescending(x => x.Name).ToList();
                    break;
                default:
                    result = productForSort.ToList();
                    break;
            }
            return result;
        }
    }
}
