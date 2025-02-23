using Code.Gameplay.Features.Invoker;
using Code.Gameplay.Features.Invoker.Config;
using Code.Gameplay.Features.Spells;
using UnityEngine;

namespace Code.Gameplay.StaticData
{
    public class StaticDataService : IStaticDataService
    {
        private SpellsConfig _spellsConfig;
        private OrbConfig _orbsConfig;

        public void LoadAll()
        {
            LoadSpells();
            LoadOrbs();
        }

        public SpellsConfig GetSpellConfig() =>
            _spellsConfig;

        public OrbConfig GetOrbConfig() =>
            _orbsConfig;

        public SpellDefinition GetSpellDefinition(SpellTypeId spellTypeId)
        {
            SpellsConfig spellsConfig = GetSpellConfig();

            return spellsConfig.spells[(int)spellTypeId];
        }

        public OrbDefinition GetOrbDefinition(OrbTypeId orbTypeId)
        {
            OrbConfig orbConfig = GetOrbConfig();

            return orbConfig.orbs[(int)orbTypeId];
        }

        private void LoadSpells()
        {
            _spellsConfig = Resources.Load<SpellsConfig>("SpellsConfig");
        }

        private void LoadOrbs()
        {
            _orbsConfig = Resources.Load<OrbConfig>("OrbConfig");
        }
    }
}