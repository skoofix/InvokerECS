using System.Collections.Generic;
using Code.Common.Extensions;
using Code.Infrastructure.View.Registrars;

namespace Code.Gameplay.Features.DeathZone.Registrars
{
    public class DeathZoneRegistrar : EntityComponentRegistrar
    {
        public override void RegisterComponents()
        {
            Entity
                .AddWorldPosition(transform.position)
                .AddDamage(1)
                .AddTargetBuffer(new List<int>(10))
                .AddRadius(1f)
                .AddCollectTargetsInterval(0.5f)
                .AddCollectTargetsTimer(0)
                .AddLayerMask(CollisionLayer.Enemy.AsMask())
                .With(x => x.isDeathZone = true);
        }

        public override void UnregisterComponents()
        {
        }
    }
}