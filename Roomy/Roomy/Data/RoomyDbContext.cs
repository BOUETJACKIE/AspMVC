using Roomy.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Roomy.Data
{
    public class RoomyDbContext : DbContext
    {
        public RoomyDbContext() : base("Roomydb")
        {

        }
        public DbSet<User> Users { get; set; }

    }
}