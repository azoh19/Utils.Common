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
    internal sealed class HandlerConfigurator<TInput, TOutput> : IHandlerConfigurator<TInput, TOutput>
    {
        public HandlerConfigurator([NotNull] Func<IResolver, IHandler<TInput, TOutput>> resolution)
        {
            ResolveFunc = resolution ?? throw new ArgumentNullException(nameof(resolution));
        }

        #region IHandlerConfigurator<TInput,TOutput> Members

        public IHandlerConfigurator<TInput, TOutput> InterceptBy<TInterceptor>() where TInterceptor : IInterceptor<TInput, TOutput>
        {
            IHandler<TInput, TOutput> Resolution(IResolver resolver)
            {
                var interceptor = resolver.Resolve<TInterceptor>();

                return ResolveFunc(resolver).InterceptedBy(interceptor);
            }

            return new HandlerConfigurator<TInput, TOutput>(Resolution);
        }

        public IHandlerConfigurator<TNewInput, TNewOutput> ConvertBy<TConverter, TNewInput, TNewOutput>()
            where TConverter : IFullConverter<TInput, TOutput, TNewInput, TNewOutput>
        {
            IHandler<TNewInput, TNewOutput> Resolution(IResolver resolver)
            {
                var converter = resolver.Resolve<TConverter>();

                return ResolveFunc(resolver).ConvertedBy(converter);
            }

            return new HandlerConfigurator<TNewInput, TNewOutput>(Resolution);
        }

        public IHandlerConfigurator<TNewInput, TOutput> ConvertInputBy<TConverter, TNewInput>()
            where TConverter : IInputConverter<TInput, TOutput, TNewInput>
        {
            IHandler<TNewInput, TOutput> Resolution(IResolver resolver)
            {
                var converter = resolver.Resolve<TConverter>();

                return ResolveFunc(resolver).ConvertedBy(converter);
            }

            return new HandlerConfigurator<TNewInput, TOutput>(Resolution);
        }

        public IHandlerConfigurator<TInput, TNewOutput> ConvertOutputBy<TConverter, TNewOutput>()
            where TConverter : IOutputConverter<TInput, TOutput, TNewOutput>
        {
            IHandler<TInput, TNewOutput> Resolution(IResolver resolver)
            {
                var converter = resolver.Resolve<TConverter>();

                return ResolveFunc(resolver).ConvertedBy(converter);
            }

            return new HandlerConfigurator<TInput, TNewOutput>(Resolution);
        }

        public IConverterConfigurator<TInput, TOutput, TNewInput, TNewOutput> ConvertTo<TNewInput, TNewOutput>()
            => new ConverterConfigurator<TNewInput, TNewOutput>(this);

        public IInputConverterConfigurator<TInput, TOutput, TNewInput> ConvertInputTo<TNewInput>()
            => new InputConverterConfigurator<TNewInput>(this);

        public IOutputConverterConfigurator<TInput, TOutput, TNewOutput> ConvertOutputTo<TNewOutput>()
            => new OutputConverterConfigurator<TNewOutput>(this);

        public Func<IResolver, IHandler<TInput, TOutput>> ResolveFunc { get; }

        #endregion

        #region Nested type: ConverterConfigurator

        internal sealed class ConverterConfigurator<TNewInput, TNewOutput> : IConverterConfigurator<TInput, TOutput, TNewInput, TNewOutput>
        {
            [NotNull]
            private readonly IHandlerConfigurator<TInput, TOutput> _configurator;

            public ConverterConfigurator([NotNull] IHandlerConfigurator<TInput, TOutput> configurator)
            {
                _configurator = configurator;
            }

            #region IConverterConfigurator<TInput,TOutput,TNewInput,TNewOutput> Members

            public IHandlerConfigurator<TNewInput, TNewOutput> By<TConverter>()
                where TConverter : IFullConverter<TInput, TOutput, TNewInput, TNewOutput>
                => _configurator.ConvertBy<TConverter, TNewInput, TNewOutput>();

            #endregion
        }

        #endregion

        #region Nested type: InputConverterConfigurator

        internal sealed class InputConverterConfigurator<TNewInput> : IInputConverterConfigurator<TInput, TOutput, TNewInput>
        {
            [NotNull]
            private readonly IHandlerConfigurator<TInput, TOutput> _configurator;

            public InputConverterConfigurator([NotNull] IHandlerConfigurator<TInput, TOutput> configurator)
            {
                _configurator = configurator;
            }

            #region Implementation of IInputConverterConfigurator<in TInput,TOutput,TNewInput>

            public IHandlerConfigurator<TNewInput, TOutput> By<TConverter>()
                where TConverter : IInputConverter<TInput, TOutput, TNewInput>
                => _configurator.ConvertInputBy<TConverter, TNewInput>();

            #endregion
        }

        #endregion

        #region Nested type: OutputConverterConfigurator

        internal sealed class OutputConverterConfigurator<TNewOutput> : IOutputConverterConfigurator<TInput, TOutput, TNewOutput>
        {
            [NotNull]
            private readonly IHandlerConfigurator<TInput, TOutput> _configurator;

            public OutputConverterConfigurator([NotNull] IHandlerConfigurator<TInput, TOutput> configurator)
            {
                _configurator = configurator;
            }

            #region Implementation of IOutputConverterConfigurator<TInput,out TOutput,TNewOutput>

            public IHandlerConfigurator<TInput, TNewOutput> By<TConverter>()
                where TConverter : IOutputConverter<TInput, TOutput, TNewOutput>
                => _configurator.ConvertOutputBy<TConverter, TNewOutput>();

            #endregion
        }

        #endregion
    }
}
