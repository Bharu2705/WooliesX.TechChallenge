using System;
using System.Collections.Generic;
using System.Text;

namespace WooliesX.Model
{
    public class TrolleyRequest
    {
        public List<Product> Products { get; set; }
        public List<Specials> Specials { get; set; }
        public List<Quantities> Quantities { get; set; }
    }
}
