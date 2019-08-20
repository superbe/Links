using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Links.WWW.Models
{
    public class LinksWWWContext : DbContext
    {
        public LinksWWWContext (DbContextOptions<LinksWWWContext> options)
            : base(options)
        {
        }

        public DbSet<Links.WWW.Models.Link> Link { get; set; }
    }
}
