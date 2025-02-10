using System.Collections.Generic;
using Entitas;

namespace Code.Gameplay.Features.Spells.Systems
{
    public class ReachEndImpactSystem : IExecuteSystem
    {
        private readonly IGroup<GameEntity> _spells;
        private readonly IGroup<GameEntity> _invokers;
        private List<GameEntity> _buffer = new (64);

        public ReachEndImpactSystem(GameContext game)
        {
            _spells = game.GetGroup(GameMatcher
                .AllOf(
                    GameMatcher.Spell, 
                    GameMatcher.ReachedEnd)
                .NoneOf(
                    GameMatcher.Dead));
            
            _invokers = game.GetGroup(GameMatcher.AllOf(GameMatcher.Invoker));
        }

        public void Execute()
        {
            foreach (GameEntity spell in _spells.GetEntities(_buffer))
            foreach (GameEntity invoker in _invokers)
            {
                spell.isReachedEnd = false;
                
                if (invoker.hasMaxHp)
                {
                    invoker.ReplaceCurrentHp(invoker.CurrentHp - spell.Damage);
                }

                spell.ReplaceCurrentHp(0);
            }
        }
    }
}