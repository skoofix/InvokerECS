using Code.Gameplay.Features.Invoker;
using Code.Gameplay.Features.Invoker.Config;
using Code.Gameplay.Features.Spells;
using Code.Gameplay.Windows;
using UnityEngine;

namespace Code.Gameplay.StaticData
{
  public interface IStaticDataService
  {
    void LoadAll();

    SpellDefinition GetSpellDefinition(SpellTypeId spellTypeId);  
    OrbDefinition GetOrbDefinition(OrbTypeId orbTypeId);
    GameObject GetWindowPrefab(WindowId id);
  }
}