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
    public interface IHandlerConfigurator<TInput, TOutput>
    {
        Func<IResolver, IHandler<TInput, TOutput>> Build { get; }


        IHandlerConfigurator<TInput, TOutput> With<TInterceptor>() where TInterceptor : class, IInterceptor<TInput, TOutput>;


        IConverterConfigurator<TInput, TOutput, TNewInput, TNewOutput> ConvertTo<TNewInput, TNewOutput>();


        IInputConverterConfigurator<TInput, TOutput, TNewInput> InputTo<TNewInput>();


        IOutputConverterConfigurator<TInput, TOutput, TNewOutput> OutputTo<TNewOutput>();
    }
}
