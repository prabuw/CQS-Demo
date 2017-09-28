using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using CQSDemo.MediatrCore.Behaviours;
using CQSDemo.MediatrCore.Worksheet.CreateWorksheet;
using CQSDemo.MediatrCore.Worksheet.GetWorksheetById;
using MediatR;
using MediatR.Pipeline;
using SimpleInjector;

namespace CQSDemo.WebApi
{
    public static class MediatrRegistrations
    {
        public static Container SetupContainer(Container container)
        {
            var assemblies = GetAssemblies().ToArray();
            //container.RegisterSingleton<IProcessor, Processor>();
            container.RegisterSingleton<IMediator, Mediator>();
            container.Register(typeof(IRequestHandler<,>), assemblies);
            container.Register(typeof(IAsyncRequestHandler<,>), assemblies);
            container.Register(typeof(IRequestHandler<>), assemblies);
            container.Register(typeof(IAsyncRequestHandler<>), assemblies);
            container.Register(typeof(ICancellableAsyncRequestHandler<>), assemblies);
            container.RegisterCollection(typeof(INotificationHandler<>), assemblies);
            container.RegisterCollection(typeof(IAsyncNotificationHandler<>), assemblies);
            container.RegisterCollection(typeof(ICancellableAsyncNotificationHandler<>), assemblies);

            //Pipeline

            //container.RegisterCollection(typeof(IPipelineBehavior<,>), new[]
            //{
            //    typeof(RequestPreProcessorBehavior<,>),
            //    typeof(RequestPostProcessorBehavior<,>),
            //});

            container.RegisterCollection(typeof(IPipelineBehavior<,>), new[] {
                typeof(LoggingBehaviour<,>)
            });

            //container.RegisterCollection(typeof(IPipelineBehavior<,>), Enumerable.Empty<Type>());
            container.RegisterCollection(typeof(IRequestPreProcessor<>), Enumerable.Empty<Type>());
            container.RegisterCollection(typeof(IRequestPostProcessor<,>), Enumerable.Empty<Type>());

            container.RegisterSingleton(new SingleInstanceFactory(container.GetInstance));
            container.RegisterSingleton(new MultiInstanceFactory(container.GetAllInstances));
            
            return container;
        }

        private static IEnumerable<Assembly> GetAssemblies()
        {
            yield return typeof(IMediator).GetTypeInfo().Assembly;
            yield return typeof(CreateWorksheetCommand).GetTypeInfo().Assembly;
            yield return typeof(GetWorksheetByIdQuery).GetTypeInfo().Assembly;
        }
    }
}