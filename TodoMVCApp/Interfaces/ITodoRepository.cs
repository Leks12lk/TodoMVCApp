using System.Collections.Generic;
using TodoMVCApp.Models;

namespace TodoMVCApp.Interfaces
{
	public interface ITodoRepository
	{
		IEnumerable<Todo> GetAll();
		Todo Add(Todo todo);
		Todo Update(Todo todo);
		void Delete(int id);
	}
}
