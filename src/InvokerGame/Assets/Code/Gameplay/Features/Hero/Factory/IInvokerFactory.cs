using UnityEngine;

namespace Code.Gameplay.Features.Hero.Factory
{
    public interface IInvokerFactory
    {
        GameEntity CreateInvoker(Vector3 at);
    }
}