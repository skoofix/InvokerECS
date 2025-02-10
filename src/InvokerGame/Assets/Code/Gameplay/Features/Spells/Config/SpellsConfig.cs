using System.Collections.Generic;
using UnityEngine;

namespace Code.Gameplay.Features.Spells
{
    [CreateAssetMenu(fileName = "SpellsConfig", menuName = "Configs/SpellsConfig")]
    public class SpellsConfig : ScriptableObject
    {
        public List<SpellDefinition> spells;
    }
}