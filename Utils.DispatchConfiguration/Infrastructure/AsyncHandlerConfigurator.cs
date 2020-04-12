#region Using

using System;
using JetBrains.Annotations;
using Utils.AbstractDI;
using Utils.DispatchConfiguration.Configurators;
using Utils.Handlers;
using Utils.Handlers.Converters;
using Utils.Handlers.Extensions;

#endregion

namespace Utils.DispatchConfiguration.Infrastructure
{
    internal sealed class AsyncHandlerConfigurator<TInput, TOutput>
        : IAsyncHandlerConfigurator<TInput, TOutput>
    {
        private Func<IResolver, IAsyncHandler<TInput, TOutput>> _buildHandler;

        public AsyncHandlerConfigurator([NotNull] Func<IResolver, IAsyncHandler<TInput, TOutput>> resolution)
        {
            _buildHandler = resolution ?? throw new ArgumentNullException(nameof(resolution));
        }

        #region IAsyncHandlerConfigurator<TInput,TOutput> Members

        IAsyncHandlerConfigurator<TInput, TOutput> IAsyncHandlerConfigurator<TInput, TOutput>.InterceptBy<TInterceptor>()
        {
            IAsyncHandler<TInput, TOutput> Build(IResolver resolver)
            {
                var interceptor = resolver.Resolve<TInterceptor>();

                return _buildHandler(resolver).InterceptedBy(interceptor);
            }

            return new AsyncHandlerConfigurator<TInput, TOutput>(Build);
        }

        IAsyncHandlerConfigurator<TNewInput, TNewOutput> IAsyncHandlerConfigurator<TInput, TOutput>.ConvertBy<TConverter, TNewInput, TNewOutput>()
        {
            IAsyncHandler<TNewInput, TNewOutput> Build(IResolver resolver)
            {
                var converter = resolver.Resolve<TConverter>();

                return _buildHandler(resolver).ConvertedBy(converter);
            }

            return new AsyncHandlerConfigurator<TNewInput, TNewOutput>(Build);
        }

        IAsyncHandlerConfigurator<TNewInput, TOutput> IAsyncHandlerConfigurator<TInput, TOutput>.ConvertInputBy<TConverter, TNewInput>()
        {
            IAsyncHandler<TNewInput, TOutput> Build(IResolver resolver)
            {
                var converter = resolver.Resolve<TConverter>();

                return _buildHandler(resolver).ConvertedBy(converter);
            }

            return new AsyncHandlerConfigurator<TNewInput, TOutput>(Build);
        }

        IAsyncHandlerConfigurator<TInput, TNewOutput> IAsyncHandlerConfigurator<TInput, TOutput>.ConvertOutputBy<TConverter, TNewOutput>()
        {
            IAsyncHandler<TInput, TNewOutput> Build(IResolver resolver)
            {
                var converter = resolver.Resolve<TConverter>();

                return _buildHandler(resolver).ConvertedBy(converter);
            }

            return new AsyncHandlerConfigurator<TInput, TNewOutput>(Build);
        }

        IAsyncConverterConfigurator<TInput, TOutput, TNewInput, TNewOutput> IAsyncHandlerConfigurator<TInput, TOutput>.ConvertTo<TNewInput, TNewOutput>()
            => new ConverterConfigurator<TNewInput, TNewOutput>(this);

        IInputAsyncConverterConfigurator<TInput, TOutput, TNewInput> IAsyncHandlerConfigurator<TInput, TOutput>.ConvertInputTo<TNewInput>()
            => new InputConverterConfigurator<TNewInput>(this);

        IOutputAsyncConverterConfigurator<TInput, TOutput, TNewOutput> IAsyncHandlerConfigurator<TInput, TOutput>.ConvertOutputTo<TNewOutput>()
            => new OutputConverterConfigurator<TNewOutput>(this);

        Func<IResolver, IAsyncHandler<TInput, TOutput>> IAsyncHandlerConfigurator<TInput, TOutput>.BuildHandler => _buildHandler;

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
