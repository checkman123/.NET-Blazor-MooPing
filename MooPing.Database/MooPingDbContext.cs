using Microsoft.EntityFrameworkCore;
using MooPing.Database.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;

namespace MooPing.Database
{
    public class MooPingDbContext : DbContext
    {
        #region Constructors

        public MooPingDbContext() { }

        public MooPingDbContext(DbContextOptions<MooPingDbContext> options) : base(options) { }

        #endregion

        #region DbSets
        public DbSet<IpLog> IpLogs { get; set; }
        #endregion
    }
}
