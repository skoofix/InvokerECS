using Code.Common.Entity;
using Code.Common.Extensions;
using Code.Infrastructure.Identifiers;
using UnityEngine;

namespace Code.Gameplay.Features.VFX.Factory
{
    public class VFXFactory : IVFXFactory
    {
        private readonly IIdentifierService _identifiers;

        public VFXFactory(IIdentifierService identifiers)
        {
            _identifiers = identifiers;
        }
        
        public GameEntity CreateExplosionVFX(Vector3 at)
        {
            return CreateEntity.Empty()
                .AddId(_identifiers.Next())
                .AddViewPath("Effects/Explosions/ExplosionVFX")
                .AddWorldPosition(at)
                .AddSelfDestructTimer(1f)
                .With(x => x.isVFX = true)
                .With(x => x.isExplosion = true);
        }
    }
}