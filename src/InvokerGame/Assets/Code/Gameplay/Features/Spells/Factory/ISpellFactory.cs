using System.Collections.Generic;
using Code.Gameplay.Features.Invoker;
using UnityEngine;

namespace Code.Gameplay.Features.Spells.Factory
{
    public interface ISpellFactory
    {
        GameEntity CreateSpell(SpellTypeId typeId, Vector3 at, List<OrbTypeId> orbsForCast);
    }
}