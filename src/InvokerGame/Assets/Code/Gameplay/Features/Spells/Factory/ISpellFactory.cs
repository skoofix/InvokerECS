using UnityEngine;

namespace Code.Gameplay.Features.Spells.Factory
{
    public interface ISpellFactory
    {
        GameEntity CreateSpell(SpellTypeId typeId, Vector3 at);
    }
}