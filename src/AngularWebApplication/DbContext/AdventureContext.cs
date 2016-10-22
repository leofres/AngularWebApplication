using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AngularWebApplication.Models;
using Microsoft.Data.Entity;
using Microsoft.Data.Entity.Infrastructure;

namespace AngularWebApplication.DbContext
{
    public class AdventureContext : Microsoft.Data.Entity.DbContext
    {
	    public AdventureContext(DbContextOptions options) 
			: base(options) {
	    }

	    public DbSet<Person> People { get; set; }
    }
}
