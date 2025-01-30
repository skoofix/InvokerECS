using System.Collections.Generic;
using Code.Common.Extensions;
using Code.Gameplay.Features.Orb;
using Code.Infrastructure.View.Registrars;
using UnityEngine;

namespace Code.Gameplay.Features.Hero.Registrars
{
    public class HeroRegistrar : EntityComponentRegistrar
    {
        public float Speed = 2f;

        public override void RegisterComponents()
        {
            Entity
                .AddWorldPosition(transform.position)
                .AddDirection(Vector2.zero)
                .AddSpeed(Speed)
                .AddActiveOrbs(new List<OrbTypeId>())
                .With(x => x.isInvoker = true)
                .With(x => x.isUltimatePressed = false);
        }

        public override void UnregisterComponents()
        {
        }
    }
}