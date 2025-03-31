using TMPro;
using UnityEngine;

namespace Code.Gameplay.Features.Score.Behaviours
{
    public class ScoreUI : MonoBehaviour
    {
        public TextMeshProUGUI ScoreHolder;

        public void SetScore(float score) => 
            ScoreHolder.text = score.ToString("0");
    }
}