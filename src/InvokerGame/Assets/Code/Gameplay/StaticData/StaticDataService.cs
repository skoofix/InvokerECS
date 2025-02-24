using System;
using System.Collections.Generic;
using System.Linq;
using Code.Gameplay.Features.Invoker;
using Code.Gameplay.Features.Invoker.Config;
using Code.Gameplay.Features.Spells;
using Code.Gameplay.Windows;
using Code.Gameplay.Windows.Configs;
using UnityEngine;

namespace Code.Gameplay.StaticData
{
    public class StaticDataService : IStaticDataService
    {
        private Dictionary<SpellTypeId, SpellDefinition> _spellsById;
        private Dictionary<OrbTypeId, OrbDefinition> _orbsById;
        private Dictionary<WindowId, GameObject> _windowPrefabsById;

        public void LoadAll()
        {
            LoadSpells();
            LoadOrbs();
            LoadWindows();
        }

        public SpellDefinition GetSpellDefinition(SpellTypeId spellTypeId) => 
            _spellsById.TryGetValue(spellTypeId, out SpellDefinition definition)
            ? definition
            : throw new Exception($"Spell definition for {spellTypeId} was not found");

        public OrbDefinition GetOrbDefinition(OrbTypeId orbTypeId) =>
            _orbsById.TryGetValue(orbTypeId, out OrbDefinition definition)
                ? definition
                : throw new Exception($"Orb definition for {orbTypeId} was not found");

        public GameObject GetWindowPrefab(WindowId id) =>
            _windowPrefabsById.TryGetValue(id, out GameObject prefab)
                ? prefab
                : throw new Exception($"Prefab config for window {id} was not found");

        private void LoadSpells()
        {
            SpellsConfig config = Resources.Load<SpellsConfig>("SpellsConfig");

            _spellsById = config.spells.ToDictionary(
                spell => spell.TypeId,
                spell => spell
            );
        }

        private void LoadOrbs()
        {
            OrbConfig config = Resources.Load<OrbConfig>("OrbConfig");

            _orbsById = config.orbs.ToDictionary(
                orb => orb.TypeId,
                orb => orb
            );
        }

        private void LoadWindows()
        {
            _windowPrefabsById = Resources
                .Load<WindowsConfig>("Configs/Windows/windowsConfig")
                .WindowConfigs
                .ToDictionary(x => x.Id, x => x.Prefab);
        }
    }
}