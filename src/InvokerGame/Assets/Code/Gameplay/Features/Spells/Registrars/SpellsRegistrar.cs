using Code.Common.Extensions;
using Code.Infrastructure.View.Registrars;
using UnityEngine;

namespace Code.Gameplay.Features.Spells.Registrars
{
    public class SpellsRegistrar : EntityComponentRegistrar
    {
        public override void RegisterComponents()
        {
            Entity
                .AddWorldPosition(transform.position)
                .AddDirection(Vector2.zero)
                .AddSpeed(1)
                .With(x=> x.isSpell = true)
                .With(x=> x.isMoving = true);
        }

        public override void UnregisterComponents()
        {
        }
    }
}