using System.Collections.Generic;
using Entitas;
using UnityEngine;

namespace Code.Gameplay.Features.Spells.Systems
{
    public class SpellDeathSystem : IExecuteSystem
    {
        private readonly IGroup<GameEntity> _spells;

        public SpellDeathSystem(GameContext game)
        {
            _spells = game.GetGroup(GameMatcher
                .AllOf(
                    GameMatcher.Spell, 
                    GameMatcher.Dead,
                    GameMatcher.ProcessingDeath));
        }

        public void Execute()
        {
            foreach (GameEntity spell in _spells)
            {
                spell.isMovementAvailable = false;
                
                if(spell.hasSpellAnimator)
                    spell.SpellAnimator.PlayDied();

                spell.ReplaceSelfDestructTimer(2);
                Debug.Log("попал в спелдез");
            }
        }
    }
}
