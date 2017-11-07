using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TodoMVCApp.Models;

namespace TodoMVCApp.Interfaces
{
	public interface ITodoRepository
	{
		IEnumerable<Todo> GetAll();
		Todo Add(Todo todo);
		Todo Update(Todo todo);
		IEnumerable<Todo> Delete(int id);
	}
}
