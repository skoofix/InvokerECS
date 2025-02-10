using System.Collections.Generic;
using Entitas;

namespace Code.Gameplay.Features.Orb.Systems
{
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