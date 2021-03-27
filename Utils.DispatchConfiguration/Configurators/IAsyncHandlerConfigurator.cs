#region Using

using System;
using JetBrains.Annotations;
using Utils.AbstractDI;
using Utils.Handlers;
using Utils.Handlers.Interceptors;

#endregion

namespace Utils.DispatchConfiguration.Configurators
{
    [PublicAPI]
    public interface IAsyncHandlerConfigurator<TInput, TOutput>
    {
        Func<IResolver, IAsyncHandler<TInput, TOutput>> Build { get; }


        IAsyncHandlerConfigurator<TInput, TOutput> With<TInterceptor>() where TInterceptor : class, IAsyncInterceptor<TInput, TOutput>;


        IAsyncConverterConfigurator<TInput, TOutput, TNewInput, TNewOutput> ConvertTo<TNewInput, TNewOutput>();


        IInputAsyncConverterConfigurator<TInput, TOutput, TNewInput> InputTo<TNewInput>();


        IOutputAsyncConverterConfigurator<TInput, TOutput, TNewOutput> OutputTo<TNewOutput>();
    }
}
