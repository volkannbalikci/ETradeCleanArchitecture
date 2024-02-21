using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Persistence.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistence.Factories
{
    public class DbContextDesignTimeFactory : IDesignTimeDbContextFactory<BaseDbContext>
    {
        public BaseDbContext CreateDbContext(string[] args)
        {
            DbContextOptionsBuilder<BaseDbContext> dbContextOptionsBuilder = new();
            dbContextOptionsBuilder.UseSqlServer(@"Server=(localdb)\mssqllocaldb; Database=ETradeDb; Trusted_Connection=true;");

           return new BaseDbContext(dbContextOptionsBuilder.Options);
        }
    }
}
