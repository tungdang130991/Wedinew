using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using WebEDI.Respository.Entity;

namespace WebEDI.Respository.Interface
{
     public interface IShiiresakiService
     {
        Task<IReadOnlyCollection<TtWebShiiresaki>> GetAllList();
    }
}
