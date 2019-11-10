using System;
using System.Collections.Generic;
using System.Text;

namespace WooliesX.Model
{
    public class Customer
    {
        public int CustomerId { get; set; }
        public List<Product> Products { get; set; }
    }
}
