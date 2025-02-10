using System.Collections.Generic;
using System.Linq;
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
        
    }
}