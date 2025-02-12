using System.Collections.Generic;
using Code.Gameplay.Features.Invoker;
using Code.Gameplay.Features.Spells.Behaviours;
using Entitas;

namespace Code.Gameplay.Features.Spells
{
    [Game] public class Spell : IComponent { }
    [Game] public class SpellId : IComponent { public SpellTypeId Value; }
    [Game] public class OrbForCastComponent : IComponent { public List<OrbTypeId> Value; }
    [Game] public class SpawnTimer : IComponent { public float Value; }
    [Game] public class SpellAnimatorComponent : IComponent { public SpellAnimator Value; }
    [Game] public class ActivatedSpell : IComponent { }
    [Game] public class Spawning : IComponent { }
    [Game] public class  ReachedEnd: IComponent { }
}