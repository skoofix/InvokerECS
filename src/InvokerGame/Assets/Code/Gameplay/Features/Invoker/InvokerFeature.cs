using Code.Gameplay.Features.Invoker.Systems;
using Code.Infrastructure.Systems;

namespace Code.Gameplay.Features.Invoker
{
    public class InvokerFeature : Feature
    {
        public InvokerFeature(ISystemFactory systems)
        {
            Add(systems.Create<InitializeInvokerSystem>());
            
            Add(systems.Create<AddOrbToActiveSystem>());
            Add(systems.Create<UltimatePressedSystem>());
            Add(systems.Create<CastSpellSystem>());
            
            Add(systems.Create<InvokerDeathSystem>());
            Add(systems.Create<FinalizeInvokerDeathProcessingSystem>());
        }
    }
}