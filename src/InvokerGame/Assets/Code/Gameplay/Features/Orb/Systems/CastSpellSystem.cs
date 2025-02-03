using System.Linq;
using Code.Gameplay.Features.Spells;
using Entitas;
using UnityEngine;

namespace Code.Gameplay.Features.Orb.Systems
{
    public class CastSpellSystem : IExecuteSystem
    {
        private readonly IGroup<GameEntity> _invokers;
        private readonly IGroup<GameEntity> _spells;
        private readonly IGroup<GameEntity> _inputs;

        private readonly SpellsConfig _spellsConfig;

        public CastSpellSystem(GameContext game)
        {
            _invokers = game.GetGroup(GameMatcher
                .AllOf(
                    GameMatcher.Invoker,
                    GameMatcher.UltimatePressed));

            _spells = game.GetGroup(GameMatcher.AllOf(GameMatcher.Spell).NoneOf(GameMatcher.ActivatedSpell));

            _spellsConfig = Resources.Load<SpellsConfig>("SpellsConfig");
        }

        public void Execute()
        {
            foreach (GameEntity invoker in _invokers.GetEntities())
            foreach (var spell in _spells.GetEntities())
            {
                Debug.Log("Ищу спелл");

                SpellDefinition foundSpellDef = _spellsConfig.spells
                    .FirstOrDefault(spellDef => spellDef.IsMatchCombination(invoker.ActiveOrbs));

                if (foundSpellDef != null && spell.SpellId == foundSpellDef.spellId)
                {
                    spell.isActivatedSpell = true;
                    break;
                }
            }
        }
    }
}