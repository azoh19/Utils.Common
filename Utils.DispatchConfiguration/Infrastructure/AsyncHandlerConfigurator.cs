#region Using

using System;
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
        private readonly Func<IResolver, IAsyncHandler<TInput, TOutput>> _buildHandler;

        public AsyncHandlerConfigurator(Func<IResolver, IAsyncHandler<TInput, TOutput>> resolution)
        {
            _buildHandler = resolution ?? throw new ArgumentNullException(nameof(resolution));
        }

        Func<IResolver, IAsyncHandler<TInput, TOutput>> IAsyncHandlerConfigurator<TInput, TOutput>.Build => _buildHandler;

        IAsyncHandlerConfigurator<TInput, TOutput> IAsyncHandlerConfigurator<TInput, TOutput>.With<TInterceptor>()
        {
            IAsyncHandler<TInput, TOutput> Build(IResolver resolver)
            {
                var interceptor = resolver.Resolve<TInterceptor>();

                return _buildHandler(resolver).InterceptedBy(interceptor);
            }

            return new AsyncHandlerConfigurator<TInput, TOutput>(Build);
        }

        IAsyncConverterConfigurator<TInput, TOutput, TNewInput, TNewOutput> IAsyncHandlerConfigurator<TInput, TOutput>.ConvertTo<TNewInput, TNewOutput>()
            => new AsyncConverterConfigurator<TInput, TOutput, TNewInput, TNewOutput>(this);

        IInputAsyncConverterConfigurator<TInput, TOutput, TNewInput> IAsyncHandlerConfigurator<TInput, TOutput>.InputTo<TNewInput>()
            => new InputAsyncConverterConfigurator<TInput, TOutput, TNewInput>(this);

        IOutputAsyncConverterConfigurator<TInput, TOutput, TNewOutput> IAsyncHandlerConfigurator<TInput, TOutput>.OutputTo<TNewOutput>()
            => new OutputAsyncConverterConfigurator<TInput, TOutput, TNewOutput>(this);

        internal IAsyncHandlerConfigurator<TNewInput, TNewOutput> ConvertBy<TConverter, TNewInput, TNewOutput>()
            where TConverter : class, IFullAsyncConverter<TInput, TOutput, TNewInput, TNewOutput>
        {
            IAsyncHandler<TNewInput, TNewOutput> Build(IResolver resolver)
            {
                var converter = resolver.Resolve<TConverter>();

                return _buildHandler(resolver).ConvertedBy(converter);
            }

            return new AsyncHandlerConfigurator<TNewInput, TNewOutput>(Build);
        }

        internal IAsyncHandlerConfigurator<TNewInput, TOutput> ConvertInputBy<TConverter, TNewInput>()
            where TConverter : class, IInputAsyncConverter<TInput, TOutput, TNewInput>
        {
            IAsyncHandler<TNewInput, TOutput> Build(IResolver resolver)
            {
                var converter = resolver.Resolve<TConverter>();

                return _buildHandler(resolver).ConvertedBy(converter);
            }

            return new AsyncHandlerConfigurator<TNewInput, TOutput>(Build);
        }

        internal IAsyncHandlerConfigurator<TInput, TNewOutput> ConvertOutputBy<TConverter, TNewOutput>()
            where TConverter : class, IOutputAsyncConverter<TInput, TOutput, TNewOutput>
        {
            IAsyncHandler<TInput, TNewOutput> Build(IResolver resolver)
            {
                var converter = resolver.Resolve<TConverter>();

                return _buildHandler(resolver).ConvertedBy(converter);
            }

            return new AsyncHandlerConfigurator<TInput, TNewOutput>(Build);
        }
    }
}
