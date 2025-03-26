using System;

namespace Code.Meta.UI.TotalScoreHolder.Service
{
    public class TotalScoreUIService : ITotalScoreUIService
    {
        private float _totalScore;

        public event Action TotalScoreChanged;
        
        public float TotalScore => _totalScore;

        public void UpdateTotalScore(float score)
        {
            _totalScore = score;
            TotalScoreChanged?.Invoke();
        }

        public void Cleanup()
        {
            _totalScore = 0f;

            TotalScoreChanged = null;
        }
    }
}