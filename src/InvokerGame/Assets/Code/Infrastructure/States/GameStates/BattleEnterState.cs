using Code.Gameplay;
using Code.Gameplay.Features.Invoker.Factory;
using Code.Infrastructure.States.StateInfrastructure;
using Code.Infrastructure.States.StateMachine;
using Code.Infrastructure.Systems;

namespace Code.Infrastructure.States.GameStates
{
    public class BattleEnterState : SimpleState
    {
        private readonly IGameStateMachine _stateMachine;
        private readonly IInvokerFactory _heroFactory;
        private readonly ISystemFactory _systems;
        private readonly GameContext _gameContext;
        private BattleFeature _battleFeature;

        public BattleEnterState(
            IGameStateMachine stateMachine,
            IInvokerFactory heroFactory)
        {
            _stateMachine = stateMachine;
            _heroFactory = heroFactory;
        }

        public override void Enter()
        {
            PlaceHero();

            _stateMachine.Enter<BattleLoopState>();
        }

        private void PlaceHero()
        {
            _heroFactory.CreateInvoker();
        }
    }
    
    
}