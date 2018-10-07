using Autofac;
using System;
using TitleViewSearch.Services.Movies;
using TitleViewSearch.Services.Request;

namespace TitleViewSearch.ViewModels.Base
{
    public class Locator
    {
        private static IContainer _container;

        public static Locator Instance { get; } = new Locator();

        protected Locator()
        {
            var builder = new ContainerBuilder();

            builder.RegisterType<RequestService>().As<IRequestService>();
            builder.RegisterType<MoviesService>().As<IMoviesService>();

            builder.RegisterType<MoviesViewModel>();

            if (_container != null)
            {
                _container.Dispose();
            }

            _container = builder.Build();
        }

        public T Resolve<T>()
        {
            return _container.Resolve<T>();
        }

        public object Resolve(Type type)
        {
            return _container.Resolve(type);
        }
    }
}