using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Links.WWW.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace Links.WWW.Data
{
	public class ApplicationDbContext : IdentityDbContext<AppUser>
	{
		public ApplicationDbContext(DbContextOptions options)
			: base(options)
		{
		}

		public DbSet<JobSeeker> JobSeekers { get; set; }
	}
}