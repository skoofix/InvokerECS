using System.Collections.Generic;
using Code.Gameplay.StaticData;
using Entitas;

namespace Code.Gameplay.Features.Spells.Systems
{
    public class UpdateSpriteSystem : IExecuteSystem
    {
        private readonly IStaticDataService _staticData;
        private readonly IGroup<GameEntity> _spells;
        private List<GameEntity> _buffer = new(64);

        public UpdateSpriteSystem(GameContext game, IStaticDataService staticData)
        {
            _staticData = staticData;
            _spells = game.GetGroup(GameMatcher
                .AllOf(
                    GameMatcher.Spell, 
                    GameMatcher.Spawning));
        }

        public void Execute()
        {
            foreach (GameEntity spell in _spells.GetEntities(_buffer))
            {
                if (spell.hasSpriteRenderer)
                {
                    spell.SpriteRenderer.sprite = _staticData.GetSpellDefinition(spell.SpellId).icon;
                    spell.isSpawning = false;
                    spell.isMoving = true;
                }
            }
        }
    }
}