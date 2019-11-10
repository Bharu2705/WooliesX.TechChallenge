using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using WooliesX.Model;

namespace WoooliesX.Service
{
    public interface ITrolleyService
    {
        Task<decimal> TrolleyTotal(TrolleyRequest postRequest);
    }
}
