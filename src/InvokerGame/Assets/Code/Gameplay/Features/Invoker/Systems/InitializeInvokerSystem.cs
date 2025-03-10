using Code.Gameplay.Features.Invoker.Factory;
using Entitas;

namespace Code.Gameplay.Features.Invoker.Systems
{
    public class InitializeInvokerSystem : IInitializeSystem
    {
        private readonly IInvokerFactory _invokerFactory;

        public InitializeInvokerSystem(IInvokerFactory invokerFactory)
        {
            _invokerFactory = invokerFactory;
        }
        
        public void Initialize()
        {
            _invokerFactory.CreateInvoker();
        }
    }
}