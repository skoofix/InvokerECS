using System.Collections.Generic;
using Code.Gameplay.Features.Orb;
using UnityEngine;

namespace Code.Gameplay.Features.Spells
{
    [CreateAssetMenu(fileName = "SpellsConfig", menuName = "Configs/SpellsConfig")]
    public class SpellsConfig : ScriptableObject
    {
        public List<SpellDefinition> spells;
    }

    [System.Serializable]
    public class SpellDefinition
    {
        public SpellTypeId spellId;
        public Sprite icon;
        public List<OrbTypeId> orbsForCast;
        
        public bool IsMatchCombination(List<OrbTypeId> invokerOrbs)
        {
            // 1) Если количество не совпадает — сразу false
            if (invokerOrbs.Count != orbsForCast.Count)
                return false;

            // 2) Копируем и сортируем оба списка, чтобы игнорировать порядок
            var castNeeded = new List<OrbTypeId>(orbsForCast);
            var castGiven = new List<OrbTypeId>(invokerOrbs);

            castNeeded.Sort();
            castGiven.Sort();

            // 3) Сравниваем поэлементно
            for (int i = 0; i < castNeeded.Count; i++)
            {
                if (castNeeded[i] != castGiven[i])
                    return false;
            }

            return true;
        }
    }
}