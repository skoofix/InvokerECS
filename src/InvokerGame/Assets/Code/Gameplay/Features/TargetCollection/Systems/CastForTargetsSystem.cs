using System.Collections.Generic;
using System.Linq;
using Code.Gameplay.Common.Physics;
using Entitas;

namespace Code.Gameplay.Features.TargetCollection.Systems
{
    public class CastForTargetsSystem : IExecuteSystem
    {
        private readonly IPhysicsService _physicsService;
        private readonly IGroup<GameEntity> _targets;
        private readonly List<GameEntity> _buffer = new (64);

        public CastForTargetsSystem(GameContext game, IPhysicsService physicsService)
        {
            _physicsService = physicsService;
            _targets = game.GetGroup(GameMatcher
                .AllOf(
                    GameMatcher.ReadyToCollectTargets,
                    GameMatcher.TargetBuffer,
                    GameMatcher.WorldPosition,
                    GameMatcher.Radius));
        }

        public void Execute()
        {
            foreach (GameEntity entity in _targets.GetEntities(_buffer))
            {
                entity.TargetBuffer.AddRange(TargetsInRadius(entity));

                entity.isReadyToCollectTargets = false;
                
            }
        }

        private IEnumerable<int> TargetsInRadius(GameEntity entity) => 
            _physicsService
                .OverlapBox(entity.WorldPosition, entity.Transform.localScale ,0, entity.LayerMask)
                .Select(x=> x.Id);
    }
}