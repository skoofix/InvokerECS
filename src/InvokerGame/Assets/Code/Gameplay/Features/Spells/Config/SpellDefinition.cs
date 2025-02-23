using System.Collections.Generic;
using Code.Gameplay.Features.Invoker;
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