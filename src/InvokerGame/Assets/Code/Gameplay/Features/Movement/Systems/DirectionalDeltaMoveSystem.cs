using Entitas;

namespace Code.Gameplay.Features.Movement.Systems
{
    public class DirectionalDeltaMoveSystem : IExecuteSystem
    {
        private readonly IGroup<GameEntity> _movers;

        public DirectionalDeltaMoveSystem(GameContext game)
        {
            _movers = game.GetGroup(GameMatcher
                .AllOf(
                    GameMatcher.Speed,
                    GameMatcher.WorldPosition));
        }

        public void Execute()
        {
            foreach (GameEntity mover in _movers)
            {
                
            }
        }
    }

}