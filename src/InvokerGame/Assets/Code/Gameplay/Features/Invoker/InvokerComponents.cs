using System.Collections.Generic;
using Entitas;

namespace Code.Gameplay.Features.Invoker
{
    [Game] public class Invoker : IComponent { }
    [Game] public class UltimatePressed : IComponent { }
    
    [Game] public class ActiveOrbs : IComponent { public List<OrbTypeId> Value; }
    
}