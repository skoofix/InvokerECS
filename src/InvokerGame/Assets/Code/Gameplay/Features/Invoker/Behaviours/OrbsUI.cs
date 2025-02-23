using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Code.Gameplay.Features.Invoker.Behaviours
{
    public class OrbsUI : MonoBehaviour
    {
        public List<Image> Orbs;

        public void SetOrbs(List<Sprite> images)
        {
            for (int i = 0; i < Orbs.Count ; i++)
            {
                Orbs[i].sprite = i < images.Count ? images[i] : null;
            }
        }
    }
}