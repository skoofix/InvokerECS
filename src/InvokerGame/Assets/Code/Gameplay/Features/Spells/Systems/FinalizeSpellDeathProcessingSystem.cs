using System.Collections.Generic;
using Entitas;

namespace Code.Gameplay.Features.Spells.Systems
{
    public class FinalizeSpellDeathProcessingSystem : IExecuteSystem
    {
        private readonly IGroup<GameEntity> _spells;
        private readonly List<GameEntity> _buffer = new(128);

        public FinalizeSpellDeathProcessingSystem(GameContext game)
        {
            _spells = game.GetGroup(GameMatcher
                .AllOf(
                    GameMatcher.Spell,
                    GameMatcher.Dead,
                    GameMatcher.ProcessingDeath));
        }

        public void Execute()
        {
            foreach (GameEntity spell in _spells.GetEntities(_buffer))
            {
                spell.isProcessingDeath = false;
            }
        }
    }
}