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
            _invokers = game.GetGroup(GameMatcher
                .AllOf(GameMatcher.Invoker));
            
            _inputs = game.GetGroup(GameMatcher
                .AllOf(
                    GameMatcher.Input, 
                    GameMatcher.SkillKey));
        }

        public void Execute()
        {
            foreach (GameEntity input in _inputs)
            foreach (GameEntity invoker in _invokers)
            {
                OrbTypeId? orbType = MapKeyToOrb(input.SkillKey);

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
            List<OrbTypeId> activeOrbs = invoker.hasActiveOrbs
                ? invoker.activeOrbs.Value
                : new List<OrbTypeId>();

            if (activeOrbs.Count >= 3)
                activeOrbs.RemoveAt(0);

            activeOrbs.Add(orbType);

            invoker.ReplaceActiveOrbs(activeOrbs);
        }
    }

    public class AddOrbToActiveSystem : IExecuteSystem
    {
        private readonly IGroup<GameEntity> _invokers;
        private readonly IGroup<GameEntity> _orbs;

        public AddOrbToActiveSystem(GameContext game)
        {
            _invokers = game.GetGroup(GameMatcher
                .AllOf(
                    GameMatcher.Invoker, 
                    GameMatcher.ActiveOrbsForTest));

            _orbs = game.GetGroup(GameMatcher
                .AllOf(
                    GameMatcher.Orb,
                    GameMatcher.Spawning));
        }

        public void Execute()
        {
            foreach (GameEntity invoker in _invokers)    
            foreach (GameEntity orb in _orbs.GetEntities())    
            {
                AddOrbToActive(invoker, orb);
                orb.isSpawning = false;
                orb.isActive = true;
            }
        }
        
        private void AddOrbToActive(GameEntity invoker, GameEntity orb)
        {
            List<GameEntity> activeOrbs = invoker.ActiveOrbsForTest;

            if (activeOrbs.Count >= 3)
            {
                GameEntity s = activeOrbs[0];
                
                activeOrbs.RemoveAt(0);
                s.isDestructed = true;
            }
            
            activeOrbs.Add(orb);

            invoker.ReplaceActiveOrbsForTest(activeOrbs);
        }
    }
}