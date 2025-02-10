using Code.Common.Destruct;
using Code.Gameplay.Features.DamageApplication;
using Code.Gameplay.Features.Invoker;
using Code.Gameplay.Features.LifeTime;
using Code.Gameplay.Features.Movement;
using Code.Gameplay.Features.Orb;
using Code.Gameplay.Features.Spells;
using Code.Gameplay.Features.TargetCollection;
using Code.Gameplay.Input;
using Code.Infrastructure.Systems;
using Code.Infrastructure.View;

namespace Code.Gameplay
{
    public class BattleFeature : Feature
    {
        public BattleFeature(ISystemFactory systems)
        {
            Add(systems.Create<InputFeature>());
            Add(systems.Create<BindViewFeature>());

            Add(systems.Create<InvokerFeature>());
            Add(systems.Create<OrbFeature>());
            Add(systems.Create<SpellFeature>());
            Add(systems.Create<DeathFeature>());

            Add(systems.Create<MovementFeature>());

            Add(systems.Create<CollectTargetsFeature>());

            Add(systems.Create<DamageApplicationFeature>());

            Add(systems.Create<ProcessDestructedFeature>());
        }
    }
}