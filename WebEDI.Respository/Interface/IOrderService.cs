using System;
using System.Collections.Generic;
using System.Text;
using WebEDI.Respository.ViewModels;
using WebEDI.Common;

namespace WebEDI.Respository.Interface
{
    public interface IOrderService
    {
        List<OrderModel> GetTable();
        List<OrderModel> SearchOrder(string id, DateTime beginorder, DateTime endorder, string checkmail);
        ErrorCodes SendMail(string id);
        List<DropDown> GetDrops();
    }
}
