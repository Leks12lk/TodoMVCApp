using System.Data.Entity;
using TodoMVCApp.Models;

namespace TodoMVCApp.DbContext
{
	public class ContextInitializer : DropCreateDatabaseAlways<ApplicationDbContext>
	{
		protected override void Seed(ApplicationDbContext db)
		{
			var task1 = new Todo { Title = "Create Entities", IsDone = true };
			var task2 = new Todo { Title = "Add Data Access Level", IsDone = true };
			var task3 = new Todo { Title = "Add Buisness Logic Layer", IsDone = false };
			var task4 = new Todo { Title = "Add Presentation Layer", IsDone = true };

			db.Todos.Add(task1);
			db.Todos.Add(task2);
			db.Todos.Add(task3);
			db.Todos.Add(task4);
			db.SaveChanges();
		}
	}
}