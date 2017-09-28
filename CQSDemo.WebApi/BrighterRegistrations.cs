using System;
using CQSDemo.BrighterCore.Entities;
using CQSDemo.BrighterCore.Worksheet.CreateWorksheet;
using CQSDemo.BrighterCore.Worksheet.GetWorksheetById;
using Paramore.Brighter;
using Paramore.Darker;
using Paramore.Darker.Builder;
using SimpleInjector;

namespace CQSDemo.WebApi
{
    public static class BrighterRegistrations
    {
        public static Container SetupContainer(Container container)
        {
            RegisterQueryProcessor(container);
            RegisterCommandProcessor(container);

            return container;
        }

        private static void RegisterQueryProcessor(Container container)
        {
            var registry = new QueryHandlerRegistry();
            registry.Register<GetWorksheetByIdQuery, Worksheet, GetWorksheetByIdQueryHandler>();

            var decoratorRegistry = new QueryHandlerDecoratorRegistry(container);
            var queryHandlerFactory = new QueryHandlerFactory(container);
            var queryHandlerDecoratorFactory = new QueryHandlerDecoratorFactory(container);

            IQueryProcessor queryProcessor = QueryProcessorBuilder.With()
            .Handlers(registry, queryHandlerFactory, decoratorRegistry, queryHandlerDecoratorFactory)
            .InMemoryQueryContextFactory()
            .Build();

            container.Register<IQueryProcessor>(() => { return queryProcessor; });
        }

        private static void RegisterCommandProcessor(Container container)
        {
            //create handler 
            var subscriberRegistry = new SubscriberRegistry();
            subscriberRegistry.RegisterAsync<CreateWorksheetCommand, CreateWorksheetCommandHandler>();

            container.Register<IHandleRequestsAsync<CreateWorksheetCommand>, CreateWorksheetCommandHandler>(Lifestyle.Scoped);

            var handlerFactory = new MyHandlerFactory(container);

            var commandProcessor = CommandProcessorBuilder.With()
                .Handlers(new Paramore.Brighter.HandlerConfiguration(subscriberRegistry, handlerFactory))
                .DefaultPolicy()
                .NoTaskQueues()
                .RequestContextFactory(new InMemoryRequestContextFactory())
                .Build();

            container.RegisterSingleton<IAmACommandProcessor>(commandProcessor);
        }

        internal class MyHandlerFactory : IAmAHandlerFactoryAsync
        {
            private readonly Container _container;

            public MyHandlerFactory(Container container)
            {
                _container = container;
            }

            public IHandleRequestsAsync Create(Type handlerType)
            {
                return (IHandleRequestsAsync)_container.GetInstance(handlerType);
            }

            public void Release(IHandleRequestsAsync handler)
            {
                var disposable = handler as IDisposable;
                if (disposable != null)
                {
                    disposable.Dispose();
                }
            }
        }

        internal class QueryHandlerFactory : IQueryHandlerFactory
        {
            private readonly Container _container;

            public QueryHandlerFactory(Container container)
            {
                _container = container;
            }
            
            public IQueryHandler Create(Type handlerType)
            {
                return (IQueryHandler)_container.GetInstance(handlerType);
            }

            public void Release(IQueryHandler handler)
            {
                var disposable = handler as IDisposable;
                if (disposable != null)
                {
                    disposable.Dispose();
                }
            }
        }

        internal class QueryHandlerDecoratorFactory : IQueryHandlerDecoratorFactory
        {
            private readonly Container _container;

            public QueryHandlerDecoratorFactory(Container container)
            {
                _container = container;
            }

            public T Create<T>(Type decoratorType) where T : IQueryHandlerDecorator
            {
                return (T) _container.GetInstance(decoratorType);
            }

            public void Release<T>(T handler) where T : IQueryHandlerDecorator
            {
                var disposable = handler as IDisposable;
                if (disposable != null)
                {
                    disposable.Dispose();
                }
            }
        }

        internal class QueryHandlerDecoratorRegistry : IQueryHandlerDecoratorRegistry
        {
            private readonly Container _container;

            public QueryHandlerDecoratorRegistry(Container container)
            {
                _container = container;
            }

            public void Register(Type decoratorType)
            {
                _container.Register(decoratorType);
            }
        }
    }
}