using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace KsigDo.Web.Models
{
    public class KsigDoContext : DbContext
    {
        public DbSet<Task> Tasks { get; set; }

    }
}