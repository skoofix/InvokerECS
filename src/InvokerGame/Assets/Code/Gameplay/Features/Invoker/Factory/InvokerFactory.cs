using System.Collections.Generic;
using Code.Common.Entity;
using Code.Common.Extensions;
using Code.Gameplay.Features.Orb;
using Code.Infrastructure.Identifiers;
using UnityEngine;

namespace Code.Gameplay.Features.Invoker.Factory
{
    public class InvokerFactory : IInvokerFactory
    {
        private readonly IIdentifierService _identifiers;

        public InvokerFactory(IIdentifierService identifiers)
        {
            _identifiers = identifiers;
        }

        public GameEntity CreateInvoker(Vector3 at)
        {
            return CreateEntity.Empty()
                .AddId(_identifiers.Next())
                .AddWorldPosition(at)
                .AddDirection(Vector2.zero)
                .AddActiveOrbsForTest(new List<GameEntity>())
                .AddViewPath("Gameplay/Spells/Hero")
                .AddMaxHp(3)
                .AddCurrentHp(3)
                .With(x => x.isInvoker = true)
                .With(x => x.isUltimatePressed = false);
        }
    }
}