using System.Collections.Generic;
using System.Linq;
using Code.Gameplay.Features.Orb;
using Entitas;

namespace Code.Gameplay.Features.Invoker.Systems
{
    public class CastSpellSystem : IExecuteSystem
    {
        private readonly IGroup<GameEntity> _invokers;
        private readonly IGroup<GameEntity> _spells;
        private readonly IGroup<GameEntity> _orbs;

        public CastSpellSystem(GameContext game)
        {
            _invokers = game.GetGroup(GameMatcher
                .AllOf(
                    GameMatcher.Invoker,
                    GameMatcher.UltimatePressed));

            _spells = game.GetGroup(GameMatcher
                .AllOf(
                    GameMatcher.Spell)
                .NoneOf(
                    GameMatcher.ActivatedSpell,
                    GameMatcher.ReachedEnd));
        }

        public void Execute()
        {
            foreach (GameEntity invoker in _invokers.GetEntities())
            foreach (GameEntity spell in _spells.GetEntities())
            {
                List<OrbTypeId> invokerOrbs = invoker.ActiveOrbsForTest
                    .Select(orbEntity => orbEntity.OrbId)
                    .ToList();

                if (IsMatchCombination(invokerOrbs, spell.OrbForCast))
                {
                    spell.isActivatedSpell = true;
                    break;
                }
            }
        }
        
        private bool IsMatchCombination(List<OrbTypeId> invokerOrbs, List<OrbTypeId> spellOrbs)
        {
            return invokerOrbs.Count == spellOrbs.Count && 
                   !invokerOrbs.Except(spellOrbs).Any() && 
                   !spellOrbs.Except(invokerOrbs).Any();
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