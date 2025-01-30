using System.Collections.Generic;
using Entitas;
using UnityEngine;

namespace Code.Gameplay.Features.Orb.Systems
{
    public class ActiveOrbsSystem : IExecuteSystem
    {
        private readonly IGroup<GameEntity> _invokers;
        private readonly IGroup<GameEntity> _inputs;

        public ActiveOrbsSystem(GameContext game)
        {
            _invokers = game.GetGroup(GameMatcher.Invoker);
            _inputs = game.GetGroup(GameMatcher.Input);
        }

        public void Execute()
        {
            foreach (GameEntity input in _inputs)
            foreach (GameEntity invoker in _invokers)
            {
                if (!input.hasSkillKey)
                    continue;

                OrbTypeId? orbType = MapKeyToOrb(input.skillKey.Value);

                if (!orbType.HasValue)
                    continue;

                AddOrbToActive(invoker, orbType.Value);
            }
        }

        private OrbTypeId? MapKeyToOrb(KeyCode key)
        {
            return key switch
            {
                KeyCode.Q => OrbTypeId.Quas,
                KeyCode.W => OrbTypeId.Wex,
                KeyCode.E => OrbTypeId.Exort,
                _ => null
            };
        }

        private void AddOrbToActive(GameEntity invoker, OrbTypeId orbType)
        {
            var activeOrbs = invoker.hasActiveOrbs
                ? invoker.activeOrbs.Value
                : new List<OrbTypeId>();

            if (activeOrbs.Count >= 3)
                activeOrbs.RemoveAt(0);

            activeOrbs.Add(orbType);

            invoker.ReplaceActiveOrbs(activeOrbs);
        }
    }
}