using System;
using System.Collections.Generic;
using System.Text;
using WebEDI.Respository.ViewModels;
namespace WebEDI.Respository.Interface
{
     public interface IOrderDetailService
    {
        List<OrderDetailModel> GetDetailOrder(string orderID);
        OrderDetailAllModel GetData(string orderID);

    }
}