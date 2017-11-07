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

		public IEnumerable<Todo> GetAll()
		{
			return _db.Todos.ToList();
		}

		public Todo Add(Todo todo)
		{
			_db.Todos.Add(todo);
			_db.SaveChanges();
			return todo;
		}

		public Todo Update(Todo todo)
		{
			_db.Entry(todo).State = EntityState.Modified;
			_db.SaveChanges();
			return todo;
		}

		public IEnumerable<Todo> Delete(int id)
		{
			var task = _db.Todos.Find(id);
			if (task != null)
			{
				_db.Todos.Remove(task);
				_db.SaveChanges();
			}
			return GetAll();
		}
	}
}