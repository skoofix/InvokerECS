//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGeneration.Plugins.ComponentLookupGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public static class GameComponentsLookup {

    public const int WorldPosition = 0;
    public const int Speed = 1;
    public const int Orb = 2;
    public const int OrbIcon = 3;
    public const int OrbId = 4;
    public const int Spell = 5;
    public const int SpellId = 6;

    public const int TotalComponents = 7;

    public static readonly string[] componentNames = {
        "WorldPosition",
        "Speed",
        "Orb",
        "OrbIcon",
        "OrbId",
        "Spell",
        "SpellId"
    };

    public static readonly System.Type[] componentTypes = {
        typeof(Code.Gameplay.Common.WorldPosition),
        typeof(Code.Gameplay.Features.Movement.Speed),
        typeof(Code.Gameplay.Features.Orb.Orb),
        typeof(Code.Gameplay.Features.Orb.OrbIcon),
        typeof(Code.Gameplay.Features.Orb.OrbId),
        typeof(Code.Gameplay.Features.Spells.Spell),
        typeof(Code.Gameplay.Features.Spells.SpellId)
    };
}
