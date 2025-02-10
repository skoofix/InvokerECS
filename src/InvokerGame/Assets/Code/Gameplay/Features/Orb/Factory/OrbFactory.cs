using System;
using Code.Common.Entity;
using Code.Common.Extensions;

namespace Code.Gameplay.Features.Orb.Factory
{
    public class OrbFactory : IOrbFactory
    {
        public GameEntity CreateOrb(OrbTypeId type)
        {
            return type switch
            {
                OrbTypeId.Quas => CreateQuasOrb(),
                OrbTypeId.Wex => CreateWexOrb(),
                OrbTypeId.Exort => CreateExortOrb(),
                _ => throw new ArgumentOutOfRangeException(nameof(type), $"Unsupported orb type: {type}")
            };
        }
        
        public GameEntity CreateQuasOrb()
        {
            return CreateEntity.Empty()
                .AddOrbId(OrbTypeId.Quas)
                .With(x => x.isOrb = true)
                .With(x => x.isSpawning = true)
                .With(x => x.isQuas = true);
        }

        public GameEntity CreateWexOrb()
        {
            return CreateEntity.Empty()
                .AddOrbId(OrbTypeId.Wex)
                .With(x => x.isOrb = true)
                .With(x => x.isSpawning = true)
                .With(x => x.isWex = true);
        }

        public GameEntity CreateExortOrb()
        {
            return CreateEntity.Empty()
                .AddOrbId(OrbTypeId.Exort)
                .With(x => x.isOrb = true)
                .With(x => x.isSpawning = true)
                .With(x => x.isExort = true);
        }
    }
}