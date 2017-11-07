using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using TodoMVCApp.DbContext;
using TodoMVCApp.Interfaces;
using TodoMVCApp.Models;

namespace TodoMVCApp.Repositories
{
	public class TodoRepository : ITodoRepository
	{
		private readonly ApplicationDbContext _db;

		public TodoRepository(ApplicationDbContext db)
		{
			_db = db;
		}

		/// <summary>
		/// Get all tasks from DB
		/// </summary>
		/// <returns>List of tasks</returns>
		public IEnumerable<Todo> GetAll()
		{
			return _db.Todos.ToList();
		}

		/// <summary>
		/// Save new task to DB
		/// </summary>
		/// <param name="todo">Task to add</param>
		/// <returns>Just added task</returns>
		public Todo Add(Todo todo)
		{
			_db.Todos.Add(todo);
			_db.SaveChanges();
			return todo;
		}

		/// <summary>
		/// Update specific task in DB
		/// </summary>
		/// <param name="todo">Task to update</param>
		/// <returns>Just updated task</returns>
		public Todo Update(Todo todo)
		{
			_db.Entry(todo).State = EntityState.Modified;
			_db.SaveChanges();
			return todo;
		}

		/// <summary>
		/// Delete task by id from DB
		/// </summary>
		/// <param name="id">Id of a task to delete</param>
		public void Delete(int id)
		{
			var task = _db.Todos.Find(id);
			if (task == null) return;
			_db.Todos.Remove(task);
			_db.SaveChanges();
		}
	}
}