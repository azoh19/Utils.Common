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
    internal sealed class HandlerConfigurator<TInput, TOutput>
        : IHandlerConfigurator<TInput, TOutput>
    {
        private readonly Func<IResolver, IHandler<TInput, TOutput>> _buildHandler;

        public HandlerConfigurator(Func<IResolver, IHandler<TInput, TOutput>> resolution)
        {
            _buildHandler = resolution ?? throw new ArgumentNullException(nameof(resolution));
        }

        Func<IResolver, IHandler<TInput, TOutput>> IHandlerConfigurator<TInput, TOutput>.Build => _buildHandler;

        IHandlerConfigurator<TInput, TOutput> IHandlerConfigurator<TInput, TOutput>.With<TInterceptor>()
        {
            IHandler<TInput, TOutput> Build(IResolver resolver)
            {
                var interceptor = resolver.Resolve<TInterceptor>();

                return _buildHandler(resolver).InterceptedBy(interceptor);
            }

            return new HandlerConfigurator<TInput, TOutput>(Build);
        }

        IConverterConfigurator<TInput, TOutput, TNewInput, TNewOutput> IHandlerConfigurator<TInput, TOutput>.
            ConvertTo<TNewInput, TNewOutput>()
            => new ConverterConfigurator<TInput, TOutput, TNewInput, TNewOutput>(this);

        IInputConverterConfigurator<TInput, TOutput, TNewInput> IHandlerConfigurator<TInput, TOutput>.InputTo<TNewInput>()
            => new InputConverterConfigurator<TInput, TOutput, TNewInput>(this);

        IOutputConverterConfigurator<TInput, TOutput, TNewOutput> IHandlerConfigurator<TInput, TOutput>.OutputTo<TNewOutput>()
            => new OutputConverterConfigurator<TInput, TOutput, TNewOutput>(this);

        internal IHandlerConfigurator<TNewInput, TNewOutput> ConvertBy<TConverter, TNewInput, TNewOutput>()
            where TConverter : class, IFullConverter<TInput, TOutput, TNewInput, TNewOutput>
        {
            IHandler<TNewInput, TNewOutput> Build(IResolver resolver)
            {
                var converter = resolver.Resolve<TConverter>();

                return _buildHandler(resolver).ConvertedBy(converter);
            }

            return new HandlerConfigurator<TNewInput, TNewOutput>(Build);
        }

        internal IHandlerConfigurator<TNewInput, TOutput> ConvertInputBy<TConverter, TNewInput>()
            where TConverter : class, IInputConverter<TInput, TOutput, TNewInput>
        {
            IHandler<TNewInput, TOutput> Build(IResolver resolver)
            {
                var converter = resolver.Resolve<TConverter>();

                return _buildHandler(resolver).ConvertedBy(converter);
            }

            return new HandlerConfigurator<TNewInput, TOutput>(Build);
        }

        internal IHandlerConfigurator<TInput, TNewOutput> ConvertOutputBy<TConverter, TNewOutput>()
            where TConverter : class, IOutputConverter<TInput, TOutput, TNewOutput>
        {
            IHandler<TInput, TNewOutput> Build(IResolver resolver)
            {
                var converter = resolver.Resolve<TConverter>();

                return _buildHandler(resolver).ConvertedBy(converter);
            }

            return new HandlerConfigurator<TInput, TNewOutput>(Build);
        }
    }
}
