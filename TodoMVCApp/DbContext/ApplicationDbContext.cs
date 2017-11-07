using System.Data.Entity;
using TodoMVCApp.Models;

namespace TodoMVCApp.DbContext
{
	public class ApplicationDbContext : System.Data.Entity.DbContext
	{
		static ApplicationDbContext()
		{
			// initialize DB with some stub data
			Database.SetInitializer(new ContextInitializer());
		}

		// pass DB connection string name 
		public ApplicationDbContext() : base("MainConnection")
		{ }

		// define table Todos in DB
		public DbSet<Todo> Todos { get; set; }
	}
}