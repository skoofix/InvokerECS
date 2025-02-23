using Code.Gameplay.Features.Invoker;
using Code.Gameplay.Features.Invoker.Config;
using Code.Gameplay.Features.Spells;

namespace Code.Gameplay.StaticData
{
  public interface IStaticDataService
  {
    void LoadAll();
    SpellsConfig GetSpellConfig();
    SpellDefinition GetSpellDefinition(SpellTypeId spellTypeId);
    OrbConfig GetOrbConfig();
    OrbDefinition GetOrbDefinition(OrbTypeId orbTypeId);
  }
}