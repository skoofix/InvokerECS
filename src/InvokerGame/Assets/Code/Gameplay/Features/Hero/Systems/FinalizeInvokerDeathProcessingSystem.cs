using System.Collections.Generic;
using Entitas;

namespace Code.Gameplay.Features.Hero.Systems
{
    public class FinalizeInvokerDeathProcessingSystem : IExecuteSystem
    {
        private readonly IGroup<GameEntity> _invokers;
        private readonly List<GameEntity> _buffer = new(10);

        public FinalizeInvokerDeathProcessingSystem(GameContext game)
        {
            _invokers = game.GetGroup(GameMatcher
                .AllOf(
                    GameMatcher.Invoker,
                    GameMatcher.Dead,
                    GameMatcher.ProcessingDeath));
        }

        public void Execute()
        {
            foreach (GameEntity invoker in _invokers.GetEntities(_buffer))
            {
                invoker.isProcessingDeath = false;
            }
        }
    }
}