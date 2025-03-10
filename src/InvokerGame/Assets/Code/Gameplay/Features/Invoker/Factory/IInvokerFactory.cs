using UnityEngine;

namespace Code.Gameplay.Features.Invoker.Factory
{
    public interface IInvokerFactory
    {
        GameEntity CreateInvoker();
    }
}