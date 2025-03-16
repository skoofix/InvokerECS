using System.Collections.Generic;
using Code.Common.Entity;
using Code.Common.Extensions;
using Code.Gameplay.Features.Invoker;
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

        public GameEntity CreateSpell(SpellTypeId typeId, Vector3 at, List<OrbTypeId> orbsForCast)
        {
            return CreateEntity.Empty()
                .AddId(_identifiers.Next())
                .AddSpellId(typeId)
                .AddWorldPosition(at)
                .AddDirection(Vector2.zero)
                .AddSpeed(1)
                .AddMaxHp(1)
                .AddCurrentHp(1)
                .AddDamage(1)
                .AddScore(5)
                .AddViewPath("Gameplay/Spells/SpellEnemy")
                .AddOrbForCast(orbsForCast)
                .With(x => x.isSpell = true)
                .With(x => x.isSpawning = true)
                .With(x => x.isMovementAvailable = true)
                .With(x => x.isMoving = false);
        }
    }
}