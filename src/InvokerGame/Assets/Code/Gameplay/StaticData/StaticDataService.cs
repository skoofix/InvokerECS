using Code.Gameplay.Features.Spells;
using UnityEngine;

namespace Code.Gameplay.StaticData
{
    public class StaticDataService : IStaticDataService
    {
        private SpellsConfig _spellsConfig;

        public void LoadAll()
        {
            LoadSpells();
        }

        public SpellsConfig GetSpellConfig()
        {
            return _spellsConfig;
        }

        public SpellDefinition GetSpellDefinition(SpellTypeId spellTypeId)
        {
            SpellsConfig spellsConfig = GetSpellConfig();

            return spellsConfig.spells[(int)spellTypeId];
        }
        
        private void LoadSpells()
        {
            _spellsConfig = Resources.Load<SpellsConfig>("SpellsConfig");
        }
    }
}
