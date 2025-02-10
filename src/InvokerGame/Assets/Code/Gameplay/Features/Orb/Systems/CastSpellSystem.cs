using System.Collections.Generic;
using System.Linq;
using Code.Gameplay.Features.Spells;
using Code.Gameplay.StaticData;
using Entitas;
using UnityEngine;

namespace Code.Gameplay.Features.Orb.Systems
{
    public class CastSpellSystem : IExecuteSystem
    {
        private readonly IStaticDataService _staticData;
        private readonly IGroup<GameEntity> _invokers;
        private readonly IGroup<GameEntity> _spells;

        public CastSpellSystem(GameContext game, IStaticDataService staticData)
        {
            _staticData = staticData;
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
                Debug.Log("Ищу спелл");
                
                
                SpellDefinition foundSpellDef = _staticData.GetSpellConfig().spells
                    .FirstOrDefault(spellDef => spellDef.IsMatchCombination(invoker.ActiveOrbs));

                if (foundSpellDef != null && spell.SpellId == foundSpellDef.spellId)
                {
                    spell.isActivatedSpell = true;
                    break;
                }
            }
        }
    }
    
    public class CastSpellTestSystem : IExecuteSystem
    {
        private readonly IStaticDataService _staticData;
        private readonly IGroup<GameEntity> _invokers;
        private readonly IGroup<GameEntity> _spells;
        private readonly IGroup<GameEntity> _orbs;

        public CastSpellTestSystem(GameContext game, IStaticDataService staticData)
        {
            _staticData = staticData;
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
                Debug.Log("Ищу спелл");

                List<OrbTypeId> invokerOrbs = invoker.ActiveOrbsForTest
                    .Select(orbEntity => orbEntity.OrbId)
                    .ToList();
                
                SpellDefinition foundSpellDef = _staticData.GetSpellConfig().spells
                    .FirstOrDefault(spellDef => spellDef.IsMatchCombination(invokerOrbs));

                if (foundSpellDef != null && spell.SpellId == foundSpellDef.spellId)
                {
                    spell.isActivatedSpell = true;
                    break;
                }
            }
        }
    }
    
    public class CastSpellTest2System : IExecuteSystem
    {
        private readonly IStaticDataService _staticData;
        private readonly IGroup<GameEntity> _invokers;
        private readonly IGroup<GameEntity> _spells;
        private readonly IGroup<GameEntity> _orbs;

        public CastSpellTest2System(GameContext game)
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

            _orbs = game.GetGroup(GameMatcher
                .AllOf(
                    GameMatcher.Orb,
                    GameMatcher.Active));
        }

        public void Execute()
        {
            foreach (GameEntity invoker in _invokers)
            foreach (GameEntity orb in _orbs)
            foreach (GameEntity spell in _spells.GetEntities())
            {
                Debug.Log("Ищу спелл");

                List<OrbTypeId> invokerOrbs = invoker.ActiveOrbsForTest
                    .Select(orbEntity => orbEntity.OrbId)
                    .ToList();
                
                SpellDefinition foundSpellDef = _staticData.GetSpellConfig().spells
                    .FirstOrDefault(spellDef => spellDef.IsMatchCombination(invokerOrbs));

                if (foundSpellDef != null && spell.SpellId == foundSpellDef.spellId)
                {
                    spell.isActivatedSpell = true;
                    break;
                }
                
                
            }
        }
    }
}