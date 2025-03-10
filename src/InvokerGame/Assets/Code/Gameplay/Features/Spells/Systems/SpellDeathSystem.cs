using System.Collections.Generic;
using Code.Gameplay.Features.VFX.Factory;
using Entitas;
using UnityEngine;

namespace Code.Gameplay.Features.Spells.Systems
{
    public class SpellDeathSystem : IExecuteSystem
    {
        private readonly IVFXFactory _vfxFactory;
        private readonly IGroup<GameEntity> _spells;

        public SpellDeathSystem(GameContext game, IVFXFactory vfxFactory)
        {
            _vfxFactory = vfxFactory;
            _spells = game.GetGroup(GameMatcher
                .AllOf(
                    GameMatcher.Spell,
                    GameMatcher.WorldPosition,
                    GameMatcher.Dead,
                    GameMatcher.ProcessingDeath));
        }

        public void Execute()
        {
            foreach (GameEntity spell in _spells)
            {
                spell.View.gameObject.SetActive(false);
                _vfxFactory.CreateExplosionVFX(spell.WorldPosition);
                spell.ReplaceSelfDestructTimer(2);
            }
        }
    }
}
