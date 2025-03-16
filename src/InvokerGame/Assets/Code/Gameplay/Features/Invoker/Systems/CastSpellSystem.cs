using System.Collections.Generic;
using System.Linq;
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
                    GameMatcher.UltimatePressed,
                    GameMatcher.ActiveOrbs));

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
                if (IsMatchCombination(invoker.ActiveOrbs, spell.OrbForCast))
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
}