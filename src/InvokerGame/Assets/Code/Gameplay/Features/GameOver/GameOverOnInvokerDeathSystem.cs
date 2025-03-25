using System.Collections.Generic;
using Code.Infrastructure.States.GameStates;
using Code.Infrastructure.States.StateMachine;
using Entitas;

namespace Code.Gameplay.Features.GameOver
{
    public class GameOverOnInvokerDeathSystem : ReactiveSystem<GameEntity>
    {
        private readonly IGameStateMachine _gameStateMachine;

        public GameOverOnInvokerDeathSystem(GameContext game, IGameStateMachine gameStateMachine) : base(game)
        {
            _gameStateMachine = gameStateMachine;
        }

        protected override ICollector<GameEntity> GetTrigger(IContext<GameEntity> context) =>
            context.CreateCollector(GameMatcher
                .AllOf(
                    GameMatcher.Invoker,
                    GameMatcher.Dead)
                .Added());

        protected override bool Filter(GameEntity invoker) => invoker.isDead;

        protected override void Execute(List<GameEntity> invokers)
        {
            foreach (GameEntity invoker in invokers)
            {
                _gameStateMachine.Enter<GameOverState>();
            }
        }
    }
}