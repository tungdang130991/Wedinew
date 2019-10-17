using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using WebEDI.Respository.Entity;
using WebEDI.Respository.Interface;

namespace WebEDI.Respository.Services
{
    public class ShiiresakiService : ConnectService,IShiiresakiService
    {
        public ShiiresakiService(webedidbContext dbContext) : base(dbContext)
        {

        }

        public async Task<IReadOnlyCollection<TtWebShiiresaki>> GetAllList()
        {
            return await  _dbContext.TtWebShiiresaki.ToListAsync();
        }
    }
}
