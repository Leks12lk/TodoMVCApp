using System;
using System.Web.Mvc;
using System.Web.Routing;
using Ninject;
using TodoMVCApp.Interfaces;
using TodoMVCApp.Repositories;

namespace TodoMVCApp.Infrastructure
{
	public class NinjectControllerFactory : DefaultControllerFactory
	{
		private readonly IKernel _ninjectKernel;
		public NinjectControllerFactory()
		{
			// container creating
			_ninjectKernel = new StandardKernel();
			 AddBindings();
		}
		protected override IController GetControllerInstance(RequestContext requestContext, Type controllerType)
		{
			return controllerType == null ? null : (IController)_ninjectKernel.Get(controllerType);
		}
		private void AddBindings()
		{
			// конфигурирование контейнера
			_ninjectKernel.Bind<ITodoRepository>().To<TodoRepository>();


			//ninjectKernel.Bind<ApplicationDbContext>().To<ApplicationDbContext>();
		}
	}
}