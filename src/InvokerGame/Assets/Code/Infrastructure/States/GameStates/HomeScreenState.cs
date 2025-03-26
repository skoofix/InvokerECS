using Code.Infrastructure.States.StateInfrastructure;
using Code.Infrastructure.Systems;
using Code.Meta;

namespace Code.Infrastructure.States.GameStates
{
    public class HomeScreenState : EndOfFrameExitState
    {
        private readonly ISystemFactory _systems;
        private readonly GameContext _game;
        private HomeScreenFeature _homeScreenFeature;

        public HomeScreenState(ISystemFactory systems, GameContext game)
        {
            _systems = systems;
            _game = game;
        }

        public override void Enter()
        {
            _homeScreenFeature = _systems.Create<HomeScreenFeature>();
            _homeScreenFeature.Initialize();
        }

        override protected void OnUpdate()
        {
            _homeScreenFeature.Execute();
            _homeScreenFeature.Cleanup();
        }

        override protected void ExitOnEndOfFrame()
        {
            _homeScreenFeature.DeactivateReactiveSystems();
            _homeScreenFeature.ClearReactiveSystems();

            DestructEntities();

            _homeScreenFeature.Cleanup();
            _homeScreenFeature.TearDown();
            _homeScreenFeature = null;
        }

        private void DestructEntities()
        {
            foreach (GameEntity entity in _game.GetEntities())
                entity.isDestructed = true;
        }
    }
}