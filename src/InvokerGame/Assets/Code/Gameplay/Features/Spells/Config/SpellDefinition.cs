using System.Collections.Generic;
using Code.Gameplay.Features.Orb;
using UnityEngine;

namespace Code.Gameplay.Features.Spells
{
    [System.Serializable]
    public class SpellDefinition
    {
        public SpellTypeId spellId;
        public Sprite icon;
        public List<OrbTypeId> orbsForCast;
        
        public bool IsMatchCombination(List<OrbTypeId> invokerOrbs)
        {
            if (invokerOrbs.Count != orbsForCast.Count)
                return false;

            var castNeeded = new List<OrbTypeId>(orbsForCast);
            var castGiven = new List<OrbTypeId>(invokerOrbs);

            castNeeded.Sort();
            castGiven.Sort();

            for (int i = 0; i < castNeeded.Count; i++)
            {
                if (castNeeded[i] != castGiven[i])
                    return false;
            }

            return true;
        }
    }
}