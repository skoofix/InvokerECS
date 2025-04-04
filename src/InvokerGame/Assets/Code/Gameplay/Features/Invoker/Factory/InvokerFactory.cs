using System.Collections.Generic;
using Code.Common.Entity;
using Code.Common.Extensions;
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

        public GameEntity CreateInvoker()
        {
            return CreateEntity.Empty()
                .AddId(_identifiers.Next())
                .AddDirection(Vector2.zero)
                .AddActiveOrbs(new List<OrbTypeId>() {
                    OrbTypeId.Quas,
                    OrbTypeId.Wex,
                    OrbTypeId.Exort
                })
                .AddMaxHp(3)
                .AddCurrentHp(3)
                .AddScore(0)
                .With(x => x.isInvoker = true)
                .With(x => x.isOrbChanged = true)
                .With(x => x.isUltimatePressed = false);
        }
    }
}