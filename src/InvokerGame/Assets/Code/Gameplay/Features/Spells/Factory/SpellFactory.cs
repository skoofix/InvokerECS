using Code.Common.Entity;
using Code.Common.Extensions;
using Code.Infrastructure.Identifiers;
using UnityEngine;

namespace Code.Gameplay.Features.Spells.Factory
{
    public class SpellFactory : ISpellFactory
    {
        private readonly IIdentifierService _identifiers;

        public SpellFactory(IIdentifierService identifiers)
        {
            _identifiers = identifiers;
        }

        public GameEntity CreateSpell(SpellTypeId typeId, Vector3 at)
        {
            return CreateEntity.Empty()
                .AddId(_identifiers.Next())
                .AddSpellId(typeId)
                .AddWorldPosition(at)
                .AddDirection(Vector2.zero)
                .AddSpeed(1)
                .AddMaxHp(1)
                .AddCurrentHp(1)
                .AddViewPath("Gameplay/Spells/SpellEnemy")
                .With(x => x.isSpell = true)
                .With(x => x.isMoving = false);
        }
    }
}