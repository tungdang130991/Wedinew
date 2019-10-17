using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Text;
using WebEDI.Respository.Entity;

namespace WebEDI.Respository.Services
{
    public class ConnectService
    {
        public ConnectService(webedidbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public webedidbContext _dbContext { get; set; }
    }
}
