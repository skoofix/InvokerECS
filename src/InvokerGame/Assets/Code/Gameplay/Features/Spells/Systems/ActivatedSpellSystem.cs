using System.Collections.Generic;
using Entitas;

namespace Code.Gameplay.Features.Spells.Systems
{
    public class ActivatedSpellSystem : IExecuteSystem
    {
        private readonly IGroup<GameEntity> _spells;
        private readonly List<GameEntity> _buffer = new(64);

        public ActivatedSpellSystem(GameContext game)
        {
            _spells = game.GetGroup(GameMatcher
                .AllOf(
                    GameMatcher.Spell,
                    GameMatcher.ActivatedSpell)
                .NoneOf(
                    GameMatcher.Dead));
        }

        public void Execute()
        {
            foreach (GameEntity spell in _spells.GetEntities(_buffer))
            {
                spell.isDead = true;
                spell.isProcessingDeath = true;
            }
        }
    }
}