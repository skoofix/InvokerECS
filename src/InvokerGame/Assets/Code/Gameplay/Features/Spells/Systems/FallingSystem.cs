using Entitas;
using UnityEngine;

namespace Code.Gameplay.Features.Spells.Systems
{
    public class FallingSystem : IExecuteSystem
    {
        private readonly IGroup<GameEntity> _entities;

        public FallingSystem(GameContext game)
        {
            _entities = game.GetGroup(GameMatcher
                .AllOf(
                    GameMatcher.Spell, 
                    GameMatcher.WorldPosition));
        }

        public void Execute()
        {
            foreach (GameEntity entity in _entities)
            {
                entity.ReplaceDirection(Vector2.down);
            }
        }
    }
}