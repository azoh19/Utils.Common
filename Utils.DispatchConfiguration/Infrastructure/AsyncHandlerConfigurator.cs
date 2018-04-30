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
    internal sealed class AsyncHandlerConfigurator<TContainerOptions, TInput, TOutput> : IAsyncHandlerConfigurator<TContainerOptions, TInput, TOutput>
    {
        [NotNull]
        private readonly IContainerBridge<TContainerOptions> _bridge;

        [NotNull]
        private Func<IResolver, IAsyncHandler<TInput, TOutput>> _resolution;

        public AsyncHandlerConfigurator([NotNull] IContainerBridge<TContainerOptions>             bridge,
                                        [NotNull] Func<IResolver, IAsyncHandler<TInput, TOutput>> resolution)
        {
            _bridge     = bridge     ?? throw new ArgumentNullException(nameof(bridge));
            _resolution = resolution ?? throw new ArgumentNullException(nameof(resolution));
        }

        #region IAsyncHandlerConfigurator<TContainerOptions,TInput,TOutput> Members

        public IAsyncHandlerConfigurator<TContainerOptions, TInput, TOutput> InterceptBy<TInterceptor>()
            where TInterceptor : IAsyncInterceptor<TInput, TOutput>
        {
            IAsyncHandler<TInput, TOutput> Resolution(IResolver resolver)
            {
                var interceptor = resolver.Resolve<TInterceptor>();

                return _resolution(resolver).InterceptedBy(interceptor);
            }

            return new AsyncHandlerConfigurator<TContainerOptions, TInput, TOutput>(_bridge, Resolution);
        }

        public IAsyncHandlerConfigurator<TContainerOptions, TNewInput, TNewOutput> ConvertBy<TConverter, TNewInput, TNewOutput>()
            where TConverter : IFullAsyncConverter<TInput, TOutput, TNewInput, TNewOutput>
        {
            IAsyncHandler<TNewInput, TNewOutput> Resolution(IResolver resolver)
            {
                var converter = resolver.Resolve<TConverter>();

                return _resolution(resolver).ConvertedBy(converter);
            }

            return new AsyncHandlerConfigurator<TContainerOptions, TNewInput, TNewOutput>(_bridge, Resolution);
        }

        public IAsyncHandlerConfigurator<TContainerOptions, TNewInput, TOutput> ConvertInputBy<TConverter, TNewInput>()
            where TConverter : IInputAsyncConverter<TInput, TOutput, TNewInput>
        {
            IAsyncHandler<TNewInput, TOutput> Resolution(IResolver resolver)
            {
                var converter = resolver.Resolve<TConverter>();

                return _resolution(resolver).ConvertedBy(converter);
            }

            return new AsyncHandlerConfigurator<TContainerOptions, TNewInput, TOutput>(_bridge, Resolution);
        }

        public IAsyncHandlerConfigurator<TContainerOptions, TInput, TNewOutput> ConvertOutputBy<TConverter, TNewOutput>()
            where TConverter : IOutputAsyncConverter<TInput, TOutput, TNewOutput>
        {
            IAsyncHandler<TInput, TNewOutput> Resolution(IResolver resolver)
            {
                var converter = resolver.Resolve<TConverter>();

                return _resolution(resolver).ConvertedBy(converter);
            }

            return new AsyncHandlerConfigurator<TContainerOptions, TInput, TNewOutput>(_bridge, Resolution);
        }

        public IAsyncConverterConfigurator<TContainerOptions, TInput, TOutput, TNewInput, TNewOutput> ConvertTo<TNewInput, TNewOutput>()
            => new ConverterConfigurator<TNewInput, TNewOutput>(this);

        public IInputAsyncConverterConfigurator<TContainerOptions, TInput, TOutput, TNewInput> ConvertInputTo<TNewInput>()
            => new InputConverterConfigurator<TNewInput>(this);

        public IOutputAsyncConverterConfigurator<TContainerOptions, TInput, TOutput, TNewOutput> ConvertOutputTo<TNewOutput>()
            => new OutputConverterConfigurator<TNewOutput>(this);

        public TContainerOptions Register() => _bridge.Register(_resolution);

        #endregion

        #region Nested type: ConverterConfigurator

        internal sealed class ConverterConfigurator<TNewInput, TNewOutput>
            : IAsyncConverterConfigurator<TContainerOptions, TInput, TOutput, TNewInput, TNewOutput>
        {
            [NotNull]
            private readonly IAsyncHandlerConfigurator<TContainerOptions, TInput, TOutput> _configurator;

            public ConverterConfigurator([NotNull] IAsyncHandlerConfigurator<TContainerOptions, TInput, TOutput> configurator)
            {
                _configurator = configurator;
            }

            #region IConverterConfigurator<TInput,TOutput,TNewInput,TNewOutput> Members

            public IAsyncHandlerConfigurator<TContainerOptions, TNewInput, TNewOutput> By<TConverter>()
                where TConverter : IFullAsyncConverter<TInput, TOutput, TNewInput, TNewOutput>
                => _configurator.ConvertBy<TConverter, TNewInput, TNewOutput>();

            #endregion
        }

        #endregion

        #region Nested type: InputConverterConfigurator

        internal sealed class InputConverterConfigurator<TNewInput>
            : IInputAsyncConverterConfigurator<TContainerOptions, TInput, TOutput, TNewInput>
        {
            [NotNull]
            private readonly IAsyncHandlerConfigurator<TContainerOptions, TInput, TOutput> _configurator;

            public InputConverterConfigurator([NotNull] IAsyncHandlerConfigurator<TContainerOptions, TInput, TOutput> configurator)
            {
                _configurator = configurator;
            }

            #region Implementation of IInputConverterConfigurator<in TInput,TOutput,TNewInput>

            public IAsyncHandlerConfigurator<TContainerOptions, TNewInput, TOutput> By<TConverter>()
                where TConverter : IInputAsyncConverter<TInput, TOutput, TNewInput>
                => _configurator.ConvertInputBy<TConverter, TNewInput>();

            #endregion
        }

        #endregion

        #region Nested type: OutputConverterConfigurator

        internal sealed class OutputConverterConfigurator<TNewOutput>
            : IOutputAsyncConverterConfigurator<TContainerOptions, TInput, TOutput, TNewOutput>
        {
            [NotNull]
            private readonly IAsyncHandlerConfigurator<TContainerOptions, TInput, TOutput> _configurator;

            public OutputConverterConfigurator([NotNull] IAsyncHandlerConfigurator<TContainerOptions, TInput, TOutput> configurator)
            {
                _configurator = configurator;
            }

            #region Implementation of IOutputConverterConfigurator<TInput,out TOutput,TNewOutput>

            public IAsyncHandlerConfigurator<TContainerOptions, TInput, TNewOutput> By<TConverter>()
                where TConverter : IOutputAsyncConverter<TInput, TOutput, TNewOutput>
                => _configurator.ConvertOutputBy<TConverter, TNewOutput>();

            #endregion
        }

        #endregion
    }
}
