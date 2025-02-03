using Entitas;

namespace Code.Gameplay.Features.Spells
{
    [Game] public class Spell : IComponent { }
    [Game] public class SpellId : IComponent { public SpellTypeId Value; }
    [Game] public class SpawnTimer : IComponent { public float Value; }
    [Game] public class ActivatedSpell : IComponent { }
}