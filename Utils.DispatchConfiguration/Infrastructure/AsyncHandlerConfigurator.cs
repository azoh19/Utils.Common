#region Using

using System;
using JetBrains.Annotations;
using Utils.AbstractDI;
using Utils.DispatchConfiguration.Configurators;
using Utils.Handlers;
using Utils.Handlers.Converters;
using Utils.Handlers.Extensions;
using Utils.Handlers.Interceptors;

#endregion

namespace Utils.DispatchConfiguration.Infrastructure
{
    internal sealed class AsyncHandlerConfigurator<TInput, TOutput> : IAsyncHandlerConfigurator<TInput, TOutput>
    {
        public AsyncHandlerConfigurator([NotNull] Func<IResolver, IAsyncHandler<TInput, TOutput>> resolution)
        {
            ResolveFunc = resolution ?? throw new ArgumentNullException(nameof(resolution));
        }

        #region IAsyncHandlerConfigurator<TInput,TOutput> Members

        public IAsyncHandlerConfigurator<TInput, TOutput> InterceptBy<TInterceptor>()
            where TInterceptor : IAsyncInterceptor<TInput, TOutput>
        {
            IAsyncHandler<TInput, TOutput> Resolution(IResolver resolver)
            {
                var interceptor = resolver.Resolve<TInterceptor>();

                return ResolveFunc(resolver).InterceptedBy(interceptor);
            }

            return new AsyncHandlerConfigurator<TInput, TOutput>(Resolution);
        }

        public IAsyncHandlerConfigurator<TNewInput, TNewOutput> ConvertBy<TConverter, TNewInput, TNewOutput>()
            where TConverter : IFullAsyncConverter<TInput, TOutput, TNewInput, TNewOutput>
        {
            IAsyncHandler<TNewInput, TNewOutput> Resolution(IResolver resolver)
            {
                var converter = resolver.Resolve<TConverter>();

                return ResolveFunc(resolver).ConvertedBy(converter);
            }

            return new AsyncHandlerConfigurator<TNewInput, TNewOutput>(Resolution);
        }

        public IAsyncHandlerConfigurator<TNewInput, TOutput> ConvertInputBy<TConverter, TNewInput>()
            where TConverter : IInputAsyncConverter<TInput, TOutput, TNewInput>
        {
            IAsyncHandler<TNewInput, TOutput> Resolution(IResolver resolver)
            {
                var converter = resolver.Resolve<TConverter>();

                return ResolveFunc(resolver).ConvertedBy(converter);
            }

            return new AsyncHandlerConfigurator<TNewInput, TOutput>(Resolution);
        }

        public IAsyncHandlerConfigurator<TInput, TNewOutput> ConvertOutputBy<TConverter, TNewOutput>()
            where TConverter : IOutputAsyncConverter<TInput, TOutput, TNewOutput>
        {
            IAsyncHandler<TInput, TNewOutput> Resolution(IResolver resolver)
            {
                var converter = resolver.Resolve<TConverter>();

                return ResolveFunc(resolver).ConvertedBy(converter);
            }

            return new AsyncHandlerConfigurator<TInput, TNewOutput>(Resolution);
        }

        public IAsyncConverterConfigurator<TInput, TOutput, TNewInput, TNewOutput> ConvertTo<TNewInput, TNewOutput>()
            => new ConverterConfigurator<TNewInput, TNewOutput>(this);

        public IInputAsyncConverterConfigurator<TInput, TOutput, TNewInput> ConvertInputTo<TNewInput>() 
            => new InputConverterConfigurator<TNewInput>(this);

        public IOutputAsyncConverterConfigurator<TInput, TOutput, TNewOutput> ConvertOutputTo<TNewOutput>()
            => new OutputConverterConfigurator<TNewOutput>(this);

        public Func<IResolver, IAsyncHandler<TInput, TOutput>> ResolveFunc { get; }

        #endregion

        #region Nested type: ConverterConfigurator

        internal sealed class ConverterConfigurator<TNewInput, TNewOutput>
            : IAsyncConverterConfigurator<TInput, TOutput, TNewInput, TNewOutput>
        {
            [NotNull]
            private readonly IAsyncHandlerConfigurator<TInput, TOutput> _configurator;

            public ConverterConfigurator([NotNull] IAsyncHandlerConfigurator<TInput, TOutput> configurator)
            {
                _configurator = configurator;
            }

            #region IConverterConfigurator<TInput,TOutput,TNewInput,TNewOutput> Members

            public IAsyncHandlerConfigurator<TNewInput, TNewOutput> By<TConverter>()
                where TConverter : IFullAsyncConverter<TInput, TOutput, TNewInput, TNewOutput>
                => _configurator.ConvertBy<TConverter, TNewInput, TNewOutput>();

            #endregion
        }

        #endregion

        #region Nested type: InputConverterConfigurator

        internal sealed class InputConverterConfigurator<TNewInput>
            : IInputAsyncConverterConfigurator<TInput, TOutput, TNewInput>
        {
            [NotNull]
            private readonly IAsyncHandlerConfigurator<TInput, TOutput> _configurator;

            public InputConverterConfigurator([NotNull] IAsyncHandlerConfigurator<TInput, TOutput> configurator)
            {
                _configurator = configurator;
            }

            #region Implementation of IInputConverterConfigurator<in TInput,TOutput,TNewInput>

            public IAsyncHandlerConfigurator<TNewInput, TOutput> By<TConverter>()
                where TConverter : IInputAsyncConverter<TInput, TOutput, TNewInput>
                => _configurator.ConvertInputBy<TConverter, TNewInput>();

            #endregion
        }

        #endregion

        #region Nested type: OutputConverterConfigurator

        internal sealed class OutputConverterConfigurator<TNewOutput>
            : IOutputAsyncConverterConfigurator<TInput, TOutput, TNewOutput>
        {
            [NotNull]
            private readonly IAsyncHandlerConfigurator<TInput, TOutput> _configurator;

            public OutputConverterConfigurator([NotNull] IAsyncHandlerConfigurator<TInput, TOutput> configurator)
            {
                _configurator = configurator;
            }

            #region Implementation of IOutputConverterConfigurator<TInput,out TOutput,TNewOutput>

            public IAsyncHandlerConfigurator<TInput, TNewOutput> By<TConverter>()
                where TConverter : IOutputAsyncConverter<TInput, TOutput, TNewOutput>
                => _configurator.ConvertOutputBy<TConverter, TNewOutput>();

            #endregion
        }

        #endregion
    }
}
