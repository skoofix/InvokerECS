using System.Collections.Generic;
using Entitas;
using UnityEngine;

namespace Code.Gameplay.Features.Invoker.Systems
{
    public class AddOrbToActiveSystem : IExecuteSystem
    {
        private readonly IGroup<GameEntity> _invokers;
        private readonly IGroup<GameEntity> _orbs;
        private readonly IGroup<GameEntity> _inputs;
        private readonly List<GameEntity> _buffer = new(5);

        public AddOrbToActiveSystem(GameContext game)
        {
            _invokers = game.GetGroup(GameMatcher
                .AllOf(
                    GameMatcher.Invoker,
                    GameMatcher.ActiveOrbs));

            _inputs = game.GetGroup(GameMatcher
                .AllOf(
                    GameMatcher.Input,
                    GameMatcher.SkillKey));
        }

        public void Execute()
        {
            foreach (GameEntity invoker in _invokers.GetEntities(_buffer))
            foreach (GameEntity input in _inputs)
            {
                AddOrbToActive(invoker, MapKeyToOrb(input.SkillKey));
                invoker.isOrbChanged = true;
            }
        }

        private void AddOrbToActive(GameEntity invoker, OrbTypeId orb)
        {
            List<OrbTypeId> activeOrbs = invoker.ActiveOrbs;

            if (activeOrbs.Count >= 3)
            {
                activeOrbs.RemoveAt(0);
            }

            activeOrbs.Add(orb);

            invoker.ReplaceActiveOrbs(activeOrbs);
        }

        private OrbTypeId MapKeyToOrb(KeyCode key)
        {
            return key switch
            {
                KeyCode.Q => OrbTypeId.Quas,
                KeyCode.W => OrbTypeId.Wex,
                KeyCode.E => OrbTypeId.Exort,
            };
        }
    }
}