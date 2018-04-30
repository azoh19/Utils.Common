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
    internal sealed class HandlerConfigurator<TContainerOptions, TInput, TOutput> : IHandlerConfigurator<TContainerOptions, TInput, TOutput>
    {
        [NotNull]
        private IContainerBridge<TContainerOptions> _bridge;

        [NotNull]
        private Func<IResolver, IHandler<TInput, TOutput>> _resolution;

        public HandlerConfigurator([NotNull] IContainerBridge<TContainerOptions> bridge, [NotNull] Func<IResolver, IHandler<TInput, TOutput>> resolution)
        {
            _bridge     = bridge     ?? throw new ArgumentNullException(nameof(bridge));
            _resolution = resolution ?? throw new ArgumentNullException(nameof(resolution));
        }

        #region IHandlerConfigurator<TContainerOptions,TInput,TOutput> Members

        public IHandlerConfigurator<TContainerOptions, TInput, TOutput> InterceptBy<TInterceptor>() where TInterceptor : IInterceptor<TInput, TOutput>
        {
            IHandler<TInput, TOutput> Resolution(IResolver resolver)
            {
                var interceptor = resolver.Resolve<TInterceptor>();

                return _resolution(resolver).InterceptedBy(interceptor);
            }

            return new HandlerConfigurator<TContainerOptions, TInput, TOutput>(_bridge, Resolution);
        }

        public IHandlerConfigurator<TContainerOptions, TNewInput, TNewOutput> ConvertBy<TConverter, TNewInput, TNewOutput>()
            where TConverter : IFullConverter<TInput, TOutput, TNewInput, TNewOutput>
        {
            IHandler<TNewInput, TNewOutput> Resolution(IResolver resolver)
            {
                var converter = resolver.Resolve<TConverter>();

                return _resolution(resolver).ConvertedBy(converter);
            }

            return new HandlerConfigurator<TContainerOptions, TNewInput, TNewOutput>(_bridge, Resolution);
        }

        public IHandlerConfigurator<TContainerOptions, TNewInput, TOutput> ConvertInputBy<TConverter, TNewInput>()
            where TConverter : IInputConverter<TInput, TOutput, TNewInput>
        {
            IHandler<TNewInput, TOutput> Resolution(IResolver resolver)
            {
                var converter = resolver.Resolve<TConverter>();

                return _resolution(resolver).ConvertedBy(converter);
            }

            return new HandlerConfigurator<TContainerOptions, TNewInput, TOutput>(_bridge, Resolution);
        }

        public IHandlerConfigurator<TContainerOptions, TInput, TNewOutput> ConvertOutputBy<TConverter, TNewOutput>()
            where TConverter : IOutputConverter<TInput, TOutput, TNewOutput>
        {
            IHandler<TInput, TNewOutput> Resolution(IResolver resolver)
            {
                var converter = resolver.Resolve<TConverter>();

                return _resolution(resolver).ConvertedBy(converter);
            }

            return new HandlerConfigurator<TContainerOptions, TInput, TNewOutput>(_bridge, Resolution);
        }

        public IConverterConfigurator<TContainerOptions, TInput, TOutput, TNewInput, TNewOutput> ConvertTo<TNewInput, TNewOutput>()
            => new ConverterConfigurator<TNewInput, TNewOutput>(this);

        public IInputConverterConfigurator<TContainerOptions, TInput, TOutput, TNewInput> ConvertInputTo<TNewInput>()
            => new InputConverterConfigurator<TNewInput>(this);

        public IOutputConverterConfigurator<TContainerOptions, TInput, TOutput, TNewOutput> ConvertOutputTo<TNewOutput>()
            => new OutputConverterConfigurator<TNewOutput>(this);

        TContainerOptions IHandlerConfigurator<TContainerOptions, TInput, TOutput>.Register() => _bridge.Register(_resolution);

        #endregion

        #region Nested type: ConverterConfigurator

        internal sealed class ConverterConfigurator<TNewInput, TNewOutput> : IConverterConfigurator<TContainerOptions, TInput, TOutput, TNewInput, TNewOutput>
        {
            [NotNull]
            private readonly IHandlerConfigurator<TContainerOptions, TInput, TOutput> _configurator;

            public ConverterConfigurator([NotNull] IHandlerConfigurator<TContainerOptions, TInput, TOutput> configurator)
            {
                _configurator = configurator;
            }

            #region IConverterConfigurator<TInput,TOutput,TNewInput,TNewOutput> Members

            public IHandlerConfigurator<TContainerOptions, TNewInput, TNewOutput> By<TConverter>()
                where TConverter : IFullConverter<TInput, TOutput, TNewInput, TNewOutput>
                => _configurator.ConvertBy<TConverter, TNewInput, TNewOutput>();

            #endregion
        }

        #endregion

        #region Nested type: InputConverterConfigurator

        internal sealed class InputConverterConfigurator<TNewInput> : IInputConverterConfigurator<TContainerOptions, TInput, TOutput, TNewInput>
        {
            [NotNull]
            private readonly IHandlerConfigurator<TContainerOptions, TInput, TOutput> _configurator;

            public InputConverterConfigurator([NotNull] IHandlerConfigurator<TContainerOptions, TInput, TOutput> configurator)
            {
                _configurator = configurator;
            }

            #region Implementation of IInputConverterConfigurator<in TInput,TOutput,TNewInput>

            public IHandlerConfigurator<TContainerOptions, TNewInput, TOutput> By<TConverter>()
                where TConverter : IInputConverter<TInput, TOutput, TNewInput>
                => _configurator.ConvertInputBy<TConverter, TNewInput>();

            #endregion
        }

        #endregion

        #region Nested type: OutputConverterConfigurator

        internal sealed class OutputConverterConfigurator<TNewOutput> : IOutputConverterConfigurator<TContainerOptions, TInput, TOutput, TNewOutput>
        {
            [NotNull]
            private readonly IHandlerConfigurator<TContainerOptions, TInput, TOutput> _configurator;

            public OutputConverterConfigurator([NotNull] IHandlerConfigurator<TContainerOptions, TInput, TOutput> configurator)
            {
                _configurator = configurator;
            }

            #region Implementation of IOutputConverterConfigurator<TInput,out TOutput,TNewOutput>

            public IHandlerConfigurator<TContainerOptions, TInput, TNewOutput> By<TConverter>()
                where TConverter : IOutputConverter<TInput, TOutput, TNewOutput>
                => _configurator.ConvertOutputBy<TConverter, TNewOutput>();

            #endregion
        }

        #endregion
    }
}
