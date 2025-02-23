using System.Collections.Generic;
using Code.Gameplay.Features.Invoker.Behaviours;
using Entitas;

namespace Code.Gameplay.Features.Invoker
{
    [Game] public class Invoker : IComponent { }
    [Game] public class UltimatePressed : IComponent { }
    [Game] public class OrbChanged : IComponent { }
    
    [Game] public class ActiveOrbs : IComponent { public List<OrbTypeId> Value; }
    [Game] public class ActiveOrbsUI : IComponent { public OrbsUI Value; }

}