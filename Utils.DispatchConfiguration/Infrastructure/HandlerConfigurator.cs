#region Using

using System;
using JetBrains.Annotations;
using Utils.AbstractDI;
using Utils.DispatchConfiguration.Configurators;
using Utils.Handlers;
using Utils.Handlers.Extensions;

#endregion

namespace Utils.DispatchConfiguration.Infrastructure
{
    internal sealed class HandlerConfigurator<TInput, TOutput>
        : IHandlerConfigurator<TInput, TOutput>
    {
        [NotNull]
        private readonly Func<IResolver, IHandler<TInput, TOutput>> _buildHandler;

        public HandlerConfigurator([NotNull] Func<IResolver, IHandler<TInput, TOutput>> resolution)
        {
            _buildHandler = resolution ?? throw new ArgumentNullException(nameof(resolution));
        }

        #region IHandlerConfigurator<TInput,TOutput> Members

        IHandlerConfigurator<TInput, TOutput> IHandlerConfigurator<TInput, TOutput>.InterceptBy<TInterceptor>()
        {
            IHandler<TInput, TOutput> Build(IResolver resolver)
            {
                var interceptor = resolver.Resolve<TInterceptor>();

                return _buildHandler(resolver).InterceptedBy(interceptor);
            }

            return new HandlerConfigurator<TInput, TOutput>(Build);
        }

        IHandlerConfigurator<TNewInput, TNewOutput> IHandlerConfigurator<TInput, TOutput>.ConvertBy<TConverter, TNewInput, TNewOutput>()
        {
            IHandler<TNewInput, TNewOutput> Build(IResolver resolver)
            {
                var converter = resolver.Resolve<TConverter>();

                return _buildHandler(resolver).ConvertedBy(converter);
            }

            return new HandlerConfigurator<TNewInput, TNewOutput>(Build);
        }

        IHandlerConfigurator<TNewInput, TOutput> IHandlerConfigurator<TInput, TOutput>.ConvertInputBy<TConverter, TNewInput>()
        {
            IHandler<TNewInput, TOutput> Build(IResolver resolver)
            {
                var converter = resolver.Resolve<TConverter>();

                return _buildHandler(resolver).ConvertedBy(converter);
            }

            return new HandlerConfigurator<TNewInput, TOutput>(Build);
        }

        IHandlerConfigurator<TInput, TNewOutput> IHandlerConfigurator<TInput, TOutput>.ConvertOutputBy<TConverter, TNewOutput>()
        {
            IHandler<TInput, TNewOutput> Build(IResolver resolver)
            {
                var converter = resolver.Resolve<TConverter>();

                return _buildHandler(resolver).ConvertedBy(converter);
            }

            return new HandlerConfigurator<TInput, TNewOutput>(Build);
        }

        IConverterConfigurator<TInput, TOutput, TNewInput, TNewOutput> IHandlerConfigurator<TInput, TOutput>.ConvertTo<TNewInput, TNewOutput>()
            => new ConverterConfigurator<TNewInput, TNewOutput>(this);

        IInputConverterConfigurator<TInput, TOutput, TNewInput> IHandlerConfigurator<TInput, TOutput>.ConvertInputTo<TNewInput>()
            => new InputConverterConfigurator<TNewInput>(this);

        IOutputConverterConfigurator<TInput, TOutput, TNewOutput> IHandlerConfigurator<TInput, TOutput>.ConvertOutputTo<TNewOutput>()
            => new OutputConverterConfigurator<TNewOutput>(this);

        Func<IResolver, IHandler<TInput, TOutput>> IHandlerConfigurator<TInput, TOutput>.BuildHandler => _buildHandler;

        #endregion

        #region Nested type: ConverterConfigurator

        internal sealed class ConverterConfigurator<TNewInput, TNewOutput>
            : IConverterConfigurator<TInput, TOutput, TNewInput, TNewOutput>
        {
            [NotNull]
            private readonly IHandlerConfigurator<TInput, TOutput> _configurator;

            public ConverterConfigurator([NotNull] IHandlerConfigurator<TInput, TOutput> configurator)
            {
                _configurator = configurator;
            }

            #region IConverterConfigurator<TInput,TOutput,TNewInput,TNewOutput> Members

            IHandlerConfigurator<TNewInput, TNewOutput> IConverterConfigurator<TInput, TOutput, TNewInput, TNewOutput>.By<TConverter>()
                => _configurator.ConvertBy<TConverter, TNewInput, TNewOutput>();

            #endregion
        }

        #endregion

        #region Nested type: InputConverterConfigurator

        internal sealed class InputConverterConfigurator<TNewInput>
            : IInputConverterConfigurator<TInput, TOutput, TNewInput>
        {
            [NotNull]
            private readonly IHandlerConfigurator<TInput, TOutput> _configurator;

            public InputConverterConfigurator([NotNull] IHandlerConfigurator<TInput, TOutput> configurator)
            {
                _configurator = configurator;
            }

            #region Implementation of IInputConverterConfigurator<in TInput,TOutput,TNewInput>

            IHandlerConfigurator<TNewInput, TOutput> IInputConverterConfigurator<TInput, TOutput, TNewInput>.By<TConverter>()
                => _configurator.ConvertInputBy<TConverter, TNewInput>();

            #endregion
        }

        #endregion

        #region Nested type: OutputConverterConfigurator

        internal sealed class OutputConverterConfigurator<TNewOutput>
            : IOutputConverterConfigurator<TInput, TOutput, TNewOutput>
        {
            [NotNull]
            private readonly IHandlerConfigurator<TInput, TOutput> _configurator;

            public OutputConverterConfigurator([NotNull] IHandlerConfigurator<TInput, TOutput> configurator)
            {
                _configurator = configurator;
            }

            #region Implementation of IOutputConverterConfigurator<TInput,out TOutput,TNewOutput>

            IHandlerConfigurator<TInput, TNewOutput> IOutputConverterConfigurator<TInput, TOutput, TNewOutput>.By<TConverter>()
                => _configurator.ConvertOutputBy<TConverter, TNewOutput>();

            #endregion
        }

        #endregion
    }
}
