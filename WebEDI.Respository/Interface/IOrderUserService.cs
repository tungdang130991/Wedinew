using System;
using System.Collections.Generic;
using System.Text;
using WebEDI.Respository.ViewModels;

namespace WebEDI.Respository.Interface
{
    public interface IOrderUserService
    {
        List<OrderUserModel> GetTable(DateTime chuumon_tsuki, String hinmoku_cd);
        List<searchModel> GetData();

        void UpdateConfirm(DateTime dateConfirm, string[] ids);
    }
}
