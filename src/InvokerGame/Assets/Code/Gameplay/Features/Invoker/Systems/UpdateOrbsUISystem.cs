using System.Collections.Generic;
using System.Linq;
using Code.Gameplay.StaticData;
using Entitas;
using UnityEngine;

namespace Code.Gameplay.Features.Invoker.Systems
{
    public class UpdateOrbsUISystem : IExecuteSystem
    {
        private readonly IStaticDataService _staticData;
        private readonly IGroup<GameEntity> _orbsUIs;
        private readonly IGroup<GameEntity> _invokers;
        private readonly List<GameEntity> _buffer = new(5);

        public UpdateOrbsUISystem(GameContext game, IStaticDataService staticData)
        {
            _staticData = staticData;

            _orbsUIs = game.GetGroup(GameMatcher
                .AllOf(GameMatcher.ActiveOrbsUI));

            _invokers = game.GetGroup(GameMatcher
                .AllOf(
                    GameMatcher.Invoker,
                    GameMatcher.ActiveOrbs,
                    GameMatcher.OrbChanged));
        }

        public void Execute()
        {
            foreach (GameEntity orbsUI in _orbsUIs)
            foreach (GameEntity invoker in _invokers.GetEntities(_buffer))
            {
                List<Sprite> sprites = invoker.ActiveOrbs
                    .Select(orbTypeId => _staticData.GetOrbDefinition(orbTypeId).icon)
                    .ToList();
                
                orbsUI.ActiveOrbsUI.SetOrbs(sprites);

                invoker.isOrbChanged = false;
            }
        }
    }
}