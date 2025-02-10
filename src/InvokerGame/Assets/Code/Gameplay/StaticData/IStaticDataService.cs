using Code.Gameplay.Features.Spells;

namespace Code.Gameplay.StaticData
{
  public interface IStaticDataService
  {
    void LoadAll();
    SpellsConfig GetSpellConfig();
    SpellDefinition GetSpellDefinition(SpellTypeId spellTypeId);
  }
}