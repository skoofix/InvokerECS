using System.Collections.Generic;
using UnityEngine;

namespace Code.Gameplay.Features.Invoker.Config
{
    [CreateAssetMenu(fileName = "OrbConfig", menuName = "Configs/OrbConfig")]
    public class OrbConfig : ScriptableObject
    {
        public List<OrbDefinition> orbs;
    }

    [System.Serializable]
    public class OrbDefinition
    {
        public OrbTypeId TypeId;
        public Sprite icon;
    }
}