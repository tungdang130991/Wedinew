using System;
using System.Collections.Generic;
using System.Text;
using WebEDI.Respository.ViewModels;
namespace WebEDI.Respository.Interface
{
    public interface IOrderDetailAllService
    {
        OrderDetailAllModel GetData(string orderID);
    }
}
