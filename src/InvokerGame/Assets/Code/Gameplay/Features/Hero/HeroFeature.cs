using Code.Gameplay.Features.Hero.Systems;
using Code.Infrastructure.Systems;

namespace Code.Gameplay.Features.Hero
{
    public class HeroFeature : Feature
    {
        public HeroFeature(ISystemFactory systems)
        {
            Add(systems.Create<InitializeInvokerSystem>());
            Add(systems.Create<SetHeroDirectionByInputSystem>());
            
            Add(systems.Create<InvokerDeathSystem>());
            Add(systems.Create<FinalizeInvokerDeathProcessingSystem>());
        }
    }
}