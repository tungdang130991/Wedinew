using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebEDI.Respository.Entity;
using WebEDI.Respository.Interface;
namespace WebEDI.Respository.Services
{
    public class UserService:ConnectService,IUserService
    {
        public UserService(webedidbContext dbContext) : base(dbContext)
        {
        }

        public Task<bool> CheckConnection()
        {
            DbConnection conn = _dbContext.Database.GetDbConnection();
            try
            {
                conn.Open();   // Check the database connection
                return  Task.FromResult(true);
            }
            catch
            {
                return Task.FromResult(false);
            }
        }

        public async Task<IReadOnlyCollection<TtWebRoguinyuza>> GetAll()
        {
           return  await _dbContext.TtWebRoguinyuza.ToListAsync();
        }

        public async Task<TtWebRoguinyuza> GetUserByUserName(string username,string companycode)
        {
            var result = from _TtWebRoguinyuza in _dbContext.TtWebRoguinyuza
                         join _TtWebShiiresaki in _dbContext.TtWebShiiresaki
                         on _TtWebRoguinyuza.FShiiresakiCd equals _TtWebShiiresaki.FShiiresakiCd
                         into a from b in a.DefaultIfEmpty()
                         where _TtWebRoguinyuza.FYuzaId == username &&
                         _TtWebRoguinyuza.FShiiresakiCd == companycode &&
                         _TtWebRoguinyuza.FRotsukuKubun == "00"
                         select _TtWebRoguinyuza;
            return  await result.FirstOrDefaultAsync();
        }

        public async Task<bool> UpdateInfoUser(TtWebRoguinyuza user)
        {
            try
            {
                using (var transaction = _dbContext.Database.BeginTransaction())
                {
                    //_dbContext.Add(user);
                    _dbContext.Entry(user).State = EntityState.Modified;
                    int effectedRows = await _dbContext.SaveChangesAsync();
                    if (effectedRows != 1)
                    {
                        transaction.Rollback();
                        return await Task.FromResult(false);
                    }
                    transaction.Commit();
                }
                return await Task.FromResult(true);
            }
            catch (Exception ex)
            {
                return await Task.FromResult(false);

            }
        }
    }
}
