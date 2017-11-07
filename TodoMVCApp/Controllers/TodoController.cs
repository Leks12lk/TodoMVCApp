using System.Net;
using System.Web.Mvc;
using TodoMVCApp.Interfaces;
using TodoMVCApp.Models;

namespace TodoMVCApp.Controllers
{
	public class TodoController : Controller
	{
		private readonly ITodoRepository _todoRepository;
		public TodoController(ITodoRepository todoRepository)
		{
			_todoRepository = todoRepository;
		}

		// GET: Todo
		public ActionResult Index()
		{
			var tasks = _todoRepository.GetAll();
			return View(tasks);
		}

		[HttpPost]
		public ActionResult AddTask(Todo task)
		{
			if(!ModelState.IsValid) return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
			var todo =_todoRepository.Add(task);
			return Json(todo);
		}

		[HttpPost]
		public ActionResult UpdateTask(Todo task)
		{
			if (!ModelState.IsValid) return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
			var todo = _todoRepository.Update(task);
			return Json(todo);
		}

		[HttpGet]
		public ActionResult DeleteTask(int id)
		{
			if (id <= 0) return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
			_todoRepository.Delete(id);
			return new HttpStatusCodeResult(HttpStatusCode.OK);
		}
	}
}