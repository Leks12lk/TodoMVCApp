using System.Data.Entity;
using TodoMVCApp.Models;

namespace TodoMVCApp.DbContext
{
	public class ApplicationDbContext : System.Data.Entity.DbContext
	{
		static ApplicationDbContext()
		{
			Database.SetInitializer(new ContextInitializer());
		}

		public ApplicationDbContext() : base("MainConnection")
		{ }

		public DbSet<Todo> Todos { get; set; }
	}
}