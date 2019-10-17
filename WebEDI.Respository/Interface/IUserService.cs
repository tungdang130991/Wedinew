using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using WebEDI.Respository.Entity;

namespace WebEDI.Respository.Interface
{
    public interface IUserService
    {
      Task<bool> CheckConnection();
      Task<IReadOnlyCollection<TtWebRoguinyuza>> GetAll();
      Task<TtWebRoguinyuza> GetUserByUserName(string username,string companycode);
      Task<bool> UpdateInfoUser(TtWebRoguinyuza user);
    }
}
