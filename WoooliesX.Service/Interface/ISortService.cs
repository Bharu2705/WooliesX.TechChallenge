using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using WooliesX.Model;

namespace WoooliesX.Service
{
    public interface ISortService
    {
        Task<List<Product>> SortProducts(string sortOptions);
    }
}
