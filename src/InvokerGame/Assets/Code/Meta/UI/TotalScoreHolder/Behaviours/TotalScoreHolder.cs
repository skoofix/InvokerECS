using Code.Meta.UI.TotalScoreHolder.Service;
using TMPro;
using UnityEngine;
using Zenject;

namespace Code.Meta.UI.TotalScoreHolder.Behaviours
{
    public class TotalScoreHolder : MonoBehaviour
    {
        public TextMeshProUGUI Amount;
        private ITotalScoreUIService _totalScoreUIService;

        [Inject]
        private void Construct(ITotalScoreUIService totalScoreUIService)
        {
            _totalScoreUIService = totalScoreUIService;
        }

        private void Start()
        {
            _totalScoreUIService.TotalScoreChanged += UpdateTotalScore;
            UpdateTotalScore();
        }

        private void OnDestroy() => 
            _totalScoreUIService.TotalScoreChanged -= UpdateTotalScore;

        private void UpdateTotalScore() =>
            Amount.text = _totalScoreUIService.TotalScore.ToString("0");
    }
}