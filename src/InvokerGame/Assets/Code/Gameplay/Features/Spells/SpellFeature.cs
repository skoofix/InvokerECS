﻿using Code.Gameplay.Features.Score.Systems;
using Code.Gameplay.Features.Spells.Systems;
using Code.Infrastructure.Systems;

namespace Code.Gameplay.Features.Spells
{
    public sealed class SpellFeature : Feature
    {
        public SpellFeature(ISystemFactory systems)
        {
            Add(systems.Create<InitializeSpawnTimerSystem>());
            
            Add(systems.Create<SpellSpawnSystem>());
            Add(systems.Create<UpdateSpriteSystem>());
            
            Add(systems.Create<FallingSystem>());
            
            Add(systems.Create<ActivatedSpellSystem>());
            Add(systems.Create<AddScoreSystem>());
            Add(systems.Create<ReachEndImpactSystem>());
            
            Add(systems.Create<SpellDeathSystem>());
            Add(systems.Create<FinalizeSpellDeathProcessingSystem>());
        }
    }
}