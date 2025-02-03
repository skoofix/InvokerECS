using Entitas;

namespace Code.Gameplay.Features.Hero.Systems
{
    public class InvokerDeathSystem : IExecuteSystem
    {
        private readonly IGroup<GameEntity> _invokers;

        public InvokerDeathSystem(GameContext game)
        {
            _invokers = game.GetGroup(GameMatcher
                .AllOf(
                    GameMatcher.Invoker, 
                    GameMatcher.Dead, 
                    GameMatcher.ProcessingDeath));
        }

        public void Execute()
        {
            foreach (GameEntity invoker in _invokers)
            {
                
            }
        }
    }
}