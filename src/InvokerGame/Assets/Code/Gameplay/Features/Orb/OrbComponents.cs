using System.Collections.Generic;
using Entitas;
using UnityEngine.UI;

namespace Code.Gameplay.Features.Orb
{
    [Game] public class Orb : IComponent { }
    [Game] public class OrbIcon : IComponent { public Image Value; }
    [Game] public class OrbId : IComponent { public OrbTypeId Value; }
    [Game] public class ActiveOrbs : IComponent { public List<OrbTypeId> Value; }
    
    [Game] public class Invoker : IComponent { }
    [Game] public class UltimatePressed : IComponent { }
}