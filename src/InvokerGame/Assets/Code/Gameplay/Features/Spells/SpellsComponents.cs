using Entitas;

namespace Code.Gameplay.Features.Spells
{
    [Game] public class Spell : IComponent { }
    [Game] public class SpellId : IComponent { public SpellTypeId Value; }
}